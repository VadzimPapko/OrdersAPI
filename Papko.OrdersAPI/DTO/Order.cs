namespace Papko.OrdersAPI.DTO;

public sealed class Order
{
    public Guid Id { get; set; }
    public Guid BuyerId { get; set; }
    List<Product> Products { get; set; }
    public int Quantity => Products.Count;
    public decimal TotalPrice => Products.Sum(p => p.Price);
    
    public Order() => Id = Guid.NewGuid();
}
