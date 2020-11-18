using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public class ExcelUtility
    {
        public static List<RegistryInfo> GetExcelTableRead(string northwinddataXlsx, out List<RegistryInfo> registersList)
        {
            registersList = new List<RegistryInfo>();

            try
            {
                using (XLWorkbook wb = new XLWorkbook(northwinddataXlsx)) { 
                    var ws = wb.Worksheet(1);

                    var rows = ws.RangeUsed().RowsUsed().Skip(6);

                    foreach (var row in rows)
                    {

                        string apartment = row.Cell(1).Value.ToString();
                        string model = row.Cell(2).Value.ToString();
                        string serial = row.Cell(3).Value.ToString();

                        registersList.Add(new RegistryInfo(apartment, model, serial));
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