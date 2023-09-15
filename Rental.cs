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
using System.Globalization;

namespace AutoVuokraus
{
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
            RentDate.Format = DateTimePickerFormat.Custom;
            RentDate.CustomFormat = "dd.MM.yyyy";
            ReturnDate.Format = DateTimePickerFormat.Custom;
            ReturnDate.CustomFormat = "dd.MM.yyyy";
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MSI\SQLEXJUSSIKI;Initial Catalog=CarRentaldb;Integrated Security=True");

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

        private void Fillcombo() //Tuo ComboBoxiin Kaikkien Autojen RekNrot
        {
            Con.Open();
            //Poistaa comboboxista vuokratun auton
            string query = "select RegNum from CarTbl where Available='"+"Kyllä"+"'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum",typeof(string));
            dt.Load(rdr);
            CarRegCb.ValueMember = "RegNum";
            CarRegCb.DataSource = dt;
            Con.Close();
        }

        private void FillCustomer() //Tuo ComboBoxiin Asiakkaat
        {
            Con.Open();
            string query = "select CustId from CustomerTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(string));
            dt.Load(rdr);
            CustCb.ValueMember = "CustId";
            CustCb.DataSource = dt;
            Con.Close();
        }

        private void FetchCustName() // Valitun ID:n perusteella tuo oikean nimen
        {
            Con.Open();
            string query = "select * from CustomerTbl where CustId="+CustCb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            Con.Close();
        }

        private void UpdateRent()
        {
            Con.Open();
            //Muokataan sql-lauseella tietokantaa
            string query = "update CarTbl set Available='" + "Ei" + "' where RegNum='" + CarRegCb.SelectedValue.ToString() + "';"; 
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
        }

        private void UpdateRentDelete()
        {
            Con.Open();
            //Muokataan sql-lauseella tietokantaa ja tuodaan auto saataville
            string query = "update CarTbl set Available='" + "Kyllä" + "' where RegNum='" + CarRegCb.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
        }

        private void Rental_Load(object sender, EventArgs e)
        {
            Fillcombo();
            FillCustomer();
            populate();
        }

        private void CarRegCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void CustCb_SelectionChangeCommitted(object sender, EventArgs e) //Kun on valittu, tuo oikean nimen textboxiin
        {
            FetchCustName();
        }

        private void label4_Click(object sender, EventArgs e) //Sulkee sovelluksen
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e) //Palaa Etusivulle
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e) //LisäysNappi
        {
            if (IdTb.Text == "" || CustNameTb.Text == "" || FeesTb.Text == "" || RegNro.Text == "")
            {
                MessageBox.Show("Tieto puuttuu!");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Lisätään sql-lauseella vuokraus tietokantaan
                    string query = "insert into RentalTbl values(" + IdTb.Text + ",'" + CarRegCb.SelectedValue.ToString() + "','" + CustNameTb.Text + "','" + RentDate.Text + "','" + ReturnDate.Text+"','"+FeesTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Uusi vuokraus lisätty!");
                    Con.Close();
                    UpdateRent();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //Poistonappi
        {
            if(IdTb.Text == "")
            {
                MessageBox.Show("Vuokrauksen ID Puuttuu");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Sql-poistolauseella poistetaan tietokannasta
                    string query = "delete from RentalTbl where RentId=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vuokraus poistettu!");
                    Con.Close();
                    populate();
                    UpdateRentDelete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Tuo taulukosta tiedot textboxeihin, (Paitsi ID:tä klikkaamalla?)
            IdTb.Text = RentDGV.SelectedRows[0].Cells[0].Value.ToString();
            CarRegCb.SelectedValue = RentDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = RentDGV.SelectedRows[0].Cells[2].Value.ToString();
            RentDate.Text = RentDGV.SelectedRows[0].Cells[3].Value.ToString();
            RentDate.Text = RentDate.Value.ToLocalTime().ToString();
            ReturnDate.Text = RentDGV.SelectedRows[0].Cells[4].Value.ToString();
            FeesTb.Text = RentDGV.SelectedRows[0].Cells[5].Value.ToString();
        }


        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
