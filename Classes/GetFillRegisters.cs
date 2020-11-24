using ClosedXML.Excel;
using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public partial class GetFill
    {
        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        public static List<InfoRegistry> GetFillRegisters(DB db)
        {
            try {
                List<InfoCatalog> path = db.GetCatalogList();
                List<InfoRegistry> registersTables = new List<InfoRegistry>();
                foreach (InfoCatalog c in path)
                {
                    var catalog_id = db.GetCatalogId(c.Catalog);
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

        /// <summary>
        /// Читает данные из Excel
        /// </summary>
        public static List<InfoRegistry> GetExcelTableRead(string pathRegistry, int catalog_id, out List<InfoRegistry> registersList)
        {
            registersList = new List<InfoRegistry>();

            try
            {
                using (XLWorkbook wb = new XLWorkbook(pathRegistry))
                {
                    var ws = wb.Worksheet(1);
                    var rows = ws.RangeUsed().RowsUsed().Skip(5);
                    //int catalog_id = 0;

                    foreach (var row in rows)
                    {
                        //catalog_id++;
                        string apartment = row.Cell(1).Value.ToString();
                        string model = row.Cell(2).Value.ToString();
                        string serial = row.Cell(3).Value.ToString();

                        registersList.Add(new InfoRegistry(catalog_id, apartment, model, serial));
                    }
                }
                return registersList;
            }
            catch
            {
                return null;
            }
        }
    }
}
