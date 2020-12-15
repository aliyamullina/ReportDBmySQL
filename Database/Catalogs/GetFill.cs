using MySql.Data.MySqlClient;
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
        public static void GetFill(ref List<InfoCatalog> сatalogsList, bool withoutReportsSearch, MySqlConnection connection)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog() { 
                ShowNewFolderButton = false,
                SelectedPath = @"Z:\Выполнение ТЭСБ 2020\для ранифа\сдаем без успд и с УСПД подписанные акты"
            };

            DialogResult dialog = folderDlg.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                var open = folderDlg.SelectedPath;
                // Общий список папок
                string[] cI = Directory.GetDirectories(open);

                Cities.GetFill(open, connection);

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
                            GetRegistryDirectory(сatalogsList, catalog);
                        }
                    }
                    else
                    {
                        GetRegistryDirectory(сatalogsList, catalog);
                    }
                }
            }
        }

        private static void GetRegistryDirectory(List<InfoCatalog> сatalogsPath, string catalog)
        {
            string[] files = new DirectoryInfo(catalog).GetFiles("Реестр" + "*.xlsx", SearchOption.AllDirectories).Select(f => f.FullName).ToArray();
            foreach (string registry in files)
            {
                сatalogsPath.Add(new InfoCatalog(catalog, registry));
            }
        }
    }
}
