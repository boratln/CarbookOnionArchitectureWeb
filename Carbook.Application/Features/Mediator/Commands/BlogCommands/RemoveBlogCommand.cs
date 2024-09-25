using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Commands.BlogCommands
{
    public class RemoveBlogCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveBlogCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
