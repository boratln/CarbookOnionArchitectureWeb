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
    public class GetCarCountByTranmissionIsAutoQueryHandler : IRequestHandler<GetCarCountByTranmissionIsAutoQuery, GetCarCountByTranmissionIsAutoQueryResult>
    {
        private readonly IstatisticRepository _statisticrepository;

        public GetCarCountByTranmissionIsAutoQueryHandler(IstatisticRepository statisticrepository)
        {
            _statisticrepository = statisticrepository;
        }

        public async Task<GetCarCountByTranmissionIsAutoQueryResult> Handle(GetCarCountByTranmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var GetCarCountByTranmissionIsAuto = _statisticrepository.GetCarCountByTranmissionIsAuto();
            return new GetCarCountByTranmissionIsAutoQueryResult { GetCarCountByTranmissionIsAuto = GetCarCountByTranmissionIsAuto };
        }
    }
}
