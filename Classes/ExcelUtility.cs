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
            const int coCategoryId = 1;

            const int apartmentRow = 1;
            const int modelRow = 2;
            const int serialRow = 3;

            var wb = new XLWorkbook(northwinddataXlsx);
            var ws = wb.Worksheet("Лист1");

            // Найдите первую использованную строку
            var firstRowUsed = ws.FirstRowUsed();

            // Сузьте строку, чтобы она включала только использованную часть
            var categoryRow = firstRowUsed.RowUsed();

            // Перейти к следующей строке (теперь в ней есть заголовки)
            categoryRow = categoryRow.RowBelow();

            // Get all categories
            while (!categoryRow.Cell(coCategoryId).IsEmpty())
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