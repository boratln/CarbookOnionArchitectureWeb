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
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public UpdateBannerCommandHandler(IRepository<Banner> repository) {
        _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var value=await _repository.GetById(command.BannerId);
            value.Description=command.Description;
            value.Title=command.Title;
            value.VideoUrl=command.VideoUrl;
            value.VideoDescription = command.VideoDescription;
            await _repository.Update(value);
        }
    }
}
