namespace ReportDBmySQL
{
    /// <summary>
    /// Адрес: город, улица и дом; Этаж; Квартира; Подъезд
    /// </summary>
    public class InfoMap
    {
        public InfoMap(string address, string floor, string flatscount, string entrance)
        {
            this.Address = address;
            this.Floor = floor;
            this.FlatsCount = flatscount;
            this.Entrance = entrance;
        }

        /// <summary>
        /// Адрес: город, улица и дом
        /// </summary>
        public string Address { get;  set; }

        /// <summary>
        /// Этаж
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        public string FlatsCount { get; set; }

        /// <summary>
        /// Подъезд
        /// </summary>
        public string Entrance { get; set; }
    }
}
