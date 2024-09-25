using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Commands.AuthorCommands
{
    public class RemoveAuthorCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveAuthorCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
