using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class PersonalDetails
    {
        //property
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }


        //paramertized constructor
        public PersonalDetails(string userName,long phoneNumber)
        {
            UserName=userName;
            PhoneNumber=phoneNumber;
        }
    }
}