using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TravelDetails
    {
        //field
        private static int s_travelID=100;
        //property
        public string TravelID { get; }
        public string CardNumber { get;  }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime Date { get; set; }
        public double TravelCost { get; set; }

        //parameterized constructor
        public TravelDetails(string cardNumber,string fromLocation,string toLocation,DateTime date,double travelCost)
        {
            s_travelID++;
            TravelID="TID"+s_travelID;
            CardNumber=cardNumber;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            Date=date;
            TravelCost=travelCost;
        }
    }
}