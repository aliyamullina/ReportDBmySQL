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
                // Общий список папок
                string[] cI = Directory.GetDirectories(open);


                // в cI передать папки без отчета ППО
                if (withoutReportsSearch == true)
                {
                    foreach (var catalog in cI)
                    {
                        // Проверка на ППО
                        var filesReports = new DirectoryInfo(catalog).GetFiles("Отчет" + "*.docx", SearchOption.AllDirectories).Any(f => f.Exists);

                        if (filesReports == false)
                        {
                            string[] files = new DirectoryInfo(catalog).GetFiles("Реестр" + "*.xlsx", SearchOption.AllDirectories).Select(f => f.FullName).ToArray();
                            foreach (string registry in files)
                            {
                                catalogsInsert.Add(new InfoCatalog(open, catalog, registry));
                            }
                        }
                    }
                }
                // в cI передать папки c отчетом ППО
                else
                {
                    foreach (var catalog in cI)
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
