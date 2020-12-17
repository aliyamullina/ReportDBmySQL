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
        public static void GetFillList(out List<InfoCatalog> сatalogsList, in bool withoutReportsSearch, MySqlConnection connection)
        {
            сatalogsList = new List<InfoCatalog>();

            FolderBrowserDialog folderDlg = new FolderBrowserDialog() { 
                ShowNewFolderButton = false,
                SelectedPath = @"Z:\Выполнение ТЭСБ 2020\для ранифа\сдаем без успд и с УСПД подписанные акты"
            };

            DialogResult dialog = folderDlg.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                var openFolder = folderDlg.SelectedPath;

                Cities.GetFillList(in openFolder, out List<InfoCity> citiesList);
                Cities.GetInsertList(in citiesList, connection);

                // Список папок из выбранной папки
                string[] catalogsArray = Directory.GetDirectories(openFolder);

                foreach (var catalog in catalogsArray)
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
                            GetRegistryDirectory(ref сatalogsList, catalog);
                        }
                    }
                    else
                    {
                        GetRegistryDirectory(ref сatalogsList, catalog);
                    }
                }
            }
        }

        public static void GetRegistryDirectory(ref List<InfoCatalog> сatalogsList, string catalog)
        {
            string[] files = new DirectoryInfo(catalog).GetFiles("Реестр" + "*.xlsx", SearchOption.AllDirectories).Select(f => f.FullName).ToArray();
            foreach (string registry in files)
            {
                сatalogsList.Add(new InfoCatalog(catalog, registry));
            }
        }
    }
}
