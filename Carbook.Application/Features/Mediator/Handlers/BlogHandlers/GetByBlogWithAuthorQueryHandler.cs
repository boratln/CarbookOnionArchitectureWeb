using Carbook.Application.Features.Mediator.Queries.BlogQueries;
using Carbook.Application.Features.Mediator.Results.BlogResults;
using Carbook.Application.Interfaces.BlogInterFaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetByBlogWithAuthorQueryHandler : IRequestHandler<GetByBlogWithAuthorQuery, GetByBlogWithAuthorQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetByBlogWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetByBlogWithAuthorQueryResult> Handle(GetByBlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetByBlogWithAuthor(request.Id);
            if (value != null)
            {
                return new GetByBlogWithAuthorQueryResult
                {
                    BlogId = request.Id,
                    AuthorId = value.AuthorId,
                    AuthorName = value.Author.Name,
                    AuthorUrl = value.Author.ImageUrl
                };
            }
            return new GetByBlogWithAuthorQueryResult();
        }
    }
}
