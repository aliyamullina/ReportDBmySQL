namespace ReportDBmySQL
{
    /// <summary>
    /// Каталог: выбранная папка, внутренние папки, файл реестра
    /// </summary>
    public class InfoCatalog
    {
        public InfoCatalog() { }

        public InfoCatalog(string catalog, string registry)
        {
            this.Catalog = catalog;
            this.Registry = registry;
        }

        public string Catalog { get; set; }
        public string Registry { get; set; }
    }
}
