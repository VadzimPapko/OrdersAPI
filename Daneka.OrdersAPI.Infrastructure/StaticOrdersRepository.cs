using Daneka.OrdersAPI.Core.Entities;
using Daneka.OrdersAPI.Core.Interfaces;

namespace Daneka.OrdersAPI.Infrastructure
{
    public class StaticOrdersRepository : IRepository<Order>
    {
        private static readonly List<Order> _orders = new()
        {
            new Order
            {
                Id = Guid.NewGuid(),
                BuyerId = Guid.NewGuid(),
                Items = new StaticProductRepository().GetAll().Select(x => (x, 1)).ToList()
            }
        };

        public bool Delete(Order entity)
        {
            return _orders.Remove(entity);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders.AsEnumerable();
        }

        public Order? GetById(Guid id)
        {
            return _orders.Find(order => order.Id == id);
        }

        public bool Update(Order entity)
        {
            var updateIndex = _orders.FindIndex(order => order.Id == entity.Id);
            if (updateIndex > 0)
            {
                _orders[updateIndex] = entity;
                return true;
            }
            return false;
        }
    }
}