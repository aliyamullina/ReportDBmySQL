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

                    string date = row.Cell(10).Value.ToString();
                    var dateFromString = DateTime.ParseExact(date, "yy/MM/dd", CultureInfo.InvariantCulture);

                    catalogRegistersTable.Add(new InfoRegistry(catalog_id, apartment, model, serial));


                    //catalogDatesTable.Add(new DateTime(dateFromString));

                    //https://github.com/closedxml/closedxml/wiki
                    //https://www.c-sharpcorner.com/UploadFile/mahesh/working-with-datetime-using-C-Sharp/
                    //https://ru.stackoverflow.com/questions/916415/%D0%91%D0%BB%D0%B8%D0%B6%D0%B0%D0%B9%D1%88%D0%B5%D0%B5-%D0%B7%D0%BD%D0%B0%D1%87%D0%B5%D0%BD%D0%B8%D0%B5-listdatetime-%D1%87%D0%B5%D1%80%D0%B5%D0%B7-linq
                }
            }
        }
    }
}
