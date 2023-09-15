using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoVuokraus
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) // Autot
        {
            this.Hide();
            Car car = new Car();
            car.Show();
        }

        private void button2_Click(object sender, EventArgs e) // Asiakkaat
        {
            this.Hide();
            Customer cust = new Customer();
            cust.Show();
        }

        private void button3_Click(object sender, EventArgs e) // Vuokraukset
        {
            this.Hide();
            Rental rent = new Rental();
            rent.Show();
        }

        private void button4_Click(object sender, EventArgs e) // Palautukset
        {
            this.Hide();
            Return ret = new Return();
            ret.Show();
        }

        private void button5_Click(object sender, EventArgs e) // Käyttäjät
        {
            this.Hide();
            Users users = new Users();
            users.Show();
        }

        private void button7_Click(object sender, EventArgs e) // Info
        {
            this.Hide();
            DashBoard dashB = new DashBoard();
            dashB.Show();
        }

        private void button6_Click(object sender, EventArgs e) //Logout Nappi
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
