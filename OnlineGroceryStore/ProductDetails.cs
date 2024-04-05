using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    public class ProductDetails
    {
        //field
        private static int s_productID=2000;
        //property
        public string ProductID { get; }
        public string ProductName { get; set; }
        public double QuantityAvailable { get; set; }
        public double PricePerQuantity { get; set; }

        //parameterized constructor
        public ProductDetails(string productName,double quatityAvailable,double pricePerQuantity)
        {
            s_productID++;
            ProductID="PID"+s_productID;
            ProductName=productName;
            QuantityAvailable=quatityAvailable;
            PricePerQuantity=pricePerQuantity;
        }
    }
}