using Rudaya.OrdersAPI.Entities;
using Rudaya.OrdersAPI.Interfaces;

namespace Rudaya.OrdersAPI.Repository
{
    public sealed class OrderRepository : IOrderRepository
    {
        private static List<Order> _orders = new();

        public void CreateOrder(Order order)
        {
           _orders.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            _orders.Remove(order);
        }

        public Order? GetOrderById(Guid orderId)
        {
            return _orders.Where(_ => _.Id == orderId)
                            .FirstOrDefault();
        }

        public IEnumerable<Order> GetOrders()
        {
            return  _orders.ToList();
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = _orders.FirstOrDefault(_ => _.Id == order.Id);

            if (existingOrder != null)
            {
                existingOrder.TotalPrice = order.TotalPrice;
                existingOrder.BuyerId = order.BuyerId;
                existingOrder.Products = order.Products;
                existingOrder.ProductName = order.ProductName;
                existingOrder.ProductPrice = order.ProductPrice;
                existingOrder.Quantity = order.Quantity;
            }
            else
            {
                throw new ArgumentException($"Order with ID {order.Id} doesn't exist");
            }
        }
    }
}
