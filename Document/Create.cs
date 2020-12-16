using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ReportDBmySQL
{
    public partial class Document
    {
        /// <summary>
        /// Принимает путь до файла, редактирует его
        /// </summary>
        public static void Create(ref List<InfoDocument> documentsList, string documentTemplate, MySqlConnection connection)
        {
            foreach (InfoDocument info in documentsList)
            {
                var fN = info.Address;

                var fC = info.Catalog;

                string filePath = CopyTemplate(documentTemplate, fN, fC);

                GetFill(fN, filePath, connection);
            }
        }
    }
}
