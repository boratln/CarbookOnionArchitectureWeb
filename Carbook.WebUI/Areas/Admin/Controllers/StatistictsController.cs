using Carbook.Dto.StatistictsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Carbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatisticts")]
    public class AdminStatistictsController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatistictsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var model = new ResultStatisticDto();
            #region CarCount
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7076/api/Statisticts/GetCarCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var data = await responseMessage1.Content.ReadAsStringAsync();
               var jsonData= JsonConvert.DeserializeObject<ResultStatisticDto>(data);
                model.CarCount = jsonData.CarCount;
            }
            #endregion
            #region AuthorCount
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7076/api/Statisticts/GetAuthorCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var data=await responseMessage2.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.AuthorCount = jsonData.AuthorCount;
            }

            #endregion
            #region BlogCount
            var client3=_httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7076/api/Statisticts/GetBlogCount");
            if (responseMessage3.IsSuccessStatusCode) {
                var data=await responseMessage3.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.BlogCount = jsonData.BlogCount;
            }
            #endregion
            #region BrandCount
            var client4=_httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:7076/api/Statisticts/GetBrandCount");
            if (responseMessage4.IsSuccessStatusCode) {
            var data=await responseMessage4.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.BrandCount = jsonData.BrandCount;
            }
            #endregion
            #region LocationCount
            var client5= _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync("https://localhost:7076/api/Statisticts/GetLocationCount");
            if (responseMessage5.IsSuccessStatusCode) {
            var data=await responseMessage5.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.LocationCount = jsonData.LocationCount;
            }
            #endregion
            #region AvgRentPriceForDaily
            var client6=_httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync("https://localhost:7076/api/Statisticts/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var data = await responseMessage6.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);


                ViewBag.avgRentPriceForDaily = jsonData.AvgRentPriceForDaily.ToString("0.00"); 


            }
            #endregion
            #region AvgRentPriceForWeekly
            var client7= _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync("https://localhost:7076/api/Statisticts/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var data = await responseMessage7.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.AvgRentPriceForWeekly = jsonData.AvgRentPriceForWeekly;
            }
            #endregion
            #region AvgRentPriceForMonthly
            var client8=_httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync("https://localhost:7076/api/Statisticts/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var data=await responseMessage8.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.AvgRentPriceForMonthly = jsonData.AvgRentPriceForMonthly;
            }
            #endregion
            #region BlogTitleByMaxBlogComment
            var client9= _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync("https://localhost:7076/api/Statisticts/GetBlogTitleByMaxBlogComment");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var data=await responseMessage9.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.BlogTitleByMaxBlogComment = jsonData.BlogTitleByMaxBlogComment;
            }
            #endregion
            #region BrandNameByMaxCar
            var client10= _httpClientFactory.CreateClient();
            var responseMessage10 = await client.GetAsync("https://localhost:7076/api/Statisticts/GetBrandNameByMaxCar");
            if (responseMessage10.IsSuccessStatusCode) {
            var data=await responseMessage10.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.BrandNameByMaxCar = jsonData.BrandNameByMaxCar;
            }
            #endregion
            #region CarBrandAndModelByRentPriceDailyMax
            var client11= _httpClientFactory.CreateClient();
            var responseMessage11 = await client11.GetAsync("https://localhost:7076/api/Statisticts/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage11.IsSuccessStatusCode) {
                var data =await responseMessage11.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.CarBrandAndModelByRentPriceDailyMax = jsonData.CarBrandAndModelByRentPriceDailyMax;
            }
            #endregion
            #region CarBrandAndModelByRentPriceDailyMin
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client11.GetAsync("https://localhost:7076/api/Statisticts/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage12.IsSuccessStatusCode)
            {
                var data =await responseMessage12.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.CarBrandAndModelByRentPriceDailyMin = jsonData.CarBrandAndModelByRentPriceDailyMin;
            }
            #endregion
            #region CarCountByFuelElectric
            var client13= _httpClientFactory.CreateClient();
            var responseMessage13 = await client13.GetAsync("https://localhost:7076/api/Statisticts/GetCarCountByFuelElectric");
            if (responseMessage13.IsSuccessStatusCode) { 
            var data=await responseMessage13.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.CarCountByFuelElectric = jsonData.CarCountByFuelElectric;
            }
            #endregion
            #region CarCountByFuelGasolineOrDiesel
            var client14= _httpClientFactory.CreateClient();
            var responseMessage14 = await client14.GetAsync("https://localhost:7076/api/Statisticts/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage14.IsSuccessStatusCode) {
            var data=await responseMessage14.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.CarCountByFuelGasolineOrDiesel=jsonData.CarCountByFuelGasolineOrDiesel;
            }
            #endregion
            #region CarCountByKmSmallerThen1000
            var client15= _httpClientFactory.CreateClient();
            var responseMessage15 = await client15.GetAsync("https://localhost:7076/api/Statisticts/GetCarCountByKmSmallerThen1000");
            if (responseMessage15.IsSuccessStatusCode)
            {
                var data=await responseMessage15.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.CarCountByKmSmallerThan1000 = jsonData.CarCountByKmSmallerThan1000;
            }
            #endregion
            #region CarCountByTranmissionIsAuto
            var client16= _httpClientFactory.CreateClient();
            var responseMessage16 = await client16.GetAsync("https://localhost:7076/api/Statisticts/GetCarCountByTranmissionIsAuto");
            if (responseMessage16.IsSuccessStatusCode)
            {
                var data= await responseMessage16.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ResultStatisticDto>(data);

                model.CarCountByTranmissionIsAuto = jsonData.CarCountByTranmissionIsAuto;
            }
            #endregion
            return View(model);
        }
    }
}
