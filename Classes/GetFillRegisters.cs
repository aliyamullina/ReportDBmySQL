using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using System.Linq;

namespace ReportDBmySQL
{
    public partial class GetFill
    {
        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        public static List<InfoRegistry> GetFillRegisters()
        {
            DB db = new DB();

            List<InfoCatalog> path = db.GetCatalogList();

            List<InfoRegistry> registersListTables = new List<InfoRegistry>();
            List<InfoRegistry> registersListTablesAll = new List<InfoRegistry>();

            foreach (InfoCatalog c in path)
            {
                //Татарстан 10
                //16  СО - ИБМЗ 11511

                //Татарстан 24
                //47  ЦЭ6807Б с150403
                //48  ЦЭ6807Б с151129

                //Татарстан 8
                //20  СО505   128862
                //24  СО505   129860
                //21  СО505   133023
                //2   СО - И4491 - 2  9044
                //4   СО - ИБМ1 91714
                //35  СО505   137298

                GetExcelTableRead(c.Registry, out registersListTables);

                registersListTablesAll.ForEach(p => registersListTables.Add(p));
            }

            return registersListTablesAll;
        }

        /// <summary>
        /// Читает данные из Excel
        /// </summary>
        /// <param name="northwinddataXlsx"></param>
        /// <param name="registersList"></param>
        /// <returns></returns>
        public static List<InfoRegistry> GetExcelTableRead(string northwinddataXlsx, out List<InfoRegistry> registersList)
        {
            registersList = new List<InfoRegistry>();

            try
            {
                using (XLWorkbook wb = new XLWorkbook(northwinddataXlsx))
                {
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
