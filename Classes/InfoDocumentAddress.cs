using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDBmySQL
{
    /// <summary>
    /// Модель адреса: город, улица, дом
    /// </summary>
    public class InfoDocumentAddress
    {
        public InfoDocumentAddress() { }
        public InfoDocumentAddress(string address) { this.Address = address; }
        public string Address { get; set; }
    }
}
