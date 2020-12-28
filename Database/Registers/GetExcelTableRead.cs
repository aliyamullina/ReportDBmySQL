using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace ReportDBmySQL
{
    public partial class Registers
    {
        /// <summary>
        /// Читает данные из Excel
        /// </summary>
        public static void GetExcelTableRead(string pathRegistry, int catalog_id, out List<InfoRegistry> catalogRegistersTable, out List<DateTime> catalogDatesTable)
        {
            catalogRegistersTable = new List<InfoRegistry>();
            catalogDatesTable = new List<DateTime>();

            using (XLWorkbook wb = new XLWorkbook(pathRegistry))
            {
                var ws = wb.Worksheet(1);
                var rows = ws.RangeUsed().RowsUsed().Skip(5);

                foreach (var row in rows)
                {
                    string apartment = row.Cell(1).Value.ToString();
                    string model = row.Cell(2).Value.ToString();
                    string serial = row.Cell(3).Value.ToString();

                    DateTime date = row.Cell(10).GetDateTime();

                    //DateTime date2 = row.Cell(10).GetValue<DateTime>();

                    catalogRegistersTable.Add(new InfoRegistry(catalog_id, apartment, model, serial));

                    catalogDatesTable.Add(date);
                }
            }
        }
    }
}
