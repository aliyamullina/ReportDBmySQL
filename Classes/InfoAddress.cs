namespace ReportDBmySQL
{
    public class InfoAddress
    {
        public InfoAddress()
        {
        }

        public InfoAddress(string street, string home, int city_id, int catalog_id)
        {
            this.Street = street;
            this.Home = home;
            this.City_id = city_id;
            this.Catalog_id = catalog_id;
        }
        public string Street { get;  set; }
        public string Home { get;  set; }
        public int City_id { get;  set; }
        public int Catalog_id { get;  set; }
    }
}
