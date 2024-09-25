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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.BlogId);
            value.CategoryId = request.CategoryId;
            value.AuthorId = request.AuthorId;
            value.CoverImageUrl = request.CoverImageUrl;
            value.Title = request.Title;
            value.CreatedDate = request.CreatedDate;

            await _repository.Update(value);
        }
    }
}
