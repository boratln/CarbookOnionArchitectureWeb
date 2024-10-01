using Carbook.Application.Interfaces.TagCloudInterfaces;
using Carbook.Domain.Entities;
using Carbook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarbookContext _context;

        public TagCloudRepository(CarbookContext context)
        {
            _context = context;
        }

        public List<TagCloud> GetTagCloudByBlogId(int id)
        {
            var values = _context.TagClouds.Where(x => x.BlogId == id).ToList();
            return values;
        }
    }
}
