using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Возвращает все адреса из БД: City, Street, Home
        /// </summary>
        public static void GetXMLFindList(ref List<InfoMap> nodeList)
        {
            foreach(InfoMap i in nodeList)
            {
                _ = i.Address;
            }
        }
    }
}
