using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        public static List<InfoRegistry> GetFill(int catalog_id, List<InfoCatalog> path)
        {
            try {
                List<InfoRegistry> registersTables = new List<InfoRegistry>();

                foreach (InfoCatalog c in path)
                {
                    GetExcelTableRead(c.Registry, catalog_id, out List <InfoRegistry> registersTable);
                    registersTables= registersTable.Union(registersTables).ToList();
                }
                return registersTables;
            }
            catch 
            { 
                return null; 
            }
        }
    }
}
