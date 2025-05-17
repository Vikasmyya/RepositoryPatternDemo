using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Abstract.IService;
using RepositoryPatternDemo.Data.Models;

namespace RepositoryPatternDemo.Service.Service
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ProductDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity); 
        }

        public void DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

    }
}
