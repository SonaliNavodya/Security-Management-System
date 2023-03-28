using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_Project
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int startP = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startP += 1;
            MyProgress.Value = startP;
            Precentage.Text = startP + "%";
            if(MyProgress.Value == 99)
            {
                MyProgress.Value = 0;
                login Obj = new login();
                Obj.Show();
                this.Hide();
                timer1.Stop();
            }
        }

        private void Precentage_Click(object sender, EventArgs e)
        {

        }

        private void MyProgress_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
