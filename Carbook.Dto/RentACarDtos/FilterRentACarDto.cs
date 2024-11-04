using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Dto.RentACarDtos
{
	public class FilterRentACarDto
	{
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string CarModel { get; set; }
        public decimal Price { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
