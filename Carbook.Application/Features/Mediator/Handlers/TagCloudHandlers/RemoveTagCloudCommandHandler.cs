using Carbook.Application.Features.Mediator.Commands.TagCloudCommands;
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
    public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public RemoveTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
        {
            TagCloud cloud = await _repository.GetById(request.Id);
            await _repository.Remove(cloud);
        }
    }
}
