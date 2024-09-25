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
    public class GetBlogByIdQueryHandlerr : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandlerr(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            return new GetBlogByIdQueryResult
            {
               Title = value.Title,
               CreatedDate = value.CreatedDate,
               AuthorId = value.AuthorId,
               BlogId = value.BlogId,
               CategoryId = value.CategoryId,
               CoverImageUrl = value.CoverImageUrl
            };
        }
    }
}
