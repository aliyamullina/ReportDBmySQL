﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ReportDBmySQL
{
    public partial class ExcelTables
    {
        /// <summary>
        /// Настройки свойств для таблицы
        /// </summary>
        public static void CreateProperties(Table table)
        {
            TableProperties props = new TableProperties(
                            new TableBorders
                            (
                                new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 },
                                new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 },
                                new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 },
                                new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 },
                                new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 },
                                new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 1 }
                            )
                        );

            TableStyle tableStyle = new TableStyle() { Val = "TableGrid" };

            TableWidth tableWidth = new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct };

            props.Append(tableStyle, tableWidth);

            table.AppendChild(props);
        }
    }
}
