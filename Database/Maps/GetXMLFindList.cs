using System.Collections.Generic;
using System.Xml;

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

                _ = i.Entrance;
                _ = i.FlatsCount;
                _ = i.Floor;
            
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"C:\Users\User1_106\Desktop\Github\ReportDBmySQL\Database\Maps\maps.xml");

                // получим корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;

                //обход всех узлов в корневом элементе
                foreach (XmlNode xNode in xRoot)
                {
                    //получаем атрибут name
                    if (xNode.Attributes.Count > 0) { 
                        XmlNode attr = xNode.Attributes.GetNamedItem("name");
                        _ = attr.Value;
                    }
                    
                    foreach(XmlNode childnode in xNode.ChildNodes)
                    {
                        if (childnode.Name== "floor") { _=childnode.InnerText; }
                        if (childnode.Name== "flatscount") { _=childnode.InnerText; }
                        if (childnode.Name== "entrance") { _=childnode.InnerText; }
                    }

                }
            }
        }
    }
}