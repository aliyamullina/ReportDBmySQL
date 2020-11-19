namespace ReportDBmySQL
{
    /// <summary>
    /// Документ: город, улица, дом, выбранная папка, каталог сохранения
    /// </summary>
    public class InfoDocument
    {
        public InfoDocument() { }

        public InfoDocument(string city, string street, string home, string open, string catalog)
        {
            this.City = city;
            this.Street = street;
            this.Home = home;
            this.Catalog = catalog;
            this.Open = open;
        }

        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Catalog { get; set; }
        public string Open { get; set; }
    }
}
