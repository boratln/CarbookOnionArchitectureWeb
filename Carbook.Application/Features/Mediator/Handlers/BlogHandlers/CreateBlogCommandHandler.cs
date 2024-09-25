using Carbook.Application.Features.Mediator.Commands.BlogCommands;
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
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.Create(new Blog
            {
              CoverImageUrl = request.CoverImageUrl,
              CategoryId = request.CategoryId,
              CreatedDate = request.CreatedDate,
              Title = request.Title,
              AuthorId = request.AuthorId,
              
            });
        }
    }
}
