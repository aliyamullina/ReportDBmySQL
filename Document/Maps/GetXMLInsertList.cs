using System.Collections.Generic;
using System.Xml;

namespace ReportDBmySQL
{
    public partial class Maps
    {
        /// <summary>
        /// Вносит данные адреса в XML файл
        /// </summary>
        public static void GetXMLInsertList(ref List<InfoMap> mapListInsert)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\User1_106\Desktop\Github\ReportDBmySQL\Database\Maps\maps.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (InfoMap i in mapListInsert)
            {
                XmlElement addressElement = xDoc.CreateElement("address");
                XmlAttribute nameAttribute = xDoc.CreateAttribute("name");

                XmlElement floorElement = xDoc.CreateElement("floor");
                XmlElement flatscounElement = xDoc.CreateElement("flatscount");
                XmlElement entranceElemement = xDoc.CreateElement("entrance");

                XmlText nameText = xDoc.CreateTextNode(i.Address);

                XmlText floorText = xDoc.CreateTextNode(i.Floor);
                XmlText flatscounText = xDoc.CreateTextNode(i.FlatsCount);
                XmlText entranceText = xDoc.CreateTextNode(i.Entrance);

            }
        }
    }
}
