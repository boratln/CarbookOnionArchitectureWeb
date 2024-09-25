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
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public RemoveBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            await _repository.Remove(value);
        }
    }
}
