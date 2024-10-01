using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Dto.BlogDtos
{
    public class GetByBlogAndAuthorDto
    {
        public GetByBlogDto getByBlogDto { get; set; }
        public GetByBlogWithAuthorDto getByBlogWithAuthorDto { get; set; }
    }
}
