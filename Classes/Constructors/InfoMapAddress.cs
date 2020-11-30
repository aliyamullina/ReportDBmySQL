namespace ReportDBmySQL
{
    /// <summary>
    /// Адрес: улица, дом, id города, id каталога
    /// </summary>
    public class InfoMapAddress
    {
        public InfoMapAddress()
        {
        }

        public InfoMapAddress(string address)
        {
            this.Address = address;
        }

        public string Address { get;  set; }
    }
}
