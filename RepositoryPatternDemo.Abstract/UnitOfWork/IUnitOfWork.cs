using RepositoryPatternDemo.Abstract.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternDemo.Abstract.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepositry Product { get; }
        Task<int> SaveChnages();
    }
}
