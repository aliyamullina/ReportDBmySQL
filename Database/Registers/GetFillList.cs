using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        public static void GetFillList(in int catalog_id, in List<InfoCatalog> oneCatalogPath, out List<InfoRegistry> registersList)
        {
            registersList = new List<InfoRegistry>();

            foreach (InfoCatalog c in oneCatalogPath)
            {
                GetExcelTableRead(c.Registry, catalog_id, out List <InfoRegistry> catalogRegistersTable);
                registersList = catalogRegistersTable.Union(registersList).ToList();
            }
        }
    }
}
