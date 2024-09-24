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
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBannerCommand command)
        {
            await _repository.Create(new Banner
            {
                Description = command.Description,
                Title = command.Title,
                VideoUrl = command.VideoUrl,
                VideoDescription = command.VideoDescription
            });
        }
    }
}
