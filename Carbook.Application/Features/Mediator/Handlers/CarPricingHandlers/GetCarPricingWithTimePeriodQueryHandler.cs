using Carbook.Application.Features.Mediator.Queries.CarPricingQueries;
using Carbook.Application.Features.Mediator.Results.CarPricingResults;
using Carbook.Application.Interfaces;
using Carbook.Application.Repositories.CarPricingRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _carpricingrepository;

		public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository carpricingrepository)
		{
			_carpricingrepository = carpricingrepository;
		}

		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = _carpricingrepository.GetCarPricingWithTimePeriod();
			return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
			{
				Brand = x.Brand,
				CarModel = x.Model,
				CoverImageUrl = x.CoverImageUrl,
				DailyAmount = x.Amounts[0],
				WeeklyAmount = x.Amounts[1],
				MonthlyAmount = x.Amounts[2]
			}).ToList();
		}
	}
}
