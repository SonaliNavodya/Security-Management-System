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

namespace Group_Project
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            DisplayEmployees();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASD\Documents\SecurityDepartmentDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayEmployees()
        {
            Con.Open();
            string Query = "Select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Clear()
        {
            EmpNameTb.Text = "";
            EmpAddTb.Text = "";
            EmpPhoneTb.Text = "";
            PasswordTb.Text = "";
        }

        int Key = 0;

        private void Save_Click(object sender, EventArgs e)
        {
            int phone;
            if( EmpNameTb.Text == "" || EmpAddTb.Text == "" || EmpPhoneTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(EmpPhoneTb.Text, out phone))
            {
                MessageBox.Show("Telephone number should contains Only Numeric Values!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Employeetbl (EmpName, EmpAdd, EmpDOB, EmpPhone, EmpPass) values(@EN,@EA,@ED,@EP,@EPa)", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDateTb.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EPa", PasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added","Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayEmployees();
                    Clear();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }


        private void EmployeesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpAddTb.Text == "" || EmpPhoneTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Information!","Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update Employeetbl set EmpName=@EN, EmpAdd=@EA, EmpDOB=@ED, EmpPhone=@EP, EmpPass=@EPa where EmpNum=@EKey", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDateTb.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EPa", PasswordTb.Text);
                    //cmd.Parameters.AddWithValue("@EKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated","Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayEmployees();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmployeeDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddTb.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpDateTb.Text = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpPhoneTb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            PasswordTb.Text = EmployeeDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (EmpNameTb.Text == "")
            {
                Key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
