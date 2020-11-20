namespace ReportDBmySQL
{
    /// <summary>
    /// Реестр: квартира, модель, серийный номер
    /// </summary>
    public class InfoRegistry
    {
        public InfoRegistry() { }

        public InfoRegistry(int registeraddress_id, string apartment, string model, string serial)
        {
            this.RegisterAddress_id = registeraddress_id;
            this.Apartment = apartment;
            this.Model = model;
            this.Serial = serial;
        }
        public int RegisterAddress_id { get; set; }
        public string Apartment { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
    }
}