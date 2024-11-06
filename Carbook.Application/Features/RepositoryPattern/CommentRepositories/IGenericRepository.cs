using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.RepositoryPattern.CommentRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
        int Count(int blogid);

        T GetById(int id);
        List<T> GetCommentsByBlogId(int id);

    }
}
