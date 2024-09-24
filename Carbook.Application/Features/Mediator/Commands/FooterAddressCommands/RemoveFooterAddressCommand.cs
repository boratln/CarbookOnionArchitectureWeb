using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class RemoveFooterAddressCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveFooterAddressCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
