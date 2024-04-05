using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserDetails : PersonalDetails, Ibalance
    {
        //field
        private static int s_cardNumber=100;
        private double _balance=0.0;

        //property
        public string  CardNumber { get;  }
        public double Balance { get{return _balance;} }

        //parameterized constructor
        public UserDetails( string userName,long phoneNumber,double balance) : base(userName, phoneNumber)
        {
            s_cardNumber++;
            CardNumber="CMRL"+s_cardNumber;
            _balance=balance;
             UserName=userName;
            PhoneNumber=phoneNumber;
        }

        public  void WalletRecharge(double rechargeAmount)
        {
            _balance+=rechargeAmount;
        }
        public void DeductBalance(double amount)
        {
            _balance-=amount;
        }
    }
}