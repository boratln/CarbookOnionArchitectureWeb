using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Dto.CarFeatureDtos
{
    public class CarFeatureByCarIdDto
    {
        public int CarFeatureId { get; set; }
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
