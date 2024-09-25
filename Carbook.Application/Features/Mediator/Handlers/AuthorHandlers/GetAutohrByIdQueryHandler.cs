using Carbook.Application.Features.Mediator.Queries.AuthorQueries;
using Carbook.Application.Features.Mediator.Results.AuthorResults;
using Carbook.Application.Features.Mediator.Results.FeatureResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAutohrByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAutohrByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            return new GetAuthorByIdQueryResult
            {
                AuthorId = request.Id,
                Description=value.Description,
                ImageUrl=value.ImageUrl,            
                Name = value.Name
            };
        }
    }
}
