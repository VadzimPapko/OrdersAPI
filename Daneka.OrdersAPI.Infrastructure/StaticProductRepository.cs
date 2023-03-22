using Daneka.OrdersAPI.Core.Entities;
using Daneka.OrdersAPI.Core.Interfaces;

namespace Daneka.OrdersAPI.Infrastructure
{
    public class StaticProductRepository : IRepository<Product>
    {
        private static readonly List<Product> _products = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Xiaomi Redmi 7 Note",
                Price = 230
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Iphone 11",
                Price = 1000
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Galaxy X1",
                Price = 800
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Xiaomi Mi Band 2",
                Price = 30
            }
        };

        public bool Delete(Product entity)
        {
            return _products.Remove(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products.AsEnumerable();
        }

        public Product? GetById(Guid id)
        {
            return _products.Find(order => order.Id == id);
        }

        public bool Update(Product entity)
        {
            var updateIndex = _products.FindIndex(order => order.Id == entity.Id);
            if (updateIndex > 0)
            {
                _products[updateIndex] = entity;
                return true;
            }
            return false;
        }
    }
}