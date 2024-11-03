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
        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var count = await _mediator.Send(new GetLocationCountQuery());
            return Ok(count);
        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var count = await _mediator.Send(new GetBrandCountQuery());
            return Ok(count);
        }
        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var count = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(count);
        }
        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var count = await _mediator.Send(new GetBlogCountQuery());
            return Ok(count);
        }
        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var avgRentPriceForDaily = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(avgRentPriceForDaily);
        }
        [HttpGet("GetAvgRentPriceForMonthly")]
        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var avgrentprice = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(avgrentprice);
        }
        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var avgrentprice = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(avgrentprice);
        }
        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var blogName = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(blogName);
        }
        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var GetBrandNameByMaxCar = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(GetBrandNameByMaxCar);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var GetCarBrandAndModelByRentPriceDailyMax = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(GetCarBrandAndModelByRentPriceDailyMax);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var GetCarBrandAndModelByRentPriceDailyMin = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(GetCarBrandAndModelByRentPriceDailyMin);
        }
        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var GetCarCountByFuelElectric = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(GetCarCountByFuelElectric);
        }
        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var GetCarCountByFuelElectric = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(GetCarCountByFuelElectric);
        }
        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThen1000()
        {
            var GetCarCountByKmSmallerThen1000 = await _mediator.Send(new GetCarCountByKmSmallerThen1000Query());
            return Ok(GetCarCountByKmSmallerThen1000);
        }
        [HttpGet("GetCarCountByTranmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTranmissionIsAuto()
        {
            var GetCarCountByKmSmallerThen1000 = await _mediator.Send(new GetCarCountByTranmissionIsAutoQuery());
            return Ok(GetCarCountByKmSmallerThen1000);
        }
        
    }
}
