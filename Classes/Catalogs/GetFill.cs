using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Catalogs
    {
        /// <summary>
        /// Папка с папками, передает пути в коллекцию CatalogInfo
        /// </summary>
        public static List<InfoCatalog> GetFill()
        {
            List<InfoCatalog> catalogsInsert = new List<InfoCatalog>();
            FolderBrowserDialog folderDlg = new FolderBrowserDialog { ShowNewFolderButton = true };
            DialogResult dialog = folderDlg.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                string open = folderDlg.SelectedPath;

                string[] cI = Directory.GetDirectories(open);

                foreach (var catalog in cI)
                {
                    string[] files = new DirectoryInfo(catalog).GetFiles("Реестр" + "*.xlsx", SearchOption.AllDirectories).Select(f => f.FullName).ToArray();

                    foreach (string registry in files)
                    {
                        catalogsInsert.Add(new InfoCatalog(open, catalog, registry));
                    }
                }
            }
            return catalogsInsert;
        }
    }
}
