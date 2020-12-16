namespace ReportDBmySQL
{
    /// <summary>
    /// Реестр счетчика: квартира, модель, серийный номер
    /// </summary>
    public class InfoRegistry
    {
        public InfoRegistry(int catalog_id, string apartment, string model, string serial)
        {
            this.Catalog_id = catalog_id;
            this.Apartment = apartment;
            this.Model = model;
            this.Serial = serial;
        }

        /// <summary>
        /// id Каталога
        /// </summary>
        public int Catalog_id { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        public string Apartment { get; set; }

        /// <summary>
        /// Модель счетчика
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Серийный номер счетчика
        /// </summary>
        public string Serial { get; set; }
    }
}