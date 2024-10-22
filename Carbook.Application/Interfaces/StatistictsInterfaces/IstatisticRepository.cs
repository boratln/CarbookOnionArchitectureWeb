using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Interfaces.StatistictsInterfaces
{
    public interface IstatisticRepository
    {
         int GetCarCount();
         int GetAuthorCount();
         int GetBlogCount();
         int GetBrandCount();
        double GetAvgRentPriceForDaily();
        double GetAvgRentPriceForWeekly();
        double GetAvgRentPriceForMonthly();
        int GetCarCountByTransmissionIsAuto();
        string BrandNameByMaxCar();
        string BlogTitleByMaxBlogComment();
        int GetCarCountByKmSmallerThan1000();
        int GetCarCountByFuelGasolineOrDiesel();
        int GetCarCountByFuelElectric();
        string GetCarBrandAndModelByRentPriceDailyMax();
        string GetCarBrandAndModelByRentPriceDailyMin();
    }
}
