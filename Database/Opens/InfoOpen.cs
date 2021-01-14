namespace ReportDBmySQL
{
    /// <summary>
    /// Путь к выбранной папке
    /// </summary>
    public class InfoOpen
    {
        public InfoOpen(string open)
        {
            this.Open = open;
        }

        /// <summary>
        /// Путь к выбранной папке
        /// </summary>
        public string Open { get; set; }
    }
}
