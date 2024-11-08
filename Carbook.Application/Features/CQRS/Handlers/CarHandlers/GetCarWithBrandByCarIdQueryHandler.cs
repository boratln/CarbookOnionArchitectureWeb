using Carbook.Application.Features.CQRS.Queries.CarQueries;
using Carbook.Application.Features.CQRS.Results.CarResults;
using Carbook.Application.Interfaces.CarInterfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWithBrandByCarIdQueryHandler
	{
		private readonly ICarRepository _carRepository;

		public GetCarWithBrandByCarIdQueryHandler(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}
		public async Task<GetCarWithBrandByCarIdQueryResult> Handle(GetCarWithBrandByCarIdQuery query)
		{
			var value = await _carRepository.GetCarWithBrandByCarId(query.Id);
			return new GetCarWithBrandByCarIdQueryResult
			{
				BigImageUrl = value.BigImageUrl,
				BrandId = value.BrandId,
				BrandName = value.Brand.Name,
				CarId = value.CarId,
				CarModel = value.CarModel,
				CoverImageUrl = value.CoverImageUrl,
				Fuel = value.Fuel,
				Kilometer = value.Kilometer,
				Luggage = value.Luggage,
				Seat = value.Seat,
				Transmission = value.Transmission
			};
		}
	}
}
