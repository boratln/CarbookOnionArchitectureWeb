using Carbook.Application.Features.Mediator.Queries.BlogQueries;
using Carbook.Application.Features.Mediator.Results.AuthorResults;
using Carbook.Application.Features.Mediator.Results.BlogResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAll();
            return values.Select(x => new GetBlogQueryResult
            {
               AuthorId = x.AuthorId,
               BlogId = x.BlogId,
               CategoryId = x.CategoryId,
               CoverImageUrl = x.CoverImageUrl,
               CreatedDate = x.CreatedDate,
               Title = x.Title
            }).ToList();
        }
    }
}
