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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            DisplayEmployee();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASD\Documents\SecurityDepartmentDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayEmployee()
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
        }

        internal DataTable GetData(string query)
        {
            throw new NotImplementedException();
        }

        int Key = 0;


        private void Save_Click(object sender, EventArgs e)
        {
            int phone;
            if (EmpNameTb.Text == "" || EmpAddTb.Text == "" || EmpPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(EmpPhoneTb.Text, out phone))
            {
                MessageBox.Show("Telephone number should contains only intergers!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Employeetbl (EmpName, EmpAdd, EmpDOB, EmpPhone) values(@EN,@EA,@ED,@EP)", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDateTb.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been saved Succesfully!", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayEmployee();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpAddTb.Text == "" || EmpPhoneTb.Text == "" )
            {
                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update Employeetbl set EmpName=@EN, EmpAdd=@EA, EmpDOB=@ED, EmpPhone=@EP where EmpNum=@EKey", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDateTb.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been Updated Succesfully!", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayEmployee();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddTb.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpDateTb.Text = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpPhoneTb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }else
            {
                Key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from Employeetbl where empNum = @EmpKey", Con);
                    cmd.Parameters.AddWithValue("@EmpKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been deleted Succesfully!", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayEmployee();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Registration Obj = new Registration();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HomeNew Obj = new HomeNew();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Records Obj = new Records();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Inventory Obj = new Inventory();
            Obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void EmpAddTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpNameTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
