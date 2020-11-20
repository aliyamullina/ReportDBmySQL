namespace ReportDBmySQL
{
    /// <summary>
    /// Адрес: улица, дом, id города, id каталога
    /// </summary>
    public class InfoAddress
    {
        public InfoAddress() { }

        public InfoAddress(string street, string home, int city_id, int catalog_id, int registeraddress_id)
        {
            this.Street = street;
            this.Home = home;
            this.City_id = city_id;
            this.Catalog_id = catalog_id;
            this.RegisterAddress_id = registeraddress_id;
        }

        public string Street { get;  set; }
        public string Home { get;  set; }
        public int City_id { get;  set; }
        public int Catalog_id { get;  set; }
        public int RegisterAddress_id { get;  set; }
    }
}
