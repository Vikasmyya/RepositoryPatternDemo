using RepositoryPatternDemo.Abstract.IService;
using RepositoryPatternDemo.Abstract.UnitOfWork;
using RepositoryPatternDemo.Data.Models;
using RepositoryPatternDemo.Service.Service;

namespace RepositoryPatternDemo.Service.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork   
    {
        private readonly ProductDbContext _context;
        public IProductRepositry Product { get; private set; }

        public UnitOfWork(ProductDbContext context)
        {
            _context = context;
            Product = new ProductRepositry(_context);
        }

        public async Task<int> SaveChnages()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
