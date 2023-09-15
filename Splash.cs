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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent(); 
            PriceLbl.Hide();      //Piilotetaan aluksi mainoslauseet
            ServiceLbl.Hide();
            NiceLbl.Hide();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            Myprogress.Value = startpoint;
            LoadLbl.Text = Myprogress.Value.ToString();
            if (Myprogress.Value == 100) // Kun progress 100, lataa login sivun
            {
                Myprogress.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            if (Myprogress.Value > 20 && Myprogress.Value < 40) //Mainoslauseet alkavat
            {
                PriceLbl.Show();
            }
            else // Ensimmäinen mainoslause poistuu
            {
                PriceLbl.Hide();
            }

            if (Myprogress.Value > 45 && Myprogress.Value < 65)
            {
                ServiceLbl.Show();
            }
            else
            {
                ServiceLbl.Hide();
            }

            if (Myprogress.Value > 70 && Myprogress.Value < 90)
            {
                NiceLbl.Show();
            }
            else
            {
                NiceLbl.Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e) // Käynnistyy kun ohjelma käynnistyy
        {
            timer1.Start(); 
        }
    }
}
