using Carbook.Application.Features.CQRS.Results.ContactResults;
using Carbook.Application.Features.Mediator.Queries.FeatureQueries;
using Carbook.Application.Features.Mediator.Results.FeatureResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetById(request.Id);
            return new GetFeatureByIdQueryResult
            {
                FeatureId = value.FeatureId,
          
                Name = value.Name
            };
        }
    }
}
