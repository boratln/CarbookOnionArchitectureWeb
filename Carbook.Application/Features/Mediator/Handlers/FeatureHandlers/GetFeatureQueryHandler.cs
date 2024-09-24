using Carbook.Application.Features.Mediator.Queries.FeatureQueries;
using Carbook.Application.Features.Mediator.Results.FeatureResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeautreQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeautreQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAll();
            return values.Select(x => new GetFeautreQueryResult
            {
                FeatureId = x.FeatureId,
                Name = x.Name
            }).ToList();
        }
    }
}
