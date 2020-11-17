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
            const int coCategoryName = 2;

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
                String categoryName = categoryRow.Cell(coCategoryName).GetString();
                registersList.Add(categoryName);

                categoryRow = categoryRow.RowBelow();
            }

            // Есть много способов получить таблицу компании. 
            // Здесь мы используем простой метод. 
            // Другой способ - найти первую строку в таблице компании 
            // с помощью цикла while row.IsEmpty ()

            // Первый возможный адрес таблицы компании:
            var firstPossibleAddress = ws.Row(categoryRow.RowNumber()).FirstCell().Address;
            // Последний возможный адрес таблицы компании:
            var lastPossibleAddress = ws.LastCellUsed().Address;

            // Получение диапазона с остатком данных рабочего листа (используемым диапазоном) 
            var companyRange = ws.Range(firstPossibleAddress, lastPossibleAddress).RangeUsed();

            // Обрабатывать диапазон как таблицу (чтобы можно было использовать имена столбцов)
            var companyTable = companyRange.AsTable();

            // Получение списка названий 
            //companies = companyTable.DataRange.Rows()
            //  .Select(companyRow => companyRow.Field("Company Name").GetString())
            //  .ToList();
            Console.WriteLine();
        }
    }
}