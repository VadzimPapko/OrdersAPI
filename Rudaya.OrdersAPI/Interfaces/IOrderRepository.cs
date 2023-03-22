using Rudaya.OrdersAPI.Entities;

namespace Rudaya.OrdersAPI.Interfaces
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetOrders();

        public Order GetOrderById(Guid orderId);

        public void CreateOrder(Order order);

        public void UpdateOrder(Order order);

        public void DeleteOrder(Order order);
    }
}
