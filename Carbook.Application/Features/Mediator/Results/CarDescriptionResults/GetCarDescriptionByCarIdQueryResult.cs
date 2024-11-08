using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Results.CarDescriptionResults
{
	public class GetCarDescriptionByCarIdQueryResult
	{
		public int CarDescriptionId { get; set; }
		public int CarId { get; set; }
		public string Details { get; set; }
	}
}
