using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class CarServicesRecommenderModel
    {

        public List<Data.Model.CarService> listToRecommend { get; set; }

        public List<Data.Model.CarService> others { get; set; }
    }
}
