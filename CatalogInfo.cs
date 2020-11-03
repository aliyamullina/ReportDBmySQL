namespace ReportDBmySQL
{
    public class CatalogInfo
    {
        public CatalogInfo(string catalog, string save)
        {
            this.Catalog = catalog;
            this.Save = save;
        }
        public string Catalog { get; set; }
        public string Save { get; set; }
    }
}
