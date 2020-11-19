using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    class GetFillCatalog
    {
        /// <summary>
        /// Папка с папками, передает пути в коллекцию CatalogInfo
        /// </summary>
        public static List<InfoCatalog> Get()
        {
            List<InfoCatalog> catalogsInsert = new List<InfoCatalog>();
            FolderBrowserDialog folderDlg = new FolderBrowserDialog { ShowNewFolderButton = true };
            DialogResult dialog = folderDlg.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                string o = folderDlg.SelectedPath;

                string[] cI = Directory.GetDirectories(o);

                foreach (var c in cI)
                {
                    string[] files = new DirectoryInfo(c).GetFiles("Реестр" + "*.xlsx", SearchOption.AllDirectories).Select(f => f.FullName).ToArray();

                    foreach (string r in files)
                    {
                        catalogsInsert.Add(new InfoCatalog(o, c, r));
                    }
                }
            }
            return catalogsInsert;
        }
    }
}
