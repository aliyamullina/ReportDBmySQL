namespace ReportDBmySQL
{
    /// <summary>
    /// Адрес: улица, дом, id города, id каталога
    /// </summary>
    public class InfoAddress
    {
        public InfoAddress(string street, string home, string part, int city_id)
        {
            this.Street = street;
            this.Home = home;
            this.Part = part;
            this.City_id = city_id;
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
        /// Часть, если есть
        /// </summary>
        public string Part { get; set; }

        /// <summary>
        /// id Города
        /// </summary>
        public int City_id { get;  set; }
    }
}
