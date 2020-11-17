using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public class ExcelUtility
    {
        public static void ExtractCategoriesCompanies(string northwinddataXlsx, out List<RegistryInfo> registersList)
        {
            registersList = new List<RegistryInfo>();
            const int coCategoryId = 1;
            const int coCategoryName1 = 1;
            const int coCategoryName2 = 2;
            const int coCategoryName3 = 3;

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
                string apartment = categoryRow.Cell(coCategoryName1).GetString();
                string model = categoryRow.Cell(coCategoryName2).GetString();
                string serial = categoryRow.Cell(coCategoryName3).GetString();

                registersList.Add(new RegistryInfo(apartment, model, serial));

                categoryRow = categoryRow.RowBelow();
            }

            Console.WriteLine();
        }
    }
}