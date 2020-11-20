using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class GetFill
    {
        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию AddressInfo
        /// </summary>
        public static List<InfoAddress> GetFillAddresses()
        {
            DB DBObject = new DB();
            List<InfoCatalog> path = DBObject.GetCatalogList();
            List<InfoAddress> folderAdress = new List<InfoAddress>();
            int city_id = 5;
            int catalog_id = 0;
            int registeraddress_id = 0;

            foreach (InfoCatalog c in path)
            {
                var pathTrim = c.Catalog.Substring(c.Catalog.LastIndexOf("\\")).Replace("\\", string.Empty);
                var street = pathTrim.Substring(0, pathTrim.LastIndexOf(" "));
                var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);
                catalog_id++;
                registeraddress_id++;
                folderAdress.Add(new InfoAddress(street, home, city_id, catalog_id, registeraddress_id));
            }
            return folderAdress;
        }
    }
}
