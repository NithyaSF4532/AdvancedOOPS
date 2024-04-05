using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore
{
    //Enumerated Types
    public enum Gender{Select,Male,Female,Others}
    public class CustomerRegistration
    {
        //field
        private static int s_customerID=1000;
        private double _walletBalance;
        //property
        public string CustomerID { get; }
       
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public long MobileNumber { get; set; }
        public DateTime DOB { get; set; }
        public string MailID { get; set; }
         public double WalletBalance { get{return _walletBalance;} }
    
    //parameterized constructor

    public CustomerRegistration(string name,string fatherName,Gender gender,long mobileNumber,DateTime dob,string mailID,double walletBalance)
    {
       s_customerID++;
       CustomerID="CID"+s_customerID;
       Name=name;
       FatherName=fatherName;
       Gender=gender;
       MobileNumber=mobileNumber;
       DOB=dob;
       MailID=mailID; 
       _walletBalance=walletBalance;

    }
   
     public void WalletRecharge(double rechargeAmount)
     {
        _walletBalance+=rechargeAmount;
     }
     public void DeductBalance(double amount)
     {
        _walletBalance-=amount;
     }

}
}