using Carbook.Application.Features.Mediator.Queries.BlogQueries;
using Carbook.Application.Features.Mediator.Results.AuthorResults;
using Carbook.Application.Features.Mediator.Results.BlogResults;
using Carbook.Application.Interfaces;
using Carbook.Application.Interfaces.BlogInterFaces;
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
        private readonly IBlogRepository _repository;

        public GetBlogByIdQueryHandlerr(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value =  _repository.GetByBlog(request.Id);
            if (value != null)
            {
                return new GetBlogByIdQueryResult
                {
                    Title = value.Title,
                    CreatedDate = value.CreatedDate,
                    AuthorId = value.AuthorId,
                    BlogId = value.BlogId,
                    AuthorName = value.Author.Name,
                    CategoryName = value.Category.Name,
                    CategoryId = value.CategoryId,
                    BlogDescription = value.BlogDescription,
                    CoverImageUrl = value.CoverImageUrl
                };
            }

            return new GetBlogByIdQueryResult();

        }
    }
}
