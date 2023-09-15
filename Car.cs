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

namespace AutoVuokraus
{
    public partial class Car : Form
    {
        public Car()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MSI\SQLEXJUSSIKI;Initial Catalog=CarRentaldb;Integrated Security=True");

        private void populate() // Hakee autot
        {
            Con.Open();
            string query = "select * from CarTbl";
            SqlDataAdapter da = new(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void FillAvailable() //Tuo ComboBoxiin Kaikkien vapaa olevien autojen RekNrot
        {
            Con.Open();
            string query = "select Available from CarTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Available", typeof(string));
            dt.Load(rdr);
            Search.ValueMember = "Available";
            Search.DataSource = dt;
            Con.Close();
        }

        private void button3_Click(object sender, EventArgs e) //Lisäysnappi
        {
            if (RegNumTb.Text == "" || BrandTb.Text == "" || ModelTb.Text == "" || PriceTb.Text == "" )
            {
                MessageBox.Show("Tieto puuttuu!");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Lisätään sql-lauseella käyttäjä tietokantaan
                    string query = "insert into CarTbl values('" + RegNumTb.Text + "','" + BrandTb.Text + "','" + ModelTb.Text + "','"+AvailableCb.SelectedItem.ToString()+"',"+PriceTb.Text+")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Auto lisätty!");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Car_Load(object sender, EventArgs e)//Hakee autot
        {
            populate();
            //FillAvailable();
        }

        private void button2_Click(object sender, EventArgs e) //Poistonappi
        {
            if (RegNumTb.Text == "")
            {
                MessageBox.Show("Rekisterinumero Puuttuu");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Sql-poistolauseella poistetaan tietokannasta
                    string query = "delete from CarTbl where RegNum='" + RegNumTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Auto poistettu!");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CarsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Tuo taulukosta tiedot textboxeihin
            RegNumTb.Text = CarsDGV.SelectedRows[0].Cells[0].Value.ToString();
            BrandTb.Text = CarsDGV.SelectedRows[0].Cells[1].Value.ToString();
            ModelTb.Text = CarsDGV.SelectedRows[0].Cells[2].Value.ToString();
            AvailableCb.SelectedItem = CarsDGV.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = CarsDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)//Muokkaanappi
        {
            if (RegNumTb.Text == "" || BrandTb.Text == "" || ModelTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Tieto puuttuu!");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Muokataan sql-lauseella tietokantaa
                    string query = "update CarTbl set Brand='" + BrandTb.Text + "', Model='" + ModelTb.Text + "', Available ='"+AvailableCb.SelectedItem.ToString()+"', Price="+PriceTb.Text+" where RegNum='" + RegNumTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Autoa muokattu!");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) //Palaa etusivulle
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button5_Click(object sender, EventArgs e) //Päivitysnappi
        {
            populate();
        }

        private void Search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Näyttää listalta vapaat ja varatut autot erikseen
            string flag;
            if (Search.SelectedItem.ToString() == "Vapaana")
            {
                flag = "Kyllä";
            }
            else
            {
                flag = "Ei";
            }
            Con.Open();
            string query = "select * from CarTbl where Available = '"+flag+"'";
            SqlDataAdapter da = new(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
