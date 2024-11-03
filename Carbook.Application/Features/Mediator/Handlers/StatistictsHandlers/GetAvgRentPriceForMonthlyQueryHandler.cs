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
    public class GetAvgRentPriceForMonthlyQueryHandler : IRequestHandler<GetAvgRentPriceForMonthlyQuery, GetAvgRentPriceForMonthlyQueryResult>
    {
        private readonly IstatisticRepository _statisticrepository;

        public GetAvgRentPriceForMonthlyQueryHandler(IstatisticRepository statisticrepository)
        {
            _statisticrepository = statisticrepository;
        }

        public async Task<GetAvgRentPriceForMonthlyQueryResult> Handle(GetAvgRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
        {
            var GetAvgRentPriceForMonthly = _statisticrepository.GetAvgRentPriceForMonthly();
            return new GetAvgRentPriceForMonthlyQueryResult
            {
                avgRentPriceForMonthly = GetAvgRentPriceForMonthly
            };
        }
    }
}
