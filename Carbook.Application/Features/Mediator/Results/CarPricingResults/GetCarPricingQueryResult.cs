using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Results.CarPricingResults
{
	public class GetCarPricingQueryResult
	{
		public int CarPricingId {  get; set; }
		public string PricingName { get; set; }
		public string BrandName {  get; set; }
		public string CarModel {  get; set; }
		public decimal Price {  get; set; }
		public string CoverImageUrl {  get; set; }
	}
}
