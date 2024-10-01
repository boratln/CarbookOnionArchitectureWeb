using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Results.BlogResults
{
    public class GetByBlogWithAuthorQueryResult
    {
        public int BlogId { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorUrl { get; set; }

        public string CategoryName { get; set; }
    }
}
