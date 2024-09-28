using Carbook.Application.Features.Mediator.Queries.CarPricingQueries;
using Carbook.Application.Features.Mediator.Results.CarPricingResults;
using Carbook.Application.Features.Mediator.Results.LocationResults;
using Carbook.Application.Repositories.CarPricingRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery,List<GetCarPricingQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetCarPricingWithCars();
			return values.Select(x => new GetCarPricingQueryResult
			{
				BrandName = x.Car.Brand.Name,
				PricingName=x.Pricing.Name,
				CarModel = x.Car.CarModel,
				CarPricingId = x.CarPricingId,
				CoverImageUrl = x.Car.CoverImageUrl,
				Price = x.Price
			}).ToList();
		}
	}
}
