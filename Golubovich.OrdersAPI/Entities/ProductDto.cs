namespace Golubovich.OrdersAPI.Entities
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price*=Quantity;
    }
}
