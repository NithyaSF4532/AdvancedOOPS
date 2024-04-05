using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class Operations
    {
       public static CustomList<UserDetails> userList=new CustomList<UserDetails>();
        public static CustomList<TravelDetails> travelList=new CustomList<TravelDetails>();
        public static CustomList<TicketFairDetails> ticketList=new CustomList<TicketFairDetails>();
        static UserDetails currentUser;
        public static void AddDefaultDetails()
        {
            //add user details
            userList.Add(new UserDetails("Ravi",94888,1000));
            userList.Add(new UserDetails("Baskaran",99498,1000));
            //add travel details
            travelList.Add(new TravelDetails("CMRL101","Airport","Egmore",new DateTime(2022,10,10),55));
            travelList.Add(new TravelDetails("CMRL101","Egmore","Koyambedu",new DateTime(2022,10,10),32));
            travelList.Add(new TravelDetails("CMRL102","Alandur","Koyambedu",new DateTime(2022,11,10),25));
            travelList.Add(new TravelDetails("CMRL102","Egmore","Thirumangalam",new DateTime(2022,11,10),25)); 
            //add ticket details
            ticketList.Add(new TicketFairDetails("Airport","Egmore",55));
            ticketList.Add(new TicketFairDetails("Airport","Koyambedu",25));
            ticketList.Add(new TicketFairDetails("Alandur","Koyambedu",25));
            ticketList.Add(new TicketFairDetails("Koyambedu","Egmore",32));
            ticketList.Add(new TicketFairDetails("Vadapalani","Egmore",45));
            ticketList.Add(new TicketFairDetails("Arumbakkam","Egmore",25));
            ticketList.Add(new TicketFairDetails("Vadapalani","Koyambedu",25));
            ticketList.Add(new TicketFairDetails("Arumbakam","Koyambedu",16));

            //Displaying default details
            //user details
            foreach(UserDetails user in userList)
            {
                Console.WriteLine($"CardNumber:{user.CardNumber} || UserName:{user.UserName} || Phone:{user.PhoneNumber} || Balance:{user.Balance}");
            }

            //travel details
            foreach(TravelDetails travel in travelList)
            {
                Console.WriteLine($"TravelID:{travel.TravelID} || CardNumber:{travel.CardNumber} || FromLocation:{travel.FromLocation} || ToLocation:{travel.ToLocation} || Date:{travel.Date.ToString("dd/MM/yyyy")} || TravelCost:{travel.TravelCost}");
            }

            //ticket details
            foreach(TicketFairDetails ticket in ticketList)
            {
                Console.WriteLine($"TicketID:{ticket.TicketID} || FromLocation:{ticket.FromLocation} || ToLocation:{ticket.ToLocation} || TicketPrice:{ticket.TicketPrice}");
            }

        }

        //MainMenu
        public static void MainMenu()
        {
            bool flag=true;
            do
            {
                Console.WriteLine("1.UserRegistration\n2.Login\n3.Exit");
                Console.Write("Enter your option:");
                int option=int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        UserRegistration();
                        break;
                    }
                    case 2:
                    {
                        Login();
                        break;
                    }
                    case 3:
                    {
                        flag=false;
                        Console.WriteLine("EXit");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid Option");
                        break;
                    }
                }

                }while(flag);
        }

        static void UserRegistration()
        {
           Console.Write("Enter your Name:");
           string userName=Console.ReadLine();

           Console.Write("Enter your PhoneNUmber:");
           long phoneNumber=long.Parse(Console.ReadLine());

           Console.Write("Enter your Balance:");
           double balance=double.Parse(Console.ReadLine());

           UserDetails user=new UserDetails(userName,phoneNumber,balance);
           userList.Add(user);
           Console.WriteLine("UserRegistration successful");
           Console.WriteLine("your CardNUmber is"+" "+user.CardNumber);


        }

        static void Login()
        {
            bool flag=true;
            Console.Write("Enter your CardNumber:");
            string askCardNumber=Console.ReadLine().ToUpper();
            foreach(UserDetails user in userList)
            {
               if(user.CardNumber.Equals(askCardNumber))
               {
                  flag=false;
                  Console.WriteLine("Login Successful");
                  currentUser=user;
                  SubMenu();
                  break;


               }
            }
            if(flag)
            {
                Console.WriteLine("Invalid CardNUmber");
            }
        }

        static void SubMenu()
        {
            bool flag=true;
            do
            {
                Console.WriteLine("1.Balance check\n2.Recharge\n3.View travel History\n4.Travel\n5.Exit");
                Console.Write("Enter your option:");
                int option=int.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                    {
                        BalanceCheck();
                        break;
                    }
                    case 2:
                    {
                        Recharge();
                        break;
                    }
                    case 3:
                    {
                        ViewTravelHistory();
                        break;
                    }
                    case 4:
                    {
                        Travel();
                        break;
                    }
                    case 5:
                    {
                        flag=false;
                        Console.WriteLine("Exit");
                        break;
                    }
                   
                }
            }while(flag);
        }

        static void BalanceCheck()
        {
           Console.WriteLine("your balance:"+" "+currentUser.Balance);
        }

        static void Recharge()
        {
           Console.WriteLine("Do you want to recharge:");
           string AskRecharge=Console.ReadLine().ToLower();
           if(AskRecharge=="yes")
           {
               Console.WriteLine("Enter the amount to be recharged");
               int rechargeAmount=int.Parse(Console.ReadLine());
               if(rechargeAmount>0)
               {
                   currentUser.WalletRecharge(rechargeAmount);
                   Console.WriteLine("your Balance:"+currentUser.Balance);
               }
               else
               {
                  Console.WriteLine("Invalid Amount");
               }

           }
        }



        static void ViewTravelHistory()
        {
            bool flag=true;
            foreach(TravelDetails travel in travelList)
            {
                if(travel.CardNumber.Equals(currentUser.CardNumber))
                {
                    flag=false;
                    Console.WriteLine($"TravelID:{travel.TravelID} || CardNumber:{travel.CardNumber} || FromLocation:{travel.FromLocation} || ToLocation:{travel.ToLocation} || Date:{travel.Date.ToString("dd/MM/yyyy")} || TravelCost:{travel.TravelCost}");
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid Card number, No travel History found");
            }

        }

        static void Travel()
        {
          
           bool flag=true;
           foreach(TicketFairDetails ticket in ticketList)
           {
              Console.WriteLine($"TicketID:{ticket.TicketID} || FromLocation:{ticket.FromLocation} || ToLocation:{ticket.ToLocation} || TicketPrice:{ticket.TicketPrice}");
           }
            Console.WriteLine("Enter your TicketID:");
           string askTicketID=Console.ReadLine();

           foreach(TicketFairDetails ticket in ticketList)
           {
              if(askTicketID.Equals(ticket.TicketID))
              {
                flag=false;
                Console.WriteLine($"TicketID:{ticket.TicketID} || FromLocation:{ticket.FromLocation} || ToLocation:{ticket.ToLocation} || TicketPrice:{ticket.TicketPrice}");
                do{
                if(ticket.TicketPrice<=currentUser.Balance)
                {
                    currentUser.DeductBalance(ticket.TicketPrice);
                    Console.WriteLine("your balance:"+currentUser.Balance);
                    TravelDetails travel=new TravelDetails(currentUser.CardNumber,ticket.FromLocation,ticket.ToLocation,DateTime.Now,ticket.TicketPrice);
                    travelList.Add(travel);
                    Console.WriteLine("Your Ticket Booking is suceessfull");
                }
                else
                {
                    Console.WriteLine("Insufficient Balance,please recharge with"+ticket.TicketPrice);
                    Console.WriteLine("Do you want to recharge");
                    string askRecharge=Console.ReadLine().ToLower();
                    if(askRecharge=="yes")
                    {
                        Console.WriteLine("Enter the amount need to recharge:");
                        double amount=double.Parse(Console.ReadLine());
                        if(amount>0)
                        {
                            currentUser.WalletRecharge(amount);
                            Console.WriteLine("your balance: "+currentUser.Balance);
                        }
                    }
                    else
                    {
                        Console.WriteLine("go to existing userID");
                        break;
                    }
                }
                }while(ticket.TicketPrice>currentUser.Balance);

              }
           }
           if(flag)
           {
             Console.WriteLine("Invalid UserID");
           }

        }

       
    }

}