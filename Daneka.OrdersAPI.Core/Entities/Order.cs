namespace Daneka.OrdersAPI.Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public decimal Total => Items!.Sum(x => x.Item.Price * x.Quantity);
        public List<(Product Item, int Quantity)>? Items { get; set; } = new();
    }
}