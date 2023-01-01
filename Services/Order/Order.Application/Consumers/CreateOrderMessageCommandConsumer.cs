using MassTransit;
using Order.Domain;
using Order.Infrastructure;
using Shared.Messages;

namespace Order.Application.Consumers
{
    public class CreateOrderMessageCommandConsumer : IConsumer<CreateOrderMessageCommand>
    {
        private readonly AppDbContext _context;


        public CreateOrderMessageCommandConsumer(AppDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
        {
            var newAddress = new Address(context.Message.Province, context.Message.District, context.Message.Street,
                context.Message.ZipCode, context.Message.Line);

            Domain.Order order = new Domain.Order(context.Message.BuyerId, newAddress, context.Message.TotalPrice);

            context.Message.OrderItems.ForEach(x =>
            {
                order.AddOrderItem(x.ProductId, x.ProductName, x.Quantity, x.Price, x.PictureUrl);
            });

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();
        }
    }
}