using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Abstract.IService;
using RepositoryPatternDemo.Data.Models;

namespace RepositoryPatternDemo.Service.Service
{
    public class ProductRepositry : GenericRepository<Product>, IProductRepositry
    {
        public ProductRepositry(ProductDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetExpensiveProducts(decimal price)
        {
            return await _context.Products.Where(p=>p.Price>price).ToListAsync();
        }
    }
}
