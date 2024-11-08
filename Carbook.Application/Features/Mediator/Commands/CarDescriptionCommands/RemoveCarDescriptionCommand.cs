using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Commands.CarDescriptionCommands
{
	public class RemoveCarDescriptionCommand:IRequest
	{
		public int Id {  get; set; }

		public RemoveCarDescriptionCommand(int ıd)
		{
			Id = ıd;
		}
	}
}
