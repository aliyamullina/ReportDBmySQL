using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        public static void GetFillList(ref List<InfoRegistry> registersList, int catalog_id, List<InfoCatalog> oneCatalogPath)
        {
            foreach (InfoCatalog c in oneCatalogPath)
            {
                GetExcelTableRead(c.Registry, catalog_id, out List <InfoRegistry> registersTable);
                registersList = registersTable.Union(registersList).ToList();
            }
        }
    }
}
