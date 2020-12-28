using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        public static void GetFillList(in int catalog_id, in List<InfoCatalog> oneCatalogPath, out List<InfoRegistry> registersList, out List<DateTime> dateList)
        {
            registersList = new List<InfoRegistry>();
            dateList = new List<DateTime>();

            foreach (InfoCatalog c in oneCatalogPath)
            {
                GetExcelTableRead(c.Registry, catalog_id, out List <InfoRegistry> catalogRegistersTable, out List<DateTime> catalogDateTable);
                registersList = catalogRegistersTable.Union(registersList).ToList();

                DateTime min = catalogDateTable.Select(model => model.Date).Min();
                dateList.Add(min);
            }
        }
    }
}
