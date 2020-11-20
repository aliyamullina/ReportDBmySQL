namespace ReportDBmySQL
{
    /// <summary>
    /// Документ: город, улица, дом, выбранная папка, каталог сохранения
    /// </summary>
    public class InfoDocument
    {
        public InfoDocument() { }

        public InfoDocument
            (
            // InfoCity
            string city,

            // InfoAddress
            string street, 
            string home,

            // InfoCatalog
            string open, 
            string catalog,

            // InfoRegistry
            string apartment, 
            string model, 
            string serial
            )
        {
            this.City = city;          
            this.Street = street;
            this.Home = home; 
            this.Catalog = catalog;
            this.Open = open;
            this.Apartment = apartment;
            this.Model = model;
            this.Serial = serial;
        }

        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Catalog { get; set; }
        public string Open { get; set; }
        public string Apartment { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
    }
}
