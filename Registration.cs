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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            DisplayRegistration();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASD\Documents\SecurityDepartmentDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayRegistration()
        {
            Con.Open();
            string Query = "Select * from RegistrationTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            RegistrationDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Clear()
        {
            RegName.Text = "";
            RegAdd.Text = "";
            RegVehicle.Text = "";
            RegPhone.Text = "";
        }
        private void Save_Click(object sender, EventArgs e)
        {
            int phone;
            if (RegName.Text == "" || RegAdd.Text == "" || RegVehicle.Text == "" || RegPhone.Text == "")
            {
                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (! int.TryParse(RegPhone.Text, out phone))
            { 
                MessageBox.Show("Telephone number should contains Only Intergers!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into RegistrationTbl (RegName, RegAdd, RegVehicle, RegPhone) values(@RN,@RA,@RV,@RP)", Con);
                    cmd.Parameters.AddWithValue("@RN", RegName.Text);
                    cmd.Parameters.AddWithValue("@RA", RegAdd.Text);
                    cmd.Parameters.AddWithValue("@RV", RegVehicle.Text);
                    cmd.Parameters.AddWithValue("@RP", RegPhone.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been Saved Succesfully!", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayRegistration();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void RegistrationDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RegName.Text = RegistrationDGV.SelectedRows[0].Cells[1].Value.ToString();
            RegAdd.Text = RegistrationDGV.SelectedRows[0].Cells[2].Value.ToString();
            RegVehicle.Text = RegistrationDGV.SelectedRows[0].Cells[3].Value.ToString();
            RegPhone.Text = RegistrationDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (RegName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(RegistrationDGV.SelectedRows[0].Cells[0].Value.ToString());
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
                    SqlCommand cmd = new SqlCommand("delete from RegistrationTbl where RegID = @RegKey", Con);
                    cmd.Parameters.AddWithValue("@RegKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been deleted Succesfully!", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayRegistration();
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
            if (RegName.Text == "" || RegAdd.Text == "" || RegVehicle.Text == "" || RegPhone.Text == "")
            {
                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update RegistrationTbl set RegName=@RN, RegAdd=@RA, RegVehicle=@RV, RegPhone=@RP where RegID=@RKey", Con);
                    cmd.Parameters.AddWithValue("@RN", RegName.Text);
                    cmd.Parameters.AddWithValue("@RA", RegAdd.Text);
                    cmd.Parameters.AddWithValue("@RV", RegVehicle.Text);
                    cmd.Parameters.AddWithValue("@RP", RegPhone.Text);
                    cmd.Parameters.AddWithValue("@RKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been Updated Succesfully!", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayRegistration();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
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

        private void label14_Click(object sender, EventArgs e)
        {
            Employee Obj = new Employee();
            Obj.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Inventory Obj = new Inventory();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
