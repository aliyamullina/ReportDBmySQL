using System;
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
            GetFolderName();
        }

        public void GetFolderName()
        {

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                string PathToFolder = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;

                string[] allfolders = Directory.GetDirectories(PathToFolder);

                foreach (string folder in allfolders)
                {
                    Console.WriteLine();
                }

                // Передать массив string[] allfolders в AddressInfo

            }
        }

    }
}
