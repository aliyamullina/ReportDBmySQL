namespace ReportDBmySQL
{
    /// <summary>
    /// Модель адреса: город, улица, дом
    /// </summary>
    public class InfoDocumentAddress
    {
        public InfoDocumentAddress() { }
        public InfoDocumentAddress(string address) { this.Address = address; }
        public string Address { get; set; }
    }

    /// <summary>
    /// Модель каталога: путь
    /// </summary>
    public class InfoDocumentCatalog
    {
        public InfoDocumentCatalog() { }
        public InfoDocumentCatalog(string catalog) { this.Catalog = catalog; }
        public string Catalog { get; set; }
    }

    public class InfoDocumentTable
    {
        public InfoDocumentTable() { }

        public InfoDocumentTable
            (
            // InfoCity
            string city,

            // InfoAddress
            string street, 
            string home,

            // InfoRegistry
            string apartment, 
            string model, 
            string serial
            )
        {
            this.City = city;          
            this.Street = street;
            this.Home = home; 

            this.Apartment = apartment;
            this.Model = model;
            this.Serial = serial;
        }

        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Apartment { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
    }
}
