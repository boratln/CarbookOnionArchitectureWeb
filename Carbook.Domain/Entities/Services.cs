using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Domain.Entities
{
    public class Services
    {
        public int ServicesId { get; set; }
        public string Title {  get; set; }
        public string Description {  get; set; }
        public string IconUrl {  get; set; }
    }
}
