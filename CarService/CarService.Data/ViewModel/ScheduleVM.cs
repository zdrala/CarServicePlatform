using CarService.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.ViewModel
{
    public class ScheduleVM
    {
        public int ScheduleID { get; set; }

        public int RequestID { get; set; }

        public DateTime DateofSchedule { get; set; }

        public string Date { get; set; }
        public int ScheduleStatusID { get; set; } //napraviti referentnu za statuse

        public string Status { get; set; }

        public string isLocked { get; set; }

        public bool isPaid { get; set; }
        public string isPaidString { get; set; }

        public double totalPrice { get; set; }

        public string User { get; set; }
        public string UserCar { get; set; }
        public bool offerCreated { get; set; }
        public List<ItemsSelected> selectedSubCategories { get; set; }


          public class ItemsSelected
          {
            public int subCategoryID { get; set; }
            public string SubCategoryName { get; set; }
            public int QuantityNeeded { get; set; }
          };


        public List<CarPartSubCategory> itemsforSelect { get; set; }
    }
}
