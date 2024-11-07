using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeatureByCarId(int carId);
        void ChangeCarFeatureAvaliableToFalse(int id);
        void ChangeCarFeatureAvaliableToTrue(int id);
        void CreateCarFeatureByCar(CarFeature CarFeature);
    }
}
