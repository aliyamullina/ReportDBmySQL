﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Adresses
    {
        /// <summary>
        /// Берет названия папок, разделяет на улицу, дом и  передает в коллекцию AddressInfo
        /// </summary>
        public static List<InfoAddress> GetFill(MySqlConnection connection, int catalog_id)
        {
            List<InfoCatalog> path = Catalogs.GetSelect(connection);
            List<InfoAddress> folderAdress = new List<InfoAddress>();
            int city_id = 5;
            int id = GetID(catalog_id);

            foreach (InfoCatalog c in path)
            {
                var pathTrim = c.Catalog.Substring(c.Catalog.LastIndexOf("\\")).Replace("\\", string.Empty);
                var street = pathTrim.Substring(0, pathTrim.LastIndexOf(" "));
                var home = pathTrim.Substring(pathTrim.LastIndexOf(" ")).Replace(" ", string.Empty);
                id++;
                folderAdress.Add(new InfoAddress(street, home, city_id, id));
            }
            return folderAdress;
        }
    }
}