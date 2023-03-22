using Papko.OrdersAPI.DTO;
using Papko.OrdersAPI.Interfaces;

namespace Papko.OrdersAPI.Repository;

public sealed class OrderRepository : IRepository<Product>
{
    public void Add()
    {
        throw new NotImplementedException();
    }

    public Product Find(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public Product Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Guid item)
    {
        throw new NotImplementedException();
    }
}
