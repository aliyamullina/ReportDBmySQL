using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportDBmySQL
{
    public partial class ExcelTables
    {
        /// <summary>
        /// Заполнение содержимого таблицы
        /// </summary>
        public static void GetFillTableBody(Table table, string fN, MySqlConnection connection)
        {
            List<InfoTable> tableBody = GetSelect(fN, connection);

            string comment = "В 2020 году истекает срок поверки. Требуется замена";
            string[] commentNope = { "Отсутствует", "отсутствует", "Дублер", "дублер" };

            int count = 1;

            foreach (InfoTable tableRow in tableBody)
            {
                TableRow bodyRow = new TableRow();
                TableCell bodyTdCount = new TableCell(new Paragraph(new Run(new Text(count++.ToString()))));
                TableCell bodyTdCity = new TableCell(new Paragraph(new Run(new Text(tableRow.City))));
                TableCell bodyTdStreet = new TableCell(new Paragraph(new Run(new Text(tableRow.Street))));
                TableCell bodyTdHome = new TableCell(new Paragraph(new Run(new Text(tableRow.Home))));
                TableCell bodyTdApartment = new TableCell(new Paragraph(new Run(new Text(tableRow.Apartment))));
                TableCell bodyTdModel = new TableCell(new Paragraph(new Run(new Text(tableRow.Model))));
                TableCell bodyTdSerial = new TableCell(new Paragraph(new Run(new Text(tableRow.Serial))));
                TableCell bodyTdComment;

                if (commentNope.Contains(tableRow.Model))
                {
                    bodyTdComment = new TableCell(new Paragraph(new Run(new Text(tableRow.Model))));
                }
                else 
                {
                    bodyTdComment = new TableCell(new Paragraph(new Run(new Text(comment))));
                }

                bodyRow.Append(bodyTdCount, bodyTdCity, bodyTdStreet, bodyTdHome, bodyTdApartment, bodyTdModel, bodyTdSerial, bodyTdComment);
                table.AppendChild(bodyRow);
            }
        }
    }
}
