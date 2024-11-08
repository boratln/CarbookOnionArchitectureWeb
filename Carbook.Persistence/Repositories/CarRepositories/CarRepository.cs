using Carbook.Application.Interfaces.CarInterfaces;
using Carbook.Domain.Entities;
using Carbook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarbookContext _context;
        public CarRepository(CarbookContext context)
        {
            _context = context;
        }

    

        public async  Task <List<Car>> GetCarsListWithBrand()
        {
            var values= await _context.Cars.Include(x=>x.Brand).ToListAsync();
            return values;
        }

		public async Task<Car> GetCarWithBrandByCarId(int CarId)
		{
			var value=await _context.Cars.Include(x=>x.Brand).Where(x=>x.CarId== CarId).FirstOrDefaultAsync();
            return value;
		}

		public async Task<List<Car>> GetLast5CarsWithBrand()
        {
           var values=await _context.Cars.Include(x=>x.Brand).OrderByDescending(x=>x.CarId).Take(5).ToListAsync();
            return values;
        }
    }
}
