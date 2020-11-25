﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReportDBmySQL
{
    public partial class GetCreateDoc
    {
        /// <summary>
        /// Заполнение заголовков таблицы
        /// </summary>
        private static void GetFillTableHead(Table table)
        {
            TableGrid tr = new TableGrid(new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn(), new GridColumn());
            table.AppendChild(tr);

            TableRow headerRow = new TableRow();
            TableCell headerTdCount = new TableCell(new Paragraph(new Run(new Text("№ П/П"))));
            TableCell headerTdCity = new TableCell(new Paragraph(new Run(new Text("Нас. пункт"))));
            TableCell headerTdStreet = new TableCell(new Paragraph(new Run(new Text("Улица"))));
            TableCell headerTdHome = new TableCell(new Paragraph(new Run(new Text("Дом"))));
            TableCell headerTdApartment = new TableCell(new Paragraph(new Run(new Text("Кв."))));
            TableCell headerTdModel = new TableCell(new Paragraph(new Run(new Text("Тип ПУ"))));
            TableCell headerTdSerial = new TableCell(new Paragraph(new Run(new Text("№ ПУ"))));
            TableCell headerTdComment = new TableCell(new Paragraph(new Run(new Text("Комментарии"))));
            headerRow.Append(headerTdCount, headerTdCity, headerTdStreet, headerTdHome, headerTdApartment, headerTdModel, headerTdSerial, headerTdComment);
            table.AppendChild(headerRow);
        }
    }
}
