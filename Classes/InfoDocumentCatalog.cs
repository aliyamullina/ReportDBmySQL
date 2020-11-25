using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDBmySQL
{
    /// <summary>
    /// Модель каталога: путь
    /// </summary>
    public class InfoDocumentCatalog
    {
        public InfoDocumentCatalog() { }
        public InfoDocumentCatalog(string catalog) { this.Catalog = catalog; }
        public string Catalog { get; set; }
    }
}
