namespace ReportDBmySQL
{
    /// <summary>
    /// Каталог: выбранная папка, внутренние папки, файл реестра
    /// </summary>
    public class InfoCatalog
    {
        public InfoCatalog() { }

        public InfoCatalog(string open, string catalog, string registry)
        {
            this.Open = open;
            this.Catalog = catalog;
            this.Registry = registry;
        }

        public string Open { get; set; }
        public string Catalog { get; set; }
        public string Registry { get; set; }
    }
}
