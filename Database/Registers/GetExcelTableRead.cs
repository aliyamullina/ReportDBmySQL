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
        public static void GetExcelTableRead(in string pathRegistry, int catalog_id, out List<InfoRegistry> catalogRegistersTable, out List<DateTime> catalogDatesTable)
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

                    catalogRegistersTable.Add(new InfoRegistry(catalog_id, apartment, model, serial));

                    DateTime dateTime = row.Cell(10).GetDateTime();
                    string date = dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                    catalogDatesTable.Add(Convert.ToDateTime(date));
                }
            }
        }
    }
}
