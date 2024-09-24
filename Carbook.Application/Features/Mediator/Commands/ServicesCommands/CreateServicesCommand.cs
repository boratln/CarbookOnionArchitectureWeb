using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Commands.ServicesCommands
{
    public class CreateServicesCommand:IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
