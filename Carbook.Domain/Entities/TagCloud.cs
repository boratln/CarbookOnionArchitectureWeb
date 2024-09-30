using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Domain.Entities
{
    public class TagCloud
    {
        public int TagCloudId { get; set; }
        public string Title {  get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
