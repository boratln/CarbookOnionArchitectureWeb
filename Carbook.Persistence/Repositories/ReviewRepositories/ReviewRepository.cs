using Carbook.Application.Interfaces.ReviewInterfaces;
using Carbook.Domain.Entities;
using Carbook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Persistence.Repositories.ReviewRepositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly CarbookContext _context;

		public ReviewRepository(CarbookContext context)
		{
			_context = context;
		}

		public async Task<List<Review>> GetReviewsByCarId(int carId)
		{
			var values = await _context.Reviews.Include(x => x.Car).Where(x => x.CarId == carId).ToListAsync();
			return values;
		}

		public int ReviewCount(int carId)
		{
			var count=_context.Reviews.Where(x=>x.CarId == carId).Count();
			return count;
		}
	}
}
