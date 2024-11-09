using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task<List<T>> GetAll();
        Task <T> GetById(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task <T?> GetByFilter(Expression<Func<T, bool>> filter);
    }
}
