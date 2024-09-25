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

        public List<Blog> GetLast3BlogWithAuthors()
        {
            var values = _carbookContext.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogId).Take(3).ToList();
            return values;
        }
    }
}
