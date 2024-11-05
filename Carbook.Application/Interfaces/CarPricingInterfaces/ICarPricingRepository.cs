using Carbook.Application.ViewModels;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Repositories.CarPricingRepository
{
	public interface ICarPricingRepository
	{
		Task<List<CarPricing>> GetCarPricingWithCars();
		List<CarPricingViewModel> GetCarPricingWithTimePeriod();

	}
}
