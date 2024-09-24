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
    public class GetServicesByIdQueryHandler : IRequestHandler<GetServicesByIdQuery, GetServicesByIdQueryResult>
    {
        private readonly IRepository<Carbook.Domain.Entities.Services> _repository;

        public GetServicesByIdQueryHandler(IRepository<Domain.Entities.Services> repository)
        {
            _repository = repository;
        }

        public async Task<GetServicesByIdQueryResult> Handle(GetServicesByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            return new GetServicesByIdQueryResult
            {
                Title = value.Title,
                Description = value.Description,
                IconUrl = value.IconUrl,
                ServicesId = value.ServicesId
            };
        }
    }
}
