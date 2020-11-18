using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public class ExcelUtility
    {
        public static void GetExcelTableRead(string northwinddataXlsx, out List<RegistryInfo> registersList)
        {
            registersList = new List<RegistryInfo>();

            const int apartmentRow = 1;
            const int modelRow = 2;
            const int serialRow = 3;

            var wb = new XLWorkbook(northwinddataXlsx);
            var ws = wb.Worksheet(1);

            var firstRowUsed = ws.FirstRowUsed();
            var categoryRow = firstRowUsed.RowUsed();

            categoryRow = categoryRow.RowBelow();

            var rngHeaders = ws.Range("A7:J7");
            //categoryRow = (IXLRangeRow)ws.Range("A7:J7");

            if (categoryRow.RowNumber() < 7)
            {
                var cell = categoryRow.Cell(3).Value;
            }

            var rows = ws.RangeUsed().RowsUsed().Skip(7); // Skip header row
            foreach (var row in rows)
            {
                var rowNumber = row.RowNumber();
                // Process the row
                Console.WriteLine(rowNumber);
            }
            

            while (!categoryRow.Cell(1).IsEmpty())
            {
                string apartment = categoryRow.Cell(apartmentRow).GetString();
                string model = categoryRow.Cell(modelRow).GetString();
                string serial = categoryRow.Cell(serialRow).GetString();

                registersList.Add(new RegistryInfo(apartment, model, serial));

                categoryRow = categoryRow.RowBelow();
                
            }

            var firstTableCell = ws.FirstCellUsed();
            var lastTableCell = ws.LastCellUsed();
            var rngData = ws.Range(firstTableCell.Address, lastTableCell.Address);
            string address = ws.Cell("C3").GetString();

            Console.WriteLine();
        }
    }
}