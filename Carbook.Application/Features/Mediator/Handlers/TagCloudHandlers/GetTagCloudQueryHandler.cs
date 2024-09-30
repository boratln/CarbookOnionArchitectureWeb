using Carbook.Application.Features.Mediator.Queries.TagCloudQueries;
using Carbook.Application.Features.Mediator.Results.BlogResults;
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
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery,List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAll();
            return values.Select(x => new GetTagCloudQueryResult
            {
               BlogId = x.BlogId,
               TagCloudId = x.TagCloudId,
               Title=x.Title
            }).ToList();
        }
    }
}
