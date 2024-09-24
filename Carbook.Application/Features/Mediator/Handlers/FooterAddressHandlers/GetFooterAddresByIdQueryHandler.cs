using Carbook.Application.Features.Mediator.Queries.FooterAddressQueries;
using Carbook.Application.Features.Mediator.Results.FeatureResults;
using Carbook.Application.Features.Mediator.Results.FooterAddressResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddresByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery,GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddresByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressId = value.FooterAddressId,
                Address = value.Address,
                Description = value.Description,
                Email = value.Email,
                Phone = value.Phone
            }; 
        }

       
    }
}
