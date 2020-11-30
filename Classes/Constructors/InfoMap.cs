namespace ReportDBmySQL
{
    /// <summary>
    /// Карта: данные с карты, этаж, количество квартир, число подъездов
    /// </summary>
    public class InfoMap
    {
        public InfoMap(string floor, string apartmentcount, string entrance)
        {
            this.Floor = floor;
            this.ApartmentCount = apartmentcount;
            this.Entrance = entrance;
        }

        public string Floor { get; set; }
        public string ApartmentCount { get; set; }
        public string Entrance { get; set; }
    }
}