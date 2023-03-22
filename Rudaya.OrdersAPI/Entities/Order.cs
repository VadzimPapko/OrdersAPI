namespace Rudaya.OrdersAPI.Entities
{
    public sealed class Order
    {
        public Guid Id { get; set; }

        public decimal TotalPrice { get; set; }

        public Guid BuyerId { get; set; }

        public List<Product>? Products { get; set; }

        public string? ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}
