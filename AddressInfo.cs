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

        

        // инициализировать 
        //AddressInfo address = new AddressInfo("Казань", "Большая", "80");

        // использовать 
        //AddressInfo[] addressInfos = new AddressInfo[0];

        // передать
        /*public void getUseArray() { 
            foreach(AddressInfo address in addressInfos)
            {
                var mycommand = new SqlCommand("INSERT INTO RSS2 VALUES(@city, @street, @home)", myConnection);
                mycommand.Parameters.AddWithValue("@city", address.City);
                mycommand.Parameters.AddWithValue("@street", address.Street);
                mycommand.Parameters.AddWithValue("@home", address.Home);
                mycommand.ExecuteNonQuery();
            }
        }*/
    }
}
