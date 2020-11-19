namespace ReportDBmySQL
{
    /// <summary>
    /// Реестр: квартира, модель, серийный номер
    /// </summary>
    public class InfoRegistry
    {
        public InfoRegistry(string apartment, string model, string serial)
        {
            this.Apartment = apartment;
            this.Model = model;
            this.Serial = serial;
        }
        public string Apartment { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
    }
}