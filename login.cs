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
    public partial class login : Form
    {
 
        public login()
        {
            InitializeComponent();
        }

        public static int ID;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

       

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(Password.Text == "" || UserName.Text == "")
            {
                MessageBox.Show("Enter UserName and Password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (UserName.Text == "Admin" && Password.Text == "Password")
            {
                HomeNew Obj = new HomeNew();
                Obj.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Invalid UserName and Password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserName.Text = "";
                Password.Text = "";
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Employee Obj = new Employee();
            Obj.Show();
            this.Hide();
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
