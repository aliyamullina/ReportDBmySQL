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

            List<InfoRegistry> registersListTable = new List<InfoRegistry>();

            //c# return list in foreach loop???
            //public IQueryable<StatusList> GetLocationStatus()
            //{
            //    var status = (from location in this.ObjectContext.Locations
            //                  where location.InspectionReadings.Status == value
            //                  orderby a.DateTaken
            //                  select new LocationStatusList()
            //                  {
            //                      ID = a.ID,
            //                      LocationName = d.Name,
            //                  }).ToList<StatusList>();
            //    return status;
            //}

            //https://overcoder.net/q/1065266/%D0%BD%D0%B5-%D1%83%D0%B4%D0%B0%D0%B5%D1%82%D1%81%D1%8F-%D0%BD%D0%B5%D1%8F%D0%B2%D0%BD%D0%BE-%D0%BF%D1%80%D0%B5%D0%BE%D0%B1%D1%80%D0%B0%D0%B7%D0%BE%D0%B2%D0%B0%D1%82%D1%8C-%D1%82%D0%B8%D0%BF-systemcollectionsgenericlist-lttgt-%D0%B2

            var Register = (from InfoCatalog c in path
                           let a = GetExcelTableRead(c.Registry, out registersListTable)
                           select new InfoRegistry()
                           {
                               Apartment = a,
                               Model = m,
                               Serial = s,
                           }).ToList<InfoRegistry>();;

            return (List<InfoRegistry>)Register;
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
