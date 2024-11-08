using Carbook.Application.Interfaces.CarDescriptionInterfaces;
using Carbook.Domain.Entities;
using Carbook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Persistence.Repositories.CarDescriptionRepositories
{
	public class CarDescriptionRepository : ICarDescriptionRepository
	{
		private readonly CarbookContext _context;

		public CarDescriptionRepository(CarbookContext context)
		{
			_context = context;
		}

		public async Task<CarDescription> GetCarDescriptionByCarId(int carId)
		{
			var value = await _context.CarDescriptions.Include(x => x.Car).Where(x => x.CarId == carId).FirstOrDefaultAsync();
			return value;
		}
	}
}
