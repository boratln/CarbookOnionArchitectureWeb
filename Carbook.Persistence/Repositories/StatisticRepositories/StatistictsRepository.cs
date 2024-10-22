using Carbook.Application.Interfaces.StatistictsInterfaces;
using Carbook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Persistence.Repositories.StatisticRepositories
{
    public class StatistictsRepository : IstatisticRepository
    {
        private readonly CarbookContext _carbookContext;

        public StatistictsRepository(CarbookContext carbookContext)
        {
            _carbookContext = carbookContext;
        }

        public string BlogTitleByMaxBlogComment()
        {
            var title = _carbookContext.Blogs.MaxBy(x => x.Comments.Count).Title;
            return title;
        }

        public string BrandNameByMaxCar()
        {
            var brandName = _carbookContext.Brands.MaxBy(x => x.Cars.Count).Name;
            return brandName;
        }

        public int GetAuthorCount()
        {
            var count = _carbookContext.Authors.Count();
            return count;
        }

        public double GetAvgRentPriceForDaily()
        {
            var AverageRentPriceDaily = (double) _carbookContext.CarPricings.Where(x => x.PricingId == 3).Average(x => x.Price);
            return AverageRentPriceDaily;
        }

        public double GetAvgRentPriceForMonthly()
        {
           var AverageRentPriceMonthly=(double) _carbookContext.CarPricings.Where(x=>x.PricingId==4).Average(x => x.Price);
            return AverageRentPriceMonthly;
        }

        public double GetAvgRentPriceForWeekly()
        {
            var AverageRentPriceWeekly = (double)_carbookContext.CarPricings.Where(x => x.PricingId == 5).Average(x => x.Price);
            return AverageRentPriceWeekly;
                }

        public int GetBlogCount()
        {
            var count=_carbookContext.Blogs.Count();
            return count;
        }

        public int GetBrandCount()
        {
           var count=_carbookContext.Brands.Count();
            return count;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            int PricingId = _carbookContext.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefault();
            decimal price =  _carbookContext.CarPricings.Where(x => x.PricingId == PricingId).Select(x => x.Price).Max();
            int CarId = _carbookContext.CarPricings.Where(x=>x.Price==price).Select(x=> x.CarId).FirstOrDefault();
            string brandModel = _carbookContext.Cars.Where(x => x.CarId == CarId).Include(x => x.Brand).Select(x => x.Brand.Name + " " + x.CarModel).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int PricingId = _carbookContext.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefault();
            decimal price = _carbookContext.CarPricings.Where(x => x.PricingId == PricingId).Select(x => x.Price).Min();
            int CarId = _carbookContext.CarPricings.Where(x => x.Price == price).Select(x => x.CarId).FirstOrDefault();
            string brandModel=_carbookContext.Cars.Where(x=>x.CarId==CarId).Include(x=>x.Brand).Select(x=>x.Brand.Name+" "+x.CarModel).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
            var count = _carbookContext.Cars.Count();
            return count;
        }

        public int GetCarCountByFuelElectric()
        {
            var count = _carbookContext.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return count;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var count = _carbookContext.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return count;
        }

        public int GetCarCountByKmSmallerThan1000()
        {
            var count = _carbookContext.Cars.Where(x => x.Kilometer <= 1000).Count();
            return count;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
           var count=_carbookContext.Cars.Where(x=>x.Transmission=="Otomatik").Count();
            return count;
        }
    }
}
