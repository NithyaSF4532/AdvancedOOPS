using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public interface Ibalance
    {
        //field
        private static double _balance=0.0;
        //property
        public double Balance { get{return _balance;} }

        public void WalletRecharge(double rechargeAmount);
        public void DeductBalance(double amount);

    }
}