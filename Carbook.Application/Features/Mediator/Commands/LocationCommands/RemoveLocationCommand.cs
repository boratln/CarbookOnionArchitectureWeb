using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Commands.LocationCommands
{
    public class RemoveLocationCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveLocationCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
