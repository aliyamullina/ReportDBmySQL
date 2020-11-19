namespace ReportDBmySQL
{
    public class DocumentInfo
    {
        public DocumentInfo()
        {
        }

        public DocumentInfo(string city, string street, string home, string open, string catalog)
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
