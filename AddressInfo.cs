using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    class AddressInfo
    {
        public AddressInfo(string city, string street, string home)
        {
            this.City = city;
            this.Street = street;
            this.Home = home;
        }
        
        public string City { get; private set; }
        public string Street { get; private set; }
        public string Home { get; private set; }
    }
}

// AddressInfo a = new AddressInfo("1", "Большая", "80");
