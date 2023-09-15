using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AutoVuokraus
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MSI\SQLEXJUSSIKI;Initial Catalog=CarRentaldb;Integrated Security=True");

        private void label4_Click(object sender, EventArgs e)//Sulkee sovelluksen
        {
            Application.Exit();
        }

        private void DashBoard_Load(object sender, EventArgs e) //Laskee lukumäärät
        {
            string quearycar = "select Count(*) from CarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(quearycar, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CarLbl.Text = dt.Rows[0][0].ToString();

            string quearycust = "select Count(*) from CustomerTbl";
            SqlDataAdapter sda1 = new SqlDataAdapter(quearycust, Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            CustLbl.Text = dt1.Rows[0][0].ToString();

            string quearyuser = "select Count(*) from UserTbl";
            SqlDataAdapter sda2 = new SqlDataAdapter(quearyuser, Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            UserLbl.Text = dt2.Rows[0][0].ToString();

            DateLbl.Text = DateTime.Now.ToString();
        }

        private void button4_Click(object sender, EventArgs e) //Palaa etusivulle
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
