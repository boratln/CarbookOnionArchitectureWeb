using Carbook.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{LocationId}/{Avaliable}")]
         public async Task<IActionResult> GetRentACarListByLocation(int LocationId,bool Avaliable)
        {
            GetRentACarQuery query=new GetRentACarQuery();
            query.LocationId = LocationId;
            query.Avaliable = Avaliable;
            var values = await _mediator.Send(query);
            return Ok(values);
        }
    }
}
