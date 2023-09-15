using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace AutoVuokraus
{
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MSI\SQLEXJUSSIKI;Initial Catalog=CarRentaldb;Integrated Security=True");

        private void label4_Click(object sender, EventArgs e) //Sulkee sovelluksen
        {
            Application.Exit();
        }
        private void populate() // Hakee vuokraukset
        {
            Con.Open();
            string query = "select * from RentalTbl";
            SqlDataAdapter da = new(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void populateRet() // Hakee palautukset
        {
            Con.Open();
            string query = "select * from ReturnTbl";
            SqlDataAdapter da = new(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReturnDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void DeleteOnReturn()
        {
            int rentId;
            rentId = Convert.ToInt32(RentDGV.SelectedRows[0].Cells[0].Value.ToString());
            Con.Open();
            //Lisätään sql-lauseella vuokraus tietokantaan
            string query = "delete from RentalTbl where RentId=" + rentId + ";";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
            populate();
        }

        private void button4_Click(object sender, EventArgs e) //Palaa etusivulle
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Return_Load(object sender, EventArgs e) //Lataa molemmat taulukot
        {
            populate();
            populateRet();
        }

        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Lasketaan onko auto palautettu ajoissa
            CarIdTb.Text = RentDGV.SelectedRows[0].Cells[0].Value.ToString();
            CustNameTb.Text = RentDGV.SelectedRows[0].Cells[2].Value.ToString();
            ReturnDate.Text = RentDGV.SelectedRows[0].Cells[4].Value.ToString();
            DateTime d1 = ReturnDate.Value.ToLocalTime();
            DateTime d2 = DateTime.Now.ToLocalTime();
            TimeSpan t = d2 - d1;
            int NrOfDays = Convert.ToInt32(t.TotalDays);
            if (NrOfDays <= 0)
            {
                DelayTb.Text = "0";
                FineTb.Text = "0";
            }
            else
            {
                DelayTb.Text = NrOfDays.ToString();
                FineTb.Text = (NrOfDays * 150).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e) //Lisäysnappi
        {
            if (IdTb.Text == "" || CustNameTb.Text == "" || FineTb.Text == "" || DelayTb.Text == "")
            {
                MessageBox.Show("Tieto puuttuu!");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Lisätään sql-lauseella vuokraus tietokantaan
                    string query = "insert into ReturnTbl values(" + IdTb.Text + ",'" + CarIdTb.Text + "','" + CustNameTb.Text + "','" + ReturnDate.CustomFormat + "','" + DelayTb.Text + "','" + FineTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Uusi palautus lisätty!");
                    Con.Close();
                    //UpdateRent();
                    populateRet();
                    DeleteOnReturn();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
