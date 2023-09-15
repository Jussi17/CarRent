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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MSI\SQLEXJUSSIKI;Initial Catalog=CarRentaldb;Integrated Security=True");

        private void populate() // Hakee asiakkaat
        {
            Con.Open();
            string query = "select * from CustomerTbl";
            SqlDataAdapter da = new(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void label4_Click(object sender, EventArgs e) //Sulkee sovelluksen
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e) //Palaa etusivulle
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Customer_Load(object sender, EventArgs e) //Hakee asiakkaat
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e) //Lisäysnappi
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Tieto puuttuu!");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Lisätään sql-lauseella asiakas tietokantaan
                    string query = "insert into CustomerTbl values('" + IdTb.Text + "','" + NameTb.Text + "','" + AddressTb.Text + "','" + PhoneTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Asiakas lisätty!");
                    Con.Close();
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
            if (IdTb.Text == "")
            {
                MessageBox.Show("Asiakas ID Puuttuu");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Sql-poistolauseella poistetaan tietokannasta
                    string query = "delete from CustomerTbl where CustId='" + IdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Asiakas poistettu!");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Tuo taulukosta tiedot textboxeihin
            IdTb.Text = CustomerDGV.SelectedRows[0].Cells[0].Value.ToString();
            NameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            AddressTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e) //Muokkausnappi
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Tieto puuttuu!");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Muokataan sql-lauseella tietokantaa
                    string query = "update CustomerTbl set CustName='" + NameTb.Text + "', Custadd='" + AddressTb.Text + "', Phone ='" + PhoneTb.Text + "' where CustId=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Asiakasta muokattu!");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
