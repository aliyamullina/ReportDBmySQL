using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    class AddressInfo
    {
        public AddressInfo(string street, string home, string city_id)
        {
            this.Street = street;
            this.Home = home;
            this.City_id = city_id;
        }

        public string Street { get; private set; }
        public string Home { get; private set; }
        public string City_id { get; private set; }
    }
}
