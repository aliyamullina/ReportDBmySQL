using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Получимть имена папок
        private void button1_Click(object sender, System.EventArgs e)
        {
            List<AddressInfo> addresses = new List<AddressInfo>();


            //addresses.AddRange(System.IO.Directory.)
        }

        public string[] GetFolderName(ref string[] allfolders)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                string PathToFolder = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;

                _ = Directory.GetDirectories(PathToFolder);
            }
            return allfolders;
        }

    }
}
