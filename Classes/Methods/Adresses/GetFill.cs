using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Adresses
    {
        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию AddressInfo
        /// </summary>
        public static List<InfoAddress> GetFill(int catalog_id, List<InfoCatalog> path)
        {
            try
            {
                List<InfoAddress> folderAdress = new List<InfoAddress>();
                int city_id = 4;

                foreach (InfoCatalog c in path)
                {
                    var pathTrim = c.Catalog.Substring(c.Catalog.LastIndexOf("\\")).Replace("\\", string.Empty);
                    var street = pathTrim.Substring(0, pathTrim.LastIndexOf(" "));
                    var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);
                    folderAdress.Add(new InfoAddress(street, home, city_id, catalog_id));
                }
                return folderAdress;
            }
            catch
            {
                return null;
            }
        }
    }
}
