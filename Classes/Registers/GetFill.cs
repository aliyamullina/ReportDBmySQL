using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        public static List<InfoRegistry> GetFill(MySqlConnection connection)
        {
            try {
                List<InfoCatalog> path = Catalogs.GetSelect(connection);
                List<InfoRegistry> registersTables = new List<InfoRegistry>();
                foreach (InfoCatalog c in path)
                {
                    //var catalog_id = db.GetCatalogId(c.Catalog);
                    int catalog_id = 1;
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
