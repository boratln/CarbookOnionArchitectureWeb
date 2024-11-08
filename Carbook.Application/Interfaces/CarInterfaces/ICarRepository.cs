using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
       Task <List<Car>> GetCarsListWithBrand();
        Task<List<Car>> GetLast5CarsWithBrand();
        Task<Car> GetCarWithBrandByCarId(int CarId);
    }
}
