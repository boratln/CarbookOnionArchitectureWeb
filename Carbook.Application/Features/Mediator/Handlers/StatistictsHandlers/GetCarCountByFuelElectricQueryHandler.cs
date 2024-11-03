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
    public class GetCarCountByFuelElectricQueryHandler : IRequestHandler<GetCarCountByFuelElectricQuery, GetCarCountByFuelElectricQueryResult>
    {
        private readonly IstatisticRepository _statisticrepository;

        public GetCarCountByFuelElectricQueryHandler(IstatisticRepository statisticrepository)
        {
            _statisticrepository = statisticrepository;
        }

        public async Task<GetCarCountByFuelElectricQueryResult> Handle(GetCarCountByFuelElectricQuery request, CancellationToken cancellationToken)
        {
            var GetCarCountByFuelElectric = _statisticrepository.GetCarCountByFuelElectric();
            return new GetCarCountByFuelElectricQueryResult { GetCarCountByFuelElectric = GetCarCountByFuelElectric };
        }
    }
}
