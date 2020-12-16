namespace ReportDBmySQL
{
    /// <summary>
    /// Адрес: улица, дом, id города, id каталога
    /// </summary>
    public class InfoAddress
    {
        public InfoAddress(string street, string home, int city_id, int catalog_id)
        {
            this.Street = street;
            this.Home = home;
            this.City_id = city_id;
            this.Catalog_id = catalog_id;
        }

        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get;  set; }

        /// <summary>
        /// Номер дома
        /// </summary>
        public string Home { get;  set; }

        /// <summary>
        /// id Города
        /// </summary>
        public int City_id { get;  set; }

        /// <summary>
        /// id Каталога
        /// </summary>
        public int Catalog_id { get;  set; }
    }
}
