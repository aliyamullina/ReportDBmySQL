using System;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class GetFill
    {
        /// <summary>
        /// Берет данные из массива и передает в коллекцию
        /// </summary>
        public static List<InfoRegistry> GetFillRegisters()
        {
            DB DBObject = new DB();
            List<InfoCatalog> path = DBObject.GetCatalogList();
            List<InfoRegistry> registersListTable = new List<InfoRegistry>();

            foreach (InfoCatalog c in path)
            {
                OfficeUtility.GetExcelTableRead(c.Registry, out registersListTable);
                Console.WriteLine();
            }
            Console.WriteLine();
            return registersListTable;
        }
    }
}
