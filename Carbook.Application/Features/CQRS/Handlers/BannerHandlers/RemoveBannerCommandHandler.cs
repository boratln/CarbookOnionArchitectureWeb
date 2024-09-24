using Carbook.Application.Features.CQRS.Commands.BannerCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {

            _repository = repository;
        }
        public async Task Handle(RemoveBannerCommand command)
        {
            var value = await _repository.GetById(command.Id);
            await _repository.Remove(value);
        }

    }

}
