using Carbook.Application.Features.Mediator.Queries.StatistictsQueries;
using Carbook.Application.Features.Mediator.Results.StatistictsResults;
using Carbook.Application.Interfaces.StatistictsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.StatistictsHandlers
{
    public class GetCarBrandAndModelByRentPriceDailyMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMinQuery, GetCarBrandAndModelByRentPriceDailyMinQueryResult>
    {
        private readonly IstatisticRepository _statisticrepository;

        public GetCarBrandAndModelByRentPriceDailyMinQueryHandler(IstatisticRepository statisticrepository)
        {
            _statisticrepository = statisticrepository;
        }

        public async Task<GetCarBrandAndModelByRentPriceDailyMinQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMinQuery request, CancellationToken cancellationToken)
        {
            var GetCarBrandAndModelByRentPriceDailyMin = _statisticrepository.GetCarBrandAndModelByRentPriceDailyMin();
            return new GetCarBrandAndModelByRentPriceDailyMinQueryResult { GetCarBrandAndModelByRentPriceDailyMin = GetCarBrandAndModelByRentPriceDailyMin };
        }
    }
}
