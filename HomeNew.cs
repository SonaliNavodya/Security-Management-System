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

namespace Group_Project
{
    public partial class HomeNew : Form
    {
        public HomeNew()
        {
            InitializeComponent();
            CountInbound();
            CountOutbound();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Registration Obj = new Registration();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Records Obj = new Records();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employee Obj = new Employee();
            Obj.Show();
            this.Hide();
        }

        private void HomeNew_Load(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            Inventory Obj = new Inventory();
            Obj.Show();
            this.Hide();
        }

        private void In_Click(object sender, EventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASD\Documents\SecurityDepartmentDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void CountInbound()
        {
            string Cat = "Inbound";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from RecordsTbl where RecType = '"+ Cat +"' ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            InLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void CountOutbound()
        {
            string Cat = "Outbound";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from RecordsTbl where RecType = '" + Cat + "' ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            OutLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }

        private void OutLbl_Click(object sender, EventArgs e)
        {

        }

        private void Total()
        {
            Con.Open();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void InTotal_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
