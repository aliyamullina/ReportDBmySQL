namespace ReportDBmySQL
{
    public class RegistryInfo
    {
        public RegistryInfo(string apartment, string model, string serial)
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