using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class DB
    {
        /// <summary>
        /// Возвращает каталог для текущего адреса в БД
        /// </summary>
        public List<InfoDocumentCatalog> GetDocCatalog(string address)
        {
            List<InfoDocumentCatalog> documentCatalog = new List<InfoDocumentCatalog>();

            using (MySqlCommand command = new MySqlCommand(@"
                SELECT 
                    catalogs.catalog
                FROM 
                    addresses,
                    catalogs,
                    cities
                WHERE CONCAT(City, ', ',Street, ' ' ,Home) LIKE @address
                AND 
                    addresses.Catalog_id = catalogs.Catalog_Id
                AND
                    addresses.City_id = cities.City_Id

                ", connection))
            {
                connection.Open();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@address", "%" + address + "%");
                command.ExecuteNonQuery();

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        InfoDocumentCatalog documentCatalogList = new InfoDocumentCatalog();

                        documentCatalogList.Catalog += dataReader["Catalog"].ToString();
                        documentCatalog.Add(documentCatalogList);
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            return documentCatalog;
        }
    }
}
