namespace ReportDBmySQL
{
    /// <summary>
    /// Карта: данные с карты, этаж, количество квартир, число подъездов
    /// </summary>
    public class InfoMap
    {
        public InfoMap(string floor, string apartment, string entrance)
        {
            this.Floor = floor;
            this.Apartment = apartment;
            this.Entrance = entrance;
        }

        public string Floor { get; set; }
        public string Apartment { get; set; }
        public string Entrance { get; set; }
    }
}