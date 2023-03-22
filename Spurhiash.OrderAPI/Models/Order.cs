namespace Spurhiash.OrderAPI.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public Guid BuyerId { get; set; }
        public List<ProductItem> ProductItems { get; set; }
    }
}
