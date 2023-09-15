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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        
        SqlConnection Con = new SqlConnection(@"Data Source=MSI\SQLEXJUSSIKI;Initial Catalog=CarRentaldb;Integrated Security=True");

        private void label4_Click(object sender, EventArgs e) //Sulkee sovelluksen
        {
            Application.Exit();
        }

        private void populate() // Hakee käyttäjät
        {
            Con.Open();
            string query = "select * from UserTbl";
            SqlDataAdapter da = new(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button3_Click(object sender, EventArgs e) //Lisäysnappi
        {
            if (Uid.Text == "" || Uname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Tieto puuttuu!");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Lisätään sql-lauseella käyttäjä tietokantaan
                    string query = "insert into UserTbl values("+Uid.Text+",'"+ Uname.Text+"','"+Upass.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Käyttäjä lisätty!");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e) // Poistonappi
        {
            if (Uid.Text == "")
            {
                MessageBox.Show("Käyttäjä ID Puuttuu");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Sql-poistolauseella poistetaan tietokannasta
                    string query = "delete from UserTbl where Id="+Uid.Text+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Käyttäjä poistettu!");
                    Con.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Tuo taulukosta tiedot textboxeihin, (Paitsi ID:tä klikkaamalla?)
            Uid.Text = UserDGV.SelectedRows[0].Cells[0].Value.ToString();
            Uname.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            Upass.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e) // Muokkausnappi
        {
            if (Uid.Text == "" || Uname.Text == "" || Upass.Text == "")
            {
                MessageBox.Show("Tieto puuttuu!");
            }
            else
            {
                try
                {
                    Con.Open();
                    //Muokataan sql-lauseella tietokantaa
                    string query = "update UserTbl set Uname='"+Uname.Text+"', Upass='"+Upass.Text+"' where Id="+Uid.Text+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Käyttäjää muokattu!");
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

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
