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

            FolderBrowserDialog folderDlg = new FolderBrowserDialog() { 
                ShowNewFolderButton = false,
                SelectedPath = @"Z:\Выполнение ТЭСБ 2020\для ранифа\сдаем без успд и с УСПД подписанные акты"
            };

            DialogResult dialog = folderDlg.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                string open = folderDlg.SelectedPath;
                // Общий список папок
                string[] cI = Directory.GetDirectories(open);

                foreach (var catalog in cI)
                {
                    // Найти без отчета ППО
                    if (withoutReportsSearch == true)
                    {
                        // Проверка на ППО
                        var filesReports = new DirectoryInfo(catalog).GetFiles("Отчет" + "*.docx", SearchOption.AllDirectories).Any(f => f.Exists);
                        
                        // Если нет отчета ППО
                        if (filesReports == false) 
                        {
                            Console.WriteLine(filesReports);
                            GetRegistryDirectory(catalogsInsert, catalog); 
                        }
                    }
                    else
                    {
                        GetRegistryDirectory(catalogsInsert, catalog);
                    }
                }              
            }
            return catalogsInsert;
        }

        private static void GetRegistryDirectory(List<InfoCatalog> catalogsInsert, string catalog)
        {
            string[] files = new DirectoryInfo(catalog).GetFiles("Реестр" + "*.xlsx", SearchOption.AllDirectories).Select(f => f.FullName).ToArray();
            foreach (string registry in files)
            {
                catalogsInsert.Add(new InfoCatalog(catalog, registry));
            }
        }
    }
}
