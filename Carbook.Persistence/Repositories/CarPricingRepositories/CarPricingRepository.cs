using Carbook.Application.Repositories.CarPricingRepository;
using Carbook.Application.ViewModels;
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

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "Select * From (Select CarModel,Name,CoverImageUrl,PricingId,Price From CarPricings Inner Join Cars On Cars.CarId=CarPricings.CarId Inner Join Brands On Brands.BrandId=Cars.BrandId) As SourceTable Pivot (Sum(Price) For PricingId In ([3],[4],[5])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Brand = reader["Name"].ToString(),
							Model = reader["CarModel"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
					{
						reader["3"] != DBNull.Value ? Convert.ToDecimal(reader["3"]) : 0,
						reader["4"] != DBNull.Value ? Convert.ToDecimal(reader["4"]) : 0,
						reader["5"] != DBNull.Value ? Convert.ToDecimal(reader["5"]) : 0
					}
						};
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}


		public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "Select * From (Select CarModel,Name,CoverImageUrl,PricingId,Price From CarPricings Inner Join Cars On Cars.CarId=CarPricings.CarId Inner Join Brands On Brands.BrandId=Cars.BrandId) As SourceTable Pivot (Sum(Price) For PricingId In ([3],[4],[5])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Brand = reader["Name"].ToString(),
							Model = reader["CarModel"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
							{
								Convert.ToDecimal(reader["3"]),
								Convert.ToDecimal(reader["4"]),
								Convert.ToDecimal(reader["5"])
							}
						};
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}
	}
}
