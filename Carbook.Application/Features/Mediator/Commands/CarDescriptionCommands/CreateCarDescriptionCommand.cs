using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Commands.CarDescriptionCommands
{
	public class CreateCarDescriptionCommand:IRequest
	{
		public int CarId { get; set; }
		public string Details { get; set; }
	}
}
