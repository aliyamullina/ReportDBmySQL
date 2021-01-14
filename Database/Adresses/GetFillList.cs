using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ReportDBmySQL
{
    public partial class Adresses
    {
        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию AddressInfo
        /// </summary>
        public static void GetFillList(in List<InfoCatalog> oneCatalogPath, out List<InfoAddress> addressesList)
        {
            addressesList = new List<InfoAddress>();
            int city_id = 1;

            foreach (InfoCatalog c in oneCatalogPath)
            {
                var pathTrim = c.Catalog.Substring(c.Catalog.LastIndexOf("\\")).Replace("\\", string.Empty);

                if (c.Catalog.Contains("часть")) 
                    pathTrim = c.Catalog.Remove(c.Catalog.Length - 7).Replace(@"\", "");

                var street = pathTrim.Substring(0, pathTrim.LastIndexOf(" ")).Replace(@"\", "");

                var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);

                addressesList.Add(new InfoAddress(street, home, city_id));
            }
        }
    }
}
