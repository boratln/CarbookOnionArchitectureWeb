using Carbook.Application.Features.CQRS.Commands.CategoryCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandle
    {
        private readonly IRepository<Category> _repository;
        public UpdateCategoryCommandHandle(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _repository.GetById(command.CategoryId);
            value.Name= command.Name;
            await _repository.Update(value);
        }
    }
}
