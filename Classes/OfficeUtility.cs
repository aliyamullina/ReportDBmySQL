using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    /// <summary>
    /// Работа с офисными документами: чтение
    /// </summary>
    public class OfficeUtility
    {
        public static List<InfoRegistry> GetExcelTableRead(string northwinddataXlsx, out List<InfoRegistry> registersList)
        {
            registersList = new List<InfoRegistry>();

            try
            {
                using (XLWorkbook wb = new XLWorkbook(northwinddataXlsx)) { 
                    var ws = wb.Worksheet(1);

                    var rows = ws.RangeUsed().RowsUsed().Skip(5);

                    foreach (var row in rows)
                    {

                        string apartment = row.Cell(1).Value.ToString();
                        string model = row.Cell(2).Value.ToString();
                        string serial = row.Cell(3).Value.ToString();

                        registersList.Add(new InfoRegistry(apartment, model, serial));
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