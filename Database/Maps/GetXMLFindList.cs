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
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\User1_106\Desktop\Github\ReportDBmySQL\Database\Maps\maps.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (InfoMap i in nodeList)
            {        
                foreach (XmlNode xNode in xRoot)
                {
                    XmlNode attr = xNode.Attributes.GetNamedItem("name");

                    if(i.Address == attr.Value)
                    {
                        foreach (XmlNode childnode in xNode.ChildNodes)
                        {
                            if (childnode.Name == "floor") { _ = childnode.InnerText; }
                            if (childnode.Name == "flatscount") { _ = childnode.InnerText; }
                            if (childnode.Name == "entrance") { _ = childnode.InnerText; }

                            _ = i.Entrance;
                            _ = i.FlatsCount;
                            _ = i.Floor;
                        }
                    }
                }
            }
        }
    }
}