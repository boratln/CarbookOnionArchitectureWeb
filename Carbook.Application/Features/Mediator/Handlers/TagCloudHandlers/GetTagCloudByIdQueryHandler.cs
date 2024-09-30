using Carbook.Application.Features.Mediator.Queries.SocialMediaQueries;
using Carbook.Application.Features.Mediator.Queries.TagCloudQueries;
using Carbook.Application.Features.Mediator.Results.SocialMediaResults;
using Carbook.Application.Features.Mediator.Results.TagCloudResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            return new GetTagCloudByIdQueryResult
            {
               Title = value.Title,
               TagCloudId = value.TagCloudId,
               BlogId=value.BlogId
            };
        }
    }
    
}
