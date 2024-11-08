using Carbook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using Carbook.Application.Features.Mediator.Results.CarDescriptionResults;
using Carbook.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
	{
		private readonly ICarDescriptionRepository _carDescriptionRepository;

		public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository carDescriptionRepository)
		{
			_carDescriptionRepository = carDescriptionRepository;
		}

		public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _carDescriptionRepository.GetCarDescriptionByCarId(request.Id);
			return new GetCarDescriptionByCarIdQueryResult
			{
				CarDescriptionId = value.CarDescriptionId,
				CarId = value.CarId,
				Details = value.Details
			};
				
				
		}
	}
}
