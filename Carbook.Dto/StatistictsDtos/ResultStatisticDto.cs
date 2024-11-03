﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Carbook.Dto.StatistictsDtos
{
    public class ResultStatisticDto
    {
        public int CarCount {  get; set; }
        public int AuthorCount {  get; set; }
        public int BlogCount {  get; set; }
        public int BrandCount {  get; set; }
        public int LocationCount {  get; set; }
        public int CarCountByKmSmallerThan1000 {  get; set; }
        public int CarCountByFuelGasolineOrDiesel{  get; set; }
        public int CarCountByTranmissionIsAuto {  get; set; }
        public int CarCountByFuelElectric{  get; set; }
        public string CarBrandAndModelByRentPriceDailyMin {  get; set; }
        public string CarBrandAndModelByRentPriceDailyMax {  get; set; }
        public string BrandNameByMaxCar {  get; set; }
        public string BlogTitleByMaxBlogComment {  get; set; }
        public decimal AvgRentPriceForWeekly {  get; set; }
        public decimal AvgRentPriceForMonthly {  get; set; }
        public decimal AvgRentPriceForDaily {  get; set; }
    }
}