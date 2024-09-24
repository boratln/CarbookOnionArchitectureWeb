﻿using Carbook.Application.Features.Mediator.Commands.PricingCommands;
using Carbook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon başarıyla güncellendi");


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Lokasyon başarıyla silindi");
        }
    }
}