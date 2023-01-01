using Order.Domain.Core;

namespace Order.Domain
{
    public class OrderItem : Entity
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUrl { get; private set; }
        
        public int Quantity { get; private set; }
        public Decimal Price { get; private set; }
      
        public OrderItem()
        {
        }

        public OrderItem(string productId, string productName, string pictureUrl,int quantity, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
            Quantity = quantity;
            Price = price;
        }

        public void UpdateOrderItem(string productName, string pictureUrl, int quantity,decimal price)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            PictureUrl = pictureUrl;
        }
    }
}
