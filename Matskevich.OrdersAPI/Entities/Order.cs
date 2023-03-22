namespace Matskevich.OrdersAPI.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Buyer { get; set; }
        public decimal Total { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public Order()
        {
            Id = Guid.NewGuid();
        }        
    }
}
