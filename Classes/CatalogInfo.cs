namespace ReportDBmySQL
{
    public class CatalogInfo
    {
        public CatalogInfo()
        {
        }

        public CatalogInfo(string open, string catalog, string registry)
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
