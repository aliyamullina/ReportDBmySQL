using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Adresses
    {
        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию AddressInfo
        /// </summary>
        public static void GetFill(ref List<InfoAddress> addressesList, int catalog_id, ref List<InfoCatalog> oneCatalogPath)
        {
            int city_id = 1;

            foreach (InfoCatalog c in oneCatalogPath)
            {
                var pathTrim = c.Catalog.Substring(c.Catalog.LastIndexOf("\\")).Replace("\\", string.Empty);
                var street = pathTrim.Substring(0, pathTrim.LastIndexOf(" "));
                var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);

                addressesList.Add(new InfoAddress(street, home, city_id, catalog_id));
            }
        }
    }
}
