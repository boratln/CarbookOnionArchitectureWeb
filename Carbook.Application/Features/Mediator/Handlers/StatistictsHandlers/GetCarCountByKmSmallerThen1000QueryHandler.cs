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
    public class GetCarCountByKmSmallerThen1000QueryHandler : IRequestHandler<GetCarCountByKmSmallerThen1000Query, GetCarCountByKmSmallerThen1000QueryResult>
    {
        private readonly IstatisticRepository _statisticrepository;

        public GetCarCountByKmSmallerThen1000QueryHandler(IstatisticRepository statisticrepository)
        {
            _statisticrepository = statisticrepository;
        }

        public async Task<GetCarCountByKmSmallerThen1000QueryResult> Handle(GetCarCountByKmSmallerThen1000Query request, CancellationToken cancellationToken)
        {
            var GetCarCountByKmSmallerThen1000 = _statisticrepository.GetCarCountByKmSmallerThen1000();
            return new GetCarCountByKmSmallerThen1000QueryResult { GetCarCountByKmSmallerThen1000 = GetCarCountByKmSmallerThen1000 };
        }
    }
}
