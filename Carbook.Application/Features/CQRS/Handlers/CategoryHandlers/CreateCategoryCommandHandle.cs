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
    public class CreateCategoryCommandHandle
    {
        private readonly IRepository<Category> _repository;
        public CreateCategoryCommandHandle(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCategoryCommand command)
        {
            await _repository.Create(new Category
            {
               Name = command.Name,
            });
        }
    }
}
