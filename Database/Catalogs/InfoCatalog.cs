namespace ReportDBmySQL
{
    /// <summary>
    /// Путь к папке, путь к файлу реестра
    /// </summary>
    public class InfoCatalog
    {
        public InfoCatalog(string open, string catalog, string registry)
        {
            this.Open = open;
            this.Catalog = catalog;
            this.Registry = registry;
        }

        /// <summary>
        /// Путь к выбранной папке
        /// </summary>
        public string Open { get; set; }

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
