using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Заполнение содержимого таблицы
        /// </summary>
        private static void GetFillTableBody(Table table, string fN, MySqlConnection connection)
        {
            List<InfoDocumentTable> fileTable = GetInfoDocumentTable(fN, connection);

            string comment = "В 2020 году истекает срок поверки. Требуется замена";

            int count = 1;

            foreach (InfoDocumentTable iT in fileTable)
            {
                TableRow bodyRow = new TableRow();
                TableCell bodyTdCount = new TableCell(new Paragraph(new Run(new Text(count++.ToString()))));
                TableCell bodyTdCity = new TableCell(new Paragraph(new Run(new Text(iT.City))));
                TableCell bodyTdStreet = new TableCell(new Paragraph(new Run(new Text(iT.Street))));
                TableCell bodyTdHome = new TableCell(new Paragraph(new Run(new Text(iT.Home))));
                TableCell bodyTdApartment = new TableCell(new Paragraph(new Run(new Text(iT.Apartment))));
                TableCell bodyTdModel = new TableCell(new Paragraph(new Run(new Text(iT.Model))));
                TableCell bodyTdSerial = new TableCell(new Paragraph(new Run(new Text(iT.Serial))));
                TableCell bodyTdComment = new TableCell(new Paragraph(new Run(new Text(comment))));
                bodyRow.Append(bodyTdCount, bodyTdCity, bodyTdStreet, bodyTdHome, bodyTdApartment, bodyTdModel, bodyTdSerial, bodyTdComment);
                table.AppendChild(bodyRow);
            }
        }
    }
}
