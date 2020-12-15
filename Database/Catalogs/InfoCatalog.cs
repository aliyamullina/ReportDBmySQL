namespace ReportDBmySQL
{
    /// <summary>
    /// Путь к папке, путь к файлу реестра
    /// </summary>
    public class InfoCatalog
    {
        public InfoCatalog() { }

        public InfoCatalog(string catalog, string registry)
        {
            this.Catalog = catalog;
            this.Registry = registry;
        }

        /// <summary>
        /// Путь к папке
        /// </summary>
        public string Catalog { get; set; }

        /// <summary>
        /// Путь к файлу реестра
        /// </summary>
        public string Registry { get; set; }
    }
}
