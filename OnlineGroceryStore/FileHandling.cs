using System;
using System.IO;

namespace OnlineGroceryStore
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("OnlineGroceryStore"))
            {
                Console.WriteLine("Creating Folder");
                Directory.CreateDirectory("OnlineGroceryStore");
            }
            //file for Customer info
            if(!File.Exists("OnlineGroceryStore/CustomerRegistration.csv"))
            {
                Console.WriteLine("Craeting file....");
                File.Create("OnlineGroceryStore/CustomerRegistration.csv").Close();
            }
            //file for product info
             if(!File.Exists("OnlineGroceryStore/ProductDetails.csv"))
            {
                Console.WriteLine("Craeting file....");
                File.Create("OnlineGroceryStore/ProductDetails.csv").Close();
            }

            //file for booking info
            if(!File.Exists("OnlineGroceryStore/BookingDetails.csv"))
            {
                Console.WriteLine("Craeting file....");
                File.Create("OnlineGroceryStore/BookingDetails.csv").Close();
            }

            //file for order info
            if(!File.Exists("OnlineGroceryStore/OrderDetails.csv"))
            {
                Console.WriteLine("Craeting file....");
                File.Create("OnlineGroceryStore/OrderDetails.csv").Close();
            }
           
        }

        public static void WriteToCSV()
        {
            //customer Info
            string [] customer=new string[Operations.customerList.Count];
            for(int i=0;i<Operations.customerList.Count;i++)
            {
                customer[i]=Operations.customerList[i].CustomerID+","+Operations.customerList[i].Name+","+Operations.customerList[i].FatherName+","+Operations.customerList[i].Gender+","+Operations.customerList[i].MobileNumber+","+Operations.customerList[i].DOB+","+Operations.customerList[i].MailID+Operations.customerList[i].WalletBalance;
            }
             File.WriteAllLines("OnlineGroceryStore/CustomerRegistration.csv",customer);

            //Product Info
            string [] product=new string[Operations.productList.Count];
            for(int i=0;i<Operations.productList.Count;i++)
            {
                product[i]=Operations.productList[i].ProductID+","+Operations.productList[i].ProductName+","+Operations.productList[i].QuantityAvailable+","+Operations.productList[i].PricePerQuantity;
            }
             File.WriteAllLines("OnlineGroceryStore/ProductDetails.csv",product);

            //Order info
            string []order=new string[Operations.orderList.Count];
            for(int i=0;i<Operations.orderList.Count;i++)
            {
                order[i]=Operations.orderList[i].OrderID+","+Operations.orderList[i].BookingID+","+Operations.orderList[i].ProductID+","+Operations.orderList[i].PurchaseCount+","+Operations.orderList[i].PriceOfOrder;
            }
            File.WriteAllLines("OnlineGroceryStore/OrderDetails.csv",order);

            //booking info
            
            string []booking=new string[Operations.bookingList.Count];
            for(int i=0;i<Operations.bookingList.Count;i++)
            {
                booking[i]=Operations.bookingList[i].BookingID+","+Operations.bookingList[i].CustomerID+","+Operations.bookingList[i].TotalPrice+","+Operations.bookingList[i].DateOfBooking+","+Operations.bookingList[i].BookingStatus;
            }
            File.WriteAllLines("OnlineGroceryStore/BookingDetails.csv",order);
            
            
         }

        // public static void ReadFromCSV()
        // {
        //     string [] customer =File.ReadAllLines("OnlineGroceryStore/CustomerRegistration.csv");
        //     foreach(string customers in customer)
        //     {
        //        CustomerRegistration customerFDetails=new CustomerRegistration(customers);
        //         Operations.customerList.Add(customerFDetails);
        //     }

        //     string [] prodDetails =File.ReadAllLines("OnlineGroceryStore/ProductDetails.csv");
        //     foreach(string product in prodDetails)
        //     {
        //         ProductDetails productDetails =new ProductDetails(product);
        //         Operations.productList.Add(productDetails);
        //     }

        //     string [] orderDetails =File.ReadAllLines("OnlineGroceryStore/OrderDetails.csv");
        //     foreach(string order in orderDetails)
        //     {
        //         OrderDetails orderDetails1=new OrderDetails(order);
        //         Operations.orderList.Add(orderDetails1);
        //     }
            

        //     string [] bookingDetails =File.ReadAllLines("OnlineGroceryStore/BookingDetails.csv");
        //     foreach(string booking in bookingDetails)
        //     {
        //         BookingDetails bookingDetails1=new BookingDetails(booking);
        //         Operations.orderList.Add(bookingDetails1);
        //     }

        // }
    }
}

