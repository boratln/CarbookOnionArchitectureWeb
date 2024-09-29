using Carbook.Application.Features.Mediator.Queries.BlogQueries;
using Carbook.Application.Features.Mediator.Results.BlogResults;
using Carbook.Application.Interfaces;
using Carbook.Application.Interfaces.BlogInterFaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async  Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName=x.Author.Name,
                BlogId=x.BlogId,
                CategoryId=x.CategoryId,
                CategoryName=x.Category.Name,
                CoverImageUrl=x.CoverImageUrl,
                CreatedDate=x.CreatedDate,
                BlogDescription=x.BlogDescription,
                Title=x.Title

            }).ToList();
        }
    }
}
