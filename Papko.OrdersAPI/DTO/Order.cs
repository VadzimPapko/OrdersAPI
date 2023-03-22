namespace Papko.OrdersAPI.DTO;

public class Order
{
    public Guid Id { get; set; }
    public decimal Total { get; set; }
    public Guid BuyerId { get; set; }

    public Order() => Id = Guid.NewGuid();
}
