using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Domain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessId { get; set; }
        public int CarId {  get; set; }
        public Car Car {  get; set; }
        public int PickUpLocation {  get; set; }
        public int DropOffLocation {  get; set; }
        public DateOnly PickUpDate {  get; set; }
        public TimeOnly PickUpTime {  get; set; }
        public DateOnly DropOffDate {  get; set; }
        public TimeOnly DropOffTime {  get; set; }
        public int CustomerId {  get; set; }
        public Customer Customer {  get; set; }
        public string PickUpDescription {  get; set; }
        public string DropOffDescription {  get; set; }
        public decimal TotalPrice {  get; set; }
    }
}
