using Carbook.Application.Features.Mediator.Queries.PricingQueries;
using Carbook.Application.Features.Mediator.Results.LocationResults;
using Carbook.Application.Features.Mediator.Results.PricingResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAll();
            return values.Select(x => new GetPricingQueryResult
            {
                PricingId=x.PricingId,
               Name = x.Name,
            }).ToList();
        }
    }
}
