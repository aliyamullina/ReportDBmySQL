namespace ReportDBmySQL
{
    class CatalogInfo
    {
        public CatalogInfo(string catalogPath)
        {
            this.CatalogPath = catalogPath;
        }
        public string CatalogPath { get; private set; }
    }
}
