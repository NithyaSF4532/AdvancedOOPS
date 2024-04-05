using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TicketFairDetails
    {
        //field
        private static int s_ticketID=100;
        //property
        public string TicketID { get;  }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public double TicketPrice { get; set; }

        //parameterized constructor
        public TicketFairDetails(string fromLocation,string toLocation,double ticketPrice)
        {
            s_ticketID++;
            TicketID="MR"+s_ticketID;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            TicketPrice=ticketPrice;
        }
    }
}