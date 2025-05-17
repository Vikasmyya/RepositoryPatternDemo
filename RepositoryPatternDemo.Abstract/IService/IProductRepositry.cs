using RepositoryPatternDemo.Data.Models;

namespace RepositoryPatternDemo.Abstract.IService
{
    public interface IProductRepositry : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetExpensiveProducts(decimal price);
    }
}
