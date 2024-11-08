using Carbook.Application.Features.CQRS.Commands.CarCommands;
using Carbook.Application.Features.CQRS.Handlers.CarHandlers;
using Carbook.Application.Features.CQRS.Queries.CarQueries;
using Carbook.Application.Features.Mediator.Queries.StatistictsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLast5CarWithBrandQueryHandler? _getLast5CarWithBrandQueryHandler;
        private readonly GetCarWithBrandByCarIdQueryHandler getCarWithBrandByCarIdQueryHandler;
		private readonly IMediator _mediator;



		public CarsController(CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler,
			GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, RemoveCarCommandHandler removeCarCommandHandler,
			GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarWithBrandQueryHandler getLast5CarWithBrandQueryHandler
, IMediator mediator, GetCarWithBrandByCarIdQueryHandler getCarWithBrandByCarIdQueryHandler)
		{
			_createCarCommandHandler = createCarCommandHandler;
			_updateCarCommandHandler = updateCarCommandHandler;
			_removeCarCommandHandler = removeCarCommandHandler;
			_getCarByIdQueryHandler = getCarByIdQueryHandler;
			_getCarQueryHandler = getCarQueryHandler;
			_getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
			_getLast5CarWithBrandQueryHandler = getLast5CarWithBrandQueryHandler;
			_mediator = mediator;
			this.getCarWithBrandByCarIdQueryHandler = getCarWithBrandByCarIdQueryHandler;
		}

		[HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("GetLast5Cars")]
        public async Task<IActionResult> GetLast5Cars()
        {
            var values = await _getLast5CarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("GetByBrand")]
        public async Task<IActionResult> GetByBrand()
        {
            var values = await _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Araç başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Araç başarıyla güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araç başarıyla silindi");
        }
        [HttpGet("GetCarWithBrand/{id}")]
        public async Task<IActionResult> GetCarWithBrand(int id)
        {
            var value = await getCarWithBrandByCarIdQueryHandler.Handle(new GetCarWithBrandByCarIdQuery(id));
            return Ok(value);

		}




	}
}
