using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Shared.PaximumModels
{
    public class PriceSearchRequest
    {

        public bool checkAllotment { get; set; } = true;
        public bool checkStopSale { get; set; } = true;
        public bool getOnlyDiscountedPrice { get; set; } = false;
        public bool getOnlyBestOffers { get; set; } = true;
        public int productType { get; set; } = 2;
        public List<ArrivalLocation> arrivalLocations { get; set; }
        public List<RoomCriterion> roomCriteria { get; set; }
        public string nationality { get; set; } = "DE";
        public string checkIn { get; set; } = "2023-05-20";
        public int night { get; set; } = 1;
        public string currency { get; set; } = "EUR";
        public string culture { get; set; } = "en-US";


        public class ArrivalLocation
        {
            public string id { get; set; } = "23494";
            public int type { get; set; } = 2;
        }

        public class RoomCriterion
        {
            public int adult { get; set; } = 2;
            public List<int> childAges { get; set; } 
        }

      


    }
}
