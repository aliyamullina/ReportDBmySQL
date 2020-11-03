using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDBmySQL
{
    public class CatalogInfo
    {
        public CatalogInfo(string catalog, string save)
        {
            this.Catalog = catalog;
            this.Save = save;
        }
        public string Catalog { get; private set; }
        public string Save { get; private set; }
    }
}
