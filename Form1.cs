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
            //GetFolderName();

            Application.Exit();
        }

        //public void GetFolderName()
        private static List<AddressInfo> ParseFolderName(string text)
        {
            List<AddressInfo> addresses = new List<AddressInfo>();
            

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            DialogResult dialog = folderDlg.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                string PathToFolder = folderDlg.SelectedPath;
                _ = folderDlg.RootFolder;

                string[] allfolders = Directory.GetDirectories(PathToFolder);

                foreach (var street in allfolders)
                {
                    


                    addresses.Add(new AddressInfo(city, street, home));
                }
            }

            return addresses;
        }
    }
}
