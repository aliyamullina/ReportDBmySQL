﻿using System;
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

            List<InfoRegistry> registersListTable = new List<InfoRegistry>();

            List<InfoRegistry> Register = (from InfoCatalog c in path
                                           let a = GetExcelTableRead(c.Registry, out registersListTable)
                                           select new InfoRegistry()
                                           {
                                               //Apartment = a,
                                               //Model = m,
                                               //Serial = s,
                                           }).ToList<InfoRegistry>();;

            return Register;
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
