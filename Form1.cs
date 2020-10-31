using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var AdressInfo = getFolderAddressInfo();
            

            Application.Exit();
        }

        private static List<AddressInfo> getFolderAddressInfo()
        {
            List<AddressInfo> folderAdress = new List<AddressInfo>();

            FolderBrowserDialog folderDlg = new FolderBrowserDialog { ShowNewFolderButton = true };

            DialogResult dialog = folderDlg.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                string PathToFolder = folderDlg.SelectedPath;
                _ = folderDlg.RootFolder;

                string[] allfolders = Directory.GetDirectories(PathToFolder);

                string city = "1";
                string home = "1";
                
                foreach (var street in allfolders)
                {
                    folderAdress.Add(new AddressInfo(city, street, home));
                }
            }
            Console.WriteLine();
            return folderAdress;
            
        }
        // Из папки в mysql
        // Из mysql в массив
        // Mассив передать в макет word с адресом в имени
    }
}
