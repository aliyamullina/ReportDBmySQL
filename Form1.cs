using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            GetFolderName();
        }

        public void GetFolderName()
        {
            List<AddressInfo> addresses = new List<AddressInfo>();
            

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                string PathToFolder = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;

                List<string> allfolders = (Directory.GetDirectories(PathToFolder)).ToList();
            }
            Console.WriteLine();
        }

    }
}
