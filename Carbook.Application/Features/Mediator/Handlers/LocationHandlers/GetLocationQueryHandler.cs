using Carbook.Application.Features.Mediator.Queries.LocationQueries;
using Carbook.Application.Features.Mediator.Results.FeatureResults;
using Carbook.Application.Features.Mediator.Results.LocationResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAll();
            return values.Select(x => new GetLocationQueryResult
            {
               LocationId = x.LocationId,
               Name=x.Name
            }).ToList();
        }
    }
}
