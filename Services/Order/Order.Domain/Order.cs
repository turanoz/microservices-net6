using Order.Domain.Core;

namespace Order.Domain
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }

        public Address Address { get; private set; }

        public string BuyerId { get; private set; }

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {
        
        }

        public Order(string buyerId, Address address, decimal totalPrice)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
            TotalPrice = totalPrice;
        }

        public void AddOrderItem(string productId, string productName, int quantity, decimal price, string pictureUrl)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);

            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, pictureUrl, quantity, price);

                _orderItems.Add(newOrderItem);
            }
        }

        public decimal TotalPrice { get; private set; }
    }
}