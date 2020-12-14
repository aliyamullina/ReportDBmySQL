namespace ReportDBmySQL
{
    /// <summary>
    /// Город: название города
    /// </summary>
    public class InfoCity
    {
        public InfoCity(string city) { this.City = city; }
        public string City { get; private set; }
    }
}
