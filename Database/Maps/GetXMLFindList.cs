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

            string xmlEntrance = "";
            string xmlFlatsCount = "";
            string xmlFloor = "";

            foreach (InfoMap i in nodeList)
            {        
                foreach (XmlNode xNode in xRoot)
                {
                    if (xNode.Attributes.Count > 0)
                    {
                        XmlNode attr = xNode.Attributes.GetNamedItem("name");

                        if (i.Address == attr.Value)
                        {
                            foreach (XmlNode childnode in xNode.ChildNodes)
                            {
                                if (childnode.Name == "floor")
                                {
                                    xmlFloor = childnode.InnerText;
                                    nodeList.ForEach(x => x.Floor = x.Floor.Replace(i.Floor, xmlFloor));
                                }

                                if (childnode.Name == "flatscount")
                                {
                                    xmlFlatsCount = childnode.InnerText;
                                    nodeList.ForEach(x => x.FlatsCount = x.FlatsCount.Replace(i.FlatsCount, xmlFlatsCount));
                                }

                                if (childnode.Name == "entrance")
                                {
                                    xmlEntrance = childnode.InnerText;
                                    nodeList.ForEach(x => x.Entrance = x.Entrance.Replace(i.Entrance, xmlEntrance));
                                }

                                System.Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}