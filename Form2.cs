using System.Windows.Forms;

namespace ReportDBmySQL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            listView1.View = View.Details;

            listView1.Columns.Add("Address");
            listView1.Columns.Add("Floor");
            listView1.Columns.Add("FlatsCount");
            listView1.Columns.Add("Entrance");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        private void button2_Click(object sender, System.EventArgs e)
        {

        }
    }
}
