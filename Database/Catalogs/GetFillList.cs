using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Catalogs
    {
        /// <summary>
        /// Папка с папками, передает пути в коллекцию CatalogInfo
        /// </summary>
        public static void GetFillList
        (
            in bool withoutReportsSearch, 
            out List<InfoCatalog> сatalogsList, 
            out List<InfoCatalog> сatalogsListLater, 
            out string open
        )
        {
            open = null;
            сatalogsList = new List<InfoCatalog>();
            сatalogsListLater = new List<InfoCatalog>();

            FolderBrowserDialog folderDlg = new FolderBrowserDialog() { 
                ShowNewFolderButton = false,
                SelectedPath = @"Z:\Выполнение ТЭСБ 2020\для ранифа\сдаем без успд и с УСПД подписанные акты"
            };

            DialogResult dialog = folderDlg.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                open = folderDlg.SelectedPath;

                // Список папок, подпапок из выбранной папки
                string[] catalogsArray = Directory.GetDirectories(open, "*", SearchOption.AllDirectories).ToArray();

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
                            GetRegistryDirectory(ref сatalogsList, ref сatalogsListLater, catalog, in open);
                        }
                    }
                    else
                    {
                        GetRegistryDirectory(ref сatalogsList, ref сatalogsListLater, catalog, in open);
                    }
                }
            }
        }

        public static void GetRegistryDirectory(ref List<InfoCatalog> сatalogsList, ref List<InfoCatalog> сatalogsListLater, string catalog, in string open)
        {
            string registry = new DirectoryInfo(catalog).GetFiles("Реестр" + "*.xlsx", SearchOption.TopDirectoryOnly).Select(f => f.FullName).FirstOrDefault();

            if (registry == null)
            {
                сatalogsListLater.Add(new InfoCatalog(open, catalog, null));
            } else
            {
                registry = registry.Replace(catalog, "");
                catalog = catalog.Replace(open, "");

                сatalogsList.Add(new InfoCatalog(open, catalog, registry));
            }
        }
    }
}
