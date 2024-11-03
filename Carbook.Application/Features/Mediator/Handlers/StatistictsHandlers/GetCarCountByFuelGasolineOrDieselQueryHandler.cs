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
    public class GetCarCountByFuelGasolineOrDieselQueryHandler : IRequestHandler<GetCarCountByFuelGasolineOrDieselQuery, GetCarCountByFuelGasolineOrDieselQueryResult>
    {
        private readonly IstatisticRepository _statisticrepository;

        public GetCarCountByFuelGasolineOrDieselQueryHandler(IstatisticRepository statisticrepository)
        {
            _statisticrepository = statisticrepository;
        }

        public async Task<GetCarCountByFuelGasolineOrDieselQueryResult> Handle(GetCarCountByFuelGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var GetCarCountByFuelGasolineOrDiesel = _statisticrepository.GetCarCountByFuelGasolineOrDiesel();
            return new GetCarCountByFuelGasolineOrDieselQueryResult { GetCarCountByFuelGasolineOrDiesel = GetCarCountByFuelGasolineOrDiesel };
        }
    }
}
