using Carbook.Application.Repositories.CarPricingRepository;
using Carbook.Domain.Entities;
using Carbook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarbookContext _context;

		public CarPricingRepository(CarbookContext context)
		{
			_context = context;
		}

		public async Task<List<CarPricing>> GetCarPricingWithCars()
		{
			
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(x=>x.PricingId==3).ToList();
			return values;
		}
	}
}
