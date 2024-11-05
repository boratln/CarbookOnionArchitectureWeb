using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Domain.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string CoverImageUrl {  get; set; }
        public int Kilometer {  get; set; }
        public string Transmission {  get; set; }
        public byte Seat { get; set; }
        public byte Luggage {  get; set; }
        public string Fuel {  get; set; }
        public string BigImageUrl {  get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricing { get; set; }
        public List<RentACar> RentACars { get; set; }
        public List<RentACarProcess> RentACarProcesses { get; set; }
        public List<Reservation> Reservations { get; set; }


    }
}
