using Carbook.Application.Features.CQRS.Commands.BrandCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        public RemoveBrandCommandHandler(IRepository<Brand> repository) {
        
        _repository= repository;
        }
        public async Task Handle(RemoveBrandCommand command)
        {
            var value = await _repository.GetById(command.Id);
            await _repository.Remove(value);
        }
    }
}
