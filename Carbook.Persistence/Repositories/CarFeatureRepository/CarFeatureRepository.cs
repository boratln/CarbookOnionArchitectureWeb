using Carbook.Application.Interfaces.CarFeatureInterfaces;
using Carbook.Domain.Entities;
using Carbook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Persistence.Repositories.CarFeatureRepository
{
	public class CarFeatureRepository : ICarFeatureRepository
	{
		private readonly CarbookContext _context;

		public CarFeatureRepository(CarbookContext context)
		{
			_context = context;
		}

		public void ChangeCarFeatureAvaliableToFalse(int id)
		{
			var value=_context.CarFeatures.Where(x=>x.CarFeatureId == id).FirstOrDefault();
			value.Available = false;
			_context.SaveChanges();
				}

		public void ChangeCarFeatureAvaliableToTrue(int id)
		{
			var value = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
			value.Available = true;
			_context.SaveChanges();
		}

		public void CreateCarFeatureByCar(CarFeature CarFeature)
		{
			_context.CarFeatures.Add(CarFeature);
			_context.SaveChanges();
		}

		public async  Task<List<CarFeature>> GetCarFeatureByCarId(int carId)
		{
			var values=await _context.CarFeatures.Include(x=>x.Feature).Include(x=>x.Car).Where(x=>x.CarId == carId).ToListAsync();
			return values;
		}
	}
}
