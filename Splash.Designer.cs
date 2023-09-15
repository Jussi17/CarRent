
namespace AutoVuokraus
{
    partial class Splash
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.Mycar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Myprogress = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LoadLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PriceLbl = new System.Windows.Forms.Label();
            this.ServiceLbl = new System.Windows.Forms.Label();
            this.NiceLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Mycar)).BeginInit();
            this.SuspendLayout();
            // 
            // Mycar
            // 
            this.Mycar.Image = ((System.Drawing.Image)(resources.GetObject("Mycar.Image")));
            this.Mycar.Location = new System.Drawing.Point(306, 102);
            this.Mycar.Name = "Mycar";
            this.Mycar.Size = new System.Drawing.Size(559, 271);
            this.Mycar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Mycar.TabIndex = 0;
            this.Mycar.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(284, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(609, 59);
            this.label1.TabIndex = 3;
            this.label1.Text = "Jussin Auto Vuokraamo";
            // 
            // Myprogress
            // 
            this.Myprogress.Location = new System.Drawing.Point(464, 453);
            this.Myprogress.Name = "Myprogress";
            this.Myprogress.Size = new System.Drawing.Size(232, 29);
            this.Myprogress.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LoadLbl
            // 
            this.LoadLbl.AutoSize = true;
            this.LoadLbl.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadLbl.Location = new System.Drawing.Point(702, 453);
            this.LoadLbl.Name = "LoadLbl";
            this.LoadLbl.Size = new System.Drawing.Size(27, 29);
            this.LoadLbl.TabIndex = 6;
            this.LoadLbl.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(735, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "%";
            // 
            // PriceLbl
            // 
            this.PriceLbl.AutoSize = true;
            this.PriceLbl.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.PriceLbl.Location = new System.Drawing.Point(25, 203);
            this.PriceLbl.Name = "PriceLbl";
            this.PriceLbl.Size = new System.Drawing.Size(261, 37);
            this.PriceLbl.TabIndex = 8;
            this.PriceLbl.Text = "Halvat hinnat!";
            // 
            // ServiceLbl
            // 
            this.ServiceLbl.AutoSize = true;
            this.ServiceLbl.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.ServiceLbl.Location = new System.Drawing.Point(744, 137);
            this.ServiceLbl.Name = "ServiceLbl";
            this.ServiceLbl.Size = new System.Drawing.Size(365, 37);
            this.ServiceLbl.TabIndex = 9;
            this.ServiceLbl.Text = "Hyvä asiakaspalvelu!";
            // 
            // NiceLbl
            // 
            this.NiceLbl.AutoSize = true;
            this.NiceLbl.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.NiceLbl.Location = new System.Drawing.Point(288, 393);
            this.NiceLbl.Name = "NiceLbl";
            this.NiceLbl.Size = new System.Drawing.Size(605, 37);
            this.NiceLbl.TabIndex = 10;
            this.NiceLbl.Text = "Uskomattoman Upea autovalikoima!";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1121, 532);
            this.Controls.Add(this.NiceLbl);
            this.Controls.Add(this.ServiceLbl);
            this.Controls.Add(this.PriceLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoadLbl);
            this.Controls.Add(this.Myprogress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Mycar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Mycar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Mycar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar Myprogress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LoadLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PriceLbl;
        private System.Windows.Forms.Label ServiceLbl;
        private System.Windows.Forms.Label NiceLbl;
    }
}

