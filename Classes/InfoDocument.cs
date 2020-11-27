namespace ReportDBmySQL
{
    /// <summary>
    /// Модель адреса: город, улица, дом, путь
    /// </summary>
    public class InfoDocument
    {
        public InfoDocument() { }
        public InfoDocument(string address, string catalog) 
        { 
            this.Address = address;
            this.Catalog = catalog;
        }
        public string Address { get; set; }
        public string Catalog { get; set; }
    }
}
