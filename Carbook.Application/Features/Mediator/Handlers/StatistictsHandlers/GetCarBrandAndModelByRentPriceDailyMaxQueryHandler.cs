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
    public class GetCarBrandAndModelByRentPriceDailyMaxQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDailyMaxQuery, GetCarBrandAndModelByRentPriceDailyMaxQueryResult>
    {
        private readonly IstatisticRepository _statisticrepository;

        public GetCarBrandAndModelByRentPriceDailyMaxQueryHandler(IstatisticRepository statisticrepository)
        {
            _statisticrepository = statisticrepository;
        }

        public async Task<GetCarBrandAndModelByRentPriceDailyMaxQueryResult> Handle(GetCarBrandAndModelByRentPriceDailyMaxQuery request, CancellationToken cancellationToken)
        {
            var GetCarBrandAndModelByRentPriceDailyMax = _statisticrepository.GetCarBrandAndModelByRentPriceDailyMax();
            return new GetCarBrandAndModelByRentPriceDailyMaxQueryResult
            {
                GetCarBrandAndModelByRentPriceDailyMax = GetCarBrandAndModelByRentPriceDailyMax
            };
        }
    }
}
