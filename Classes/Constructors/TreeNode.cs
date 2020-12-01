namespace ReportDBmySQL
{
    /// <summary>
    /// Адрес: улица, дом, id города, id каталога
    /// </summary>
    public class TreeNode
    {
        public TreeNode()
        {
        }

        public TreeNode(string address, string floor, string flatscount, string entrance)
        {
            this.Address = address;
            this.Floor = floor;
            this.FlatsCount = flatscount;
            this.Entrance = entrance;
        }

        public string Address { get;  set; }
        public string Floor { get; set; }
        public string FlatsCount { get; set; }
        public string Entrance { get; set; }
    }
}
