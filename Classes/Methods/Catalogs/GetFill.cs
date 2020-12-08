using System;
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
        public static List<InfoCatalog> GetFill(bool withoutReportsSearch)
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
                    // в cI передать папки без отчета ППО
                    if (withoutReportsSearch == true)
                    {
                        string[] filesReports = new DirectoryInfo(catalog)
                            .GetFiles("Отчет" + "*.docx", SearchOption.AllDirectories)
                            .Select(f => f.FullName)
                            .ToArray();
                        
                        Console.WriteLine();
                    }
                    // в cI передать папки c отчетом ППО
                    else
                    {
                        string[] files = new DirectoryInfo(catalog).GetFiles("Реестр" + "*.xlsx", SearchOption.AllDirectories).Select(f => f.FullName).ToArray();
                        foreach (string registry in files)
                        {
                            catalogsInsert.Add(new InfoCatalog(open, catalog, registry));
                        }
                    }
                }
            }
            return catalogsInsert;
        }
    }
}
