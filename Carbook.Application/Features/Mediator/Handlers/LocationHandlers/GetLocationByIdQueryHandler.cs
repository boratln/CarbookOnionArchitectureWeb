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
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            return new GetLocationByIdQueryResult
            {
               LocationId= value.LocationId,

                Name = value.Name
            };
        }
    }
}
