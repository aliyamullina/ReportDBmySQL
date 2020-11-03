namespace ReportDBmySQL
{
    public class AddressInfo
    {
        public AddressInfo(string street, string home, string city_id, string catalog_id)
        {
            this.Street = street;
            this.Home = home;
            this.City_id = city_id;
            this.Catalog_id = catalog_id;
        }

        public string Street { get; private set; }
        public string Home { get; private set; }
        public string City_id { get; private set; }
        public string Catalog_id { get; private set; }
    }
}
