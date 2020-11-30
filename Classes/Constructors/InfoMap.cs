namespace ReportDBmySQL
{
    /// <summary>
    /// Карта: данные с карты, этаж, количество квартир, число подъездов
    /// </summary>
    public class InfoMap
    {
        public InfoMap(string floor, string flatscount, string entrance)
        {
            this.Floor = floor;
            this.FlatsCount = flatscount;
            this.Entrance = entrance;
        }

        public string Floor { get; set; }
        public string FlatsCount { get; set; }
        public string Entrance { get; set; }
    }
}