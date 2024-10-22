using Carbook.Application.Features.Mediator.Queries.StatistictsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatistictsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatistictsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var count = await _mediator.Send(new GetCarCountQuery());
            return Ok(count);
        }
    }
}
