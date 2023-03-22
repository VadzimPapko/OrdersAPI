using Spurhiash.OrderAPI.Models;

namespace Spurhiash.OrderAPI.Data
{
    public static class OrderData
    {
        public static List<Order> Orders { get; } = new List<Order>
    {
        new Order
        {
            Id = Guid.NewGuid(),
            Total = 30.00M,
            BuyerId = Guid.NewGuid(),
            ProductItems = new List<ProductItem>
            {
                new ProductItem { ProductName = "Product 1", ProductPrice = 10.00M, Quantity = 2 },
                new ProductItem { ProductName = "Product 2", ProductPrice = 5.00M, Quantity = 4 }
            }
        },
        new Order
        {
            Id = Guid.NewGuid(),
            Total = 15.50M,
            BuyerId = Guid.NewGuid(),
            ProductItems = new List<ProductItem>
            {
                new ProductItem { ProductName = "Product 3", ProductPrice = 5.50M, Quantity = 2 }
            }
        }
    };
    }
}
