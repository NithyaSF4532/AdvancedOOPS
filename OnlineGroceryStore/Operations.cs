using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Transactions;
using List_DataStructures;

namespace OnlineGroceryStore
{
    public class Operations
    {
        public static CustomList<CustomerRegistration> customerList = new CustomList<CustomerRegistration>();
        public static CustomList<ProductDetails> productList = new CustomList<ProductDetails>();
        public static CustomList<BookingDetails> bookingList = new CustomList<BookingDetails>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        static CustomerRegistration currentUser;

        public static void AddDefaultDetails()
        {
            //Adding Default customer details
            customerList.Add(new CustomerRegistration("Ravi", "Ettapparajan", Gender.Male, 974774646, new DateTime(1999, 11, 11), "ravi@gmail.com", 10000));
            customerList.Add(new CustomerRegistration("Baskaran", "Sethurajan", Gender.Male, 847575775, new DateTime(1999, 11, 11), "baskaran@gmail.com", 15000));
            //Adding Default product details
            productList.Add(new ProductDetails("Sugar", 20, 40));
            productList.Add(new ProductDetails("Rice", 100, 50));
            productList.Add(new ProductDetails("Milk", 10, 40));
            productList.Add(new ProductDetails("Coffee", 10, 10));
            productList.Add(new ProductDetails("Tea", 10, 10));
            productList.Add(new ProductDetails("Masala Powder", 10, 20));
            productList.Add(new ProductDetails("Salt", 10, 10));
            productList.Add(new ProductDetails("Turmeric Powder", 10, 25));
            productList.Add(new ProductDetails("Chilli Powder", 10, 20));
            productList.Add(new ProductDetails("Groundnut", 10, 140));

            //Adding Default booking details
            bookingList.Add(new BookingDetails("CID1001", 220, new DateTime(2022, 07, 26), BookingStatus.Booked));
            bookingList.Add(new BookingDetails("CID1002", 400, new DateTime(2022, 07, 26), BookingStatus.Booked));
            bookingList.Add(new BookingDetails("CID1001", 280, new DateTime(2022, 07, 26), BookingStatus.Cancelled));
            bookingList.Add(new BookingDetails("CID1002", 0, new DateTime(2022, 07, 26), BookingStatus.Initiated));

            //Adding Default order Details
            orderList.Add(new OrderDetails("BID3001", "PID2001", 2, 80));
            orderList.Add(new OrderDetails("BID3001", "PID2002", 2, 100));
            orderList.Add(new OrderDetails("BID3001", "PID2003", 1, 40));
            orderList.Add(new OrderDetails("BID3002", "PID2001", 1, 40));
            orderList.Add(new OrderDetails("BID3002", "PID2002", 4, 200));
            orderList.Add(new OrderDetails("BID3002", "PID2010", 1, 140));
            orderList.Add(new OrderDetails("BID3002", "PID2009", 1, 20));
            orderList.Add(new OrderDetails("BID3003", "PID2002", 2, 100));
            orderList.Add(new OrderDetails("BID3003", "PID2008", 4, 100));
            orderList.Add(new OrderDetails("BID3003", "PID2001", 2, 80));

            //Displaying Default Details
            //Customer
            foreach (CustomerRegistration customer in customerList)
            {
                Console.WriteLine($"CustomerID:{customer.CustomerID} || Name:{customer.Name} || FatherName:{customer.FatherName} || Gender:{customer.Gender} || Moblie:{customer.MobileNumber} || DOB:{customer.DOB.ToString("dd/MM/yyy")} || MailID:{customer.MailID} || WalletBalance:{customer.WalletBalance}");
            }

            //product
            foreach (ProductDetails product in productList)
            {
                Console.WriteLine($"ProductID:{product.ProductID} || ProductName:{product.ProductName} || Quantity:{product.QuantityAvailable} || Price:{product.PricePerQuantity}");
            }

            //Booking
            foreach (BookingDetails booking in bookingList)
            {
                Console.WriteLine($"BookingID:{booking.BookingID} || CustomerID:{booking.CustomerID} || TotalPrice:{booking.TotalPrice} || DateOfBooking:{booking.DateOfBooking.ToString("dd/MM/yyyy")} || BookingStatus:{booking.BookingStatus}");

            }

            //Order
            foreach (OrderDetails order in orderList)
            {
                Console.WriteLine($"OrderID:{order.OrderID} || BookingID:{order.BookingID} || ProductID:{order.ProductID} || PurchaseCount:{order.PurchaseCount} || PriceOfOrder:{order.PriceOfOrder}");
            }
        }

        //MainMenu
        public static void MainMenu()
        {
            bool flag = true;
            do
            {
                Console.WriteLine("1. Registration\n2.Login\n3.Exit");
                Console.WriteLine("enter your Option");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            flag = false;
                            Console.WriteLine("Exit");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid CustomerID");
                            break;
                        }
                }
            } while (flag);
        }

        static void Registration()
        {
            Console.Write("Enter your name:");
            string name = Console.ReadLine();

            Console.Write("Enter your Father name:");
            string fatherName = Console.ReadLine();

            Console.Write("Enter your Gender:");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            Console.Write("Enter your number:");
            long mobileNumber = long.Parse(Console.ReadLine());

            Console.Write("Enter your DOB:");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Enter your MailID:");
            string mailID = Console.ReadLine();

            Console.Write("Enter your balance:");
            double walletBalance = double.Parse(Console.ReadLine());

            CustomerRegistration customer = new CustomerRegistration(name, fatherName, gender, mobileNumber, dob, mailID, walletBalance);
            customerList.Add(customer);
            Console.WriteLine("Registration Successful");
            Console.WriteLine("Your customerID is" + " " + customer.CustomerID);


        }
        static void Login()
        {
            Console.Write("Enter your customerID:");
            string askCustomerID = Console.ReadLine().ToUpper();
            int value = BinarySearch(askCustomerID);
            if (value > 0)
            {
                SubMenu();
            }
            else
            {
                Console.WriteLine("Invalid CustomerID");
            }

            // foreach(CustomerRegistration customer in customerList)
            // {
            //     if(customer.CustomerID.Equals(askCustomerID))
            //     {
            //         flag=false;
            //         Console.WriteLine("Login Successfull");
            //         currentUser=customer;
            //         SubMenu();
            //         break;
            //     }
            // }
            // if(flag)
            // {
            //     Console.WriteLine("Invalid ID");
            // }
        }
        public static int BinarySearch(string askCustomerID)
        {
            int left = 0;
            int right = customerList.Count + 1;
            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (customerList[middle].CustomerID.Equals(askCustomerID))
                {
                    Console.WriteLine("Login successfull");
                    currentUser = customerList[middle];
                    return 1;

                }
                else if (askCustomerID.CompareTo(customerList[middle].CustomerID) == 1)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return -1;

        }




        //Submenu
        static void SubMenu()
        {
            bool flag = true;
            do
            {
                Console.WriteLine("1.Show Customer Details\n2.Show Product Details\n3.Wallet Recharge\n4.Take Order\n5.Modify Order Quantity\n6.Cancel Order\n7.Order History\n8.Show Balance\n9.Exit");
                Console.Write("Enter your Option:");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            ShowCustomerDetails();
                            break;
                        }
                    case 2:
                        {
                            ShowProductDetails();
                            break;
                        }
                    case 3:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 4:
                        {
                            TakeOrder();
                            break;
                        }
                    case 5:
                        {
                            ModifyOrderQuantity();
                            break;
                        }
                    case 6:
                        {
                            CancelOrder();
                            break;
                        }
                    case 7:
                        {
                            OrderHistory();
                            break;
                        }
                    case 8:
                        {
                            ShowBalance();
                            break;
                        }
                    case 9:
                        {
                            flag = false;
                            Console.WriteLine("Exit");
                            break;
                        }
                }

            } while (flag);
        }

        static void ShowCustomerDetails()
        {
            bool flag = true;
            foreach (CustomerRegistration customer in customerList)
            {
                if (customer.CustomerID == currentUser.CustomerID)
                {
                    flag = false;
                    Console.WriteLine($"CustomerID:{currentUser.CustomerID} || Name:{currentUser.Name} || FatherName:{currentUser.FatherName} || Gender:{currentUser.Gender} || Moblie:{currentUser.MobileNumber} || DOB:{currentUser.DOB.ToString("dd/MM/yyy")} || MailID:{currentUser.MailID} || WalletBalance:{currentUser.WalletBalance}");
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid CustomerID");
            }

        }

        static void ShowProductDetails()
        {
            foreach (ProductDetails product in productList)
            {
                Console.WriteLine($"ProductID:{product.ProductID} || ProductName:{product.ProductName} || Quantity:{product.QuantityAvailable} || Price:{product.PricePerQuantity}");
            }

        }

        static void WalletRecharge()
        {
            Console.WriteLine("Do you want to recharge your wallet?");
            string askrecharge = Console.ReadLine().ToLower();

            if (askrecharge == "yes")
            {

                Console.WriteLine("Enter the Recharege amount:");
                double rechargeAmount = double.Parse(Console.ReadLine());

                if (rechargeAmount > 0)
                {

                    currentUser.WalletRecharge(rechargeAmount);
                    Console.WriteLine("Your Balance:" + currentUser.WalletBalance);
                }
                else
                {
                    Console.WriteLine("Invalid amount");
                }

            }

        }

        static void TakeOrder()
        {
            //ask customer if he want want to purchase
            Console.WriteLine("Do you want to purchase?");
            string askCustomer = Console.ReadLine().ToLower();
            double total = 0;
            double fullTotal = 0;
            string askAnotherProd = "";






            //if yes then create booking detail objects
            if (askCustomer == "yes")
            {
                BookingDetails booking = new BookingDetails(currentUser.CustomerID, 0, DateTime.Now, BookingStatus.Initiated);
                CustomList<OrderDetails> tempOrderList = new CustomList<OrderDetails>();
                // displaying product details of available stock.
                do
                {
                    foreach (ProductDetails product in productList)
                    {

                        Console.WriteLine($"ProductID:{product.ProductID} || ProductName:{product.ProductName} || Quantity:{product.QuantityAvailable} || Price:{product.PricePerQuantity}");

                    }
                    //ask the user to enter the productId to be purchsed
                    Console.Write("Enter your productID:");
                    string askProductID = Console.ReadLine();


                    bool IsValidate = true;
                    foreach (ProductDetails product in productList)
                    {
                        if (product.ProductID.Equals(askProductID))
                        {
                            IsValidate = false;
                            Console.Write("Enter your purchase Quantity:");
                            double selectedQuantity = double.Parse(Console.ReadLine());


                            // Check whether the selected Purchase quantity is available in stock.
                            if (product.QuantityAvailable >= selectedQuantity)
                            {
                                total = selectedQuantity * product.PricePerQuantity;
                                fullTotal += total;
                                OrderDetails order = new OrderDetails(booking.BookingID, product.ProductID, (int)selectedQuantity, fullTotal);
                                tempOrderList.Add(order);
                                product.QuantityAvailable -= selectedQuantity;
                                Console.WriteLine("Product added successfully to the cart");

                            }



                        }


                    }
                    if (IsValidate)
                    {
                        Console.WriteLine("Invalid ProductID");
                    }



                    Console.WriteLine("Do you want to book another product? ");
                    askAnotherProd = Console.ReadLine();

                } while (askAnotherProd == "yes");



                Console.WriteLine("Do you want to confirm the order?");
                string askConfirm = Console.ReadLine();

                if (askConfirm == "yes")
                {
                    do
                    {

                        if (currentUser.WalletBalance >= fullTotal)
                        {
                            currentUser.DeductBalance(fullTotal);
                            Console.WriteLine("your walletBalance:" + currentUser.WalletBalance);
                            booking.BookingStatus = BookingStatus.Booked;
                            booking.TotalPrice = fullTotal;
                            bookingList.Add(booking);

                             orderList.AddRange(tempOrderList);
                            Console.WriteLine("Booking Successfull");


                        }
                        else
                        {
                            Console.WriteLine("Insufficient account balance recharge with" + fullTotal);
                            Console.WriteLine("Do you want to recharge?");
                            string recharge = Console.ReadLine();
                            if (recharge == "yes")
                            {


                                Console.Write("Enter the amount to be recharged:");
                                double enterAmount = double.Parse(Console.ReadLine());

                                currentUser.WalletRecharge(enterAmount);
                                Console.WriteLine("your wallet balance:" + currentUser.WalletBalance);



                            }
                        }
                    } while (currentUser.WalletBalance < fullTotal);

                }
                else
                {
                    foreach (OrderDetails order1 in tempOrderList)
                    {
                        foreach (ProductDetails product1 in productList)
                        {
                            if (order1.ProductID.Equals(product1.ProductID))
                            {
                                product1.QuantityAvailable = order1.PurchaseCount;
                                Console.WriteLine("Cart Removed sucessfully");
                                break;
                            }
                        }

                    }
                }




            }




        }

        static void ModifyOrderQuantity()
        {
            foreach (BookingDetails booking in bookingList)
            {
                if (booking.CustomerID.Equals(currentUser.CustomerID))
                {
                    if (booking.BookingStatus == BookingStatus.Booked)
                    {
                       
                    }
                }
            }
        }

        static void CancelOrder()
        {
            bool flag = true;
            foreach (BookingDetails booking in bookingList)
            {
                if (currentUser.CustomerID.Equals(booking.CustomerID) && booking.BookingStatus == BookingStatus.Booked)
                {
                    flag = false;
                    Console.WriteLine($"BookingID:{booking.BookingID} || CustomerID:{booking.CustomerID} || TotalPrice:{booking.TotalPrice} || DateOfBooking:{booking.DateOfBooking.ToString("dd/MM/yyyy")} || BookingStatus:{booking.BookingStatus}");

                }
            }

            Console.WriteLine("Enter your Booking Id to be cancelled");
            string askBookingID = Console.ReadLine();
            foreach (BookingDetails booking in bookingList)
            {

                if (askBookingID == booking.BookingID && booking.BookingStatus == BookingStatus.Booked)
                {
                    booking.BookingStatus = BookingStatus.Cancelled;
                    currentUser.WalletRecharge(booking.TotalPrice);
                    Console.WriteLine("Balance:" + currentUser.WalletBalance);
                    foreach (OrderDetails order in orderList)
                    {
                        foreach (ProductDetails product in productList)
                        {
                            if (order.ProductID.Equals(product.ProductID))
                            {
                                product.QuantityAvailable += order.PurchaseCount;

                            }
                        }
                    }
                }
                Console.WriteLine("Booking Cancelled Successfully");
                break;

            }

            if (flag)
            {
                Console.WriteLine("No booking placed yet now");
            }



        }

        static void OrderHistory()
        {
            bool flag = true;

            foreach (BookingDetails booking in bookingList)
            {
                if (currentUser.CustomerID.Equals(booking.CustomerID))
                {
                    flag = false;
                    foreach (OrderDetails order in orderList)
                    {
                        if (booking.BookingID == order.BookingID)
                        {
                            Console.WriteLine($"OrderID:{order.OrderID} || BookingID:{order.BookingID} || ProductID:{order.ProductID} || PurchaseCount:{order.PurchaseCount} || PriceOfOrder:{order.PriceOfOrder}");
                        }

                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("No Order found");
            }
        }

        static void ShowBalance()
        {
            Console.WriteLine($"your wallet balnce is:{currentUser.WalletBalance}");
        }




    }
}

















