using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class OrderDetails
    {
        //field
        private static int s_orderID=4000;
        //property
        public string OrderID { get;  }
        public string BookingID { get; }
        public string ProductID { get; }
        public int PurchaseCount { get; set; }
        public double PriceOfOrder { get; set; }

        //parameterized Constructor
        public OrderDetails(string bookingID,string productID,int purchaseCount,double priceOfOrder)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            BookingID=bookingID;
            ProductID=productID;
            PurchaseCount=purchaseCount;
            PriceOfOrder=priceOfOrder;
        }
    }
}