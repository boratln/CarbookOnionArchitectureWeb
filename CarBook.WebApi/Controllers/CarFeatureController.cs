using Carbook.Application.Features.Mediator.Commands.CarFeatureCommands;
using Carbook.Application.Features.Mediator.Handlers.CarFeatureHandlers;
using Carbook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarFeatureController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetCarFeatureByCarId/{id}")]
        public async Task<IActionResult> GetCarFeatureByCarId(int id)
        {
            var values =await  mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }
        [HttpGet("CarFeatureChangeAvaliableToFalse/{id}")]
        public IActionResult CarFeatureChangeAvaliableToFalse(int id)
        {
            mediator.Send(new UpdateCarFeatureAvaliableChangeToFalseCommand(id));
            return Ok("Araba özelliği devre dışı bırakıldı");
        }
        [HttpGet("CarFeatureChangeAvaliableToTrue/{id}")]
        public IActionResult CarFeatureChangeAvaliableToTrue(int id)
        {
            mediator.Send(new UpdateCarFeatureAvaliableChangeToTrueCommand(id));
            return Ok("Araba özelliği Aktif Edildi");
        }
        [HttpPost("CreateCarFeature")]
        public IActionResult CreateCarFeature(CreateCarFeatureCommand command)
        {
            mediator.Send(command);
            return Ok("Başarıyla araç özelliği eklendi");
        }
    }
}
