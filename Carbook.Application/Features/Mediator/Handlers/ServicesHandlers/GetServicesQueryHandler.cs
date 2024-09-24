using Carbook.Application.Features.Mediator.Queries.ServicesQueries;
using Carbook.Application.Features.Mediator.Results.PricingResults;
using Carbook.Application.Features.Mediator.Results.ServicesResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.ServicesHandlers
{
    public class GetServicesQueryHandler : IRequestHandler<GetServicesQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Carbook.Domain.Entities.Services> _repository;

        public GetServicesQueryHandler(IRepository<Carbook.Domain.Entities.Services> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAll();
            return values.Select(x => new GetServiceQueryResult
            {
                Title = x.Title,
                Description = x.Description,
                IconUrl = x.IconUrl,
                ServicesId = x.ServicesId
            }).ToList();
        }
    }
}
