using Carbook.Application.Interfaces.BlogInterFaces;
using Carbook.Domain.Entities;
using Carbook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarbookContext _carbookContext;

        public BlogRepository(CarbookContext carbookContext)
        {
            _carbookContext = carbookContext;
        }

        public List<Blog> GetAllBlogsWithAuthors()
        {
            var values = _carbookContext.Blogs.Include(x => x.Author).Include(x => x.Category).ToList();
            return values;
        }

        public Blog GetByBlog(int id)
        {
            var value = _carbookContext.Blogs.Include(x => x.Author).Include(x => x.Category).FirstOrDefault(x => x.BlogId == id);
            return value;
        }

        public Blog GetByBlogWithAuthor(int id)
        {
            // Blog ile birlikte yazarı dahil ederek tek bir sorgu ile çekiyoruz
            var value = _carbookContext.Blogs
                                       .Include(x => x.Author)  // Blog ile yazarı da dahil ediyoruz
                                       .FirstOrDefault(x => x.BlogId == id); // BlogId'ye göre arıyoruz

            // Eğer blog bulunamazsa, null döneriz
            if (value == null)
            {
                return null;
            }

            return value;
        }


        public List<Blog> GetLast3BlogWithAuthors()
        {
            var values = _carbookContext.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogId).Take(3).ToList();
            return values;
        }
    }
}
