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
using System.Media;
using System.Threading;

namespace AutoVuokraus
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            WrongLbl.Hide();
        }
        // Ottaa yhteyden SQL-tietokantaan
        SqlConnection Con = new SqlConnection(@"Data Source=MSI\SQLEXJUSSIKI;Initial Catalog=CarRentaldb;Integrated Security=True");


        private void button2_Click(object sender, EventArgs e) //Tyhjennänappi
        {
            Uname.Text = "";
            PassTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) //Kirjautumisnappi
        {
            string query = "select count (*) from UserTbl where Uname='" + Uname.Text + "' and Upass='" + PassTb.Text + "'";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MainForm mainform = new MainForm();
                mainform.Show();
                this.Hide();
            }
            else
            {
                WrongLbl.Show();
                Uname.Text = "";
                PassTb.Text = "";

                SystemSounds.Exclamation.Play(); //Antaa äänimerkin, jos antaa väärät tiedot

                for (int i = 0; i < 5; i++) // Sovellus tärisee hieman, jos antaa väärät tiedot
                {
                    this.Left += 10;
                    System.Threading.Thread.Sleep(75);
                    this.Left -= 10;
                    System.Threading.Thread.Sleep(75);
                }
            }
            Con.Close();
        }

        private void label4_Click(object sender, EventArgs e) //Sulkee sovelluksen
        {
            Application.Exit();
        }

        private void label12_Click(object sender, EventArgs e) //Piilottaa sovelluksen
        {
            this.Hide();
        }

    }
}
