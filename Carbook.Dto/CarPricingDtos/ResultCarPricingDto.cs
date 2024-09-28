using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Dto.CarPricingDtos
{
	public class ResultCarPricingDto
	{
        public int CarPricingId { get; set; }
        public string PricingName { get; set; }
        public string BrandName { get; set; }
        public string CarModel { get; set; }
        public decimal Price { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
