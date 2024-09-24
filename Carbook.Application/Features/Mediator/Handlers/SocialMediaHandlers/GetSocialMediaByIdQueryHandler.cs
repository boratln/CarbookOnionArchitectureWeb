using Carbook.Application.Features.Mediator.Queries.SocialMediaQueries;
using Carbook.Application.Features.Mediator.Results.ServicesResults;
using Carbook.Application.Features.Mediator.Results.SocialMediaResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
           Icon = value.Icon,
           Name = value.Name,
           SocialMediaId = value.SocialMediaId,
           Url = value.Url  
            };
        }
    }
}
