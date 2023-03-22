namespace Papko.OrdersAPI.Interfaces;

public interface IRepository<TModel> where TModel : class
{
    void Add();
    IEnumerable<TModel> GetAll();
    TModel Find(Guid id);
    TModel Remove(Guid id);
    void Update(Guid item);
}
