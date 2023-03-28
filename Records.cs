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
    public partial class Records : Form
    {
        public Records()
        {
            InitializeComponent();
            DisplayRecords();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASD\Documents\SecurityDepartmentDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayRecords()
        {
            Con.Open();
            string Query = "Select * from RecordsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            RecordsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Clear()
        {
            RecVehicle.Text = "";
            RecCat.SelectedIndex = -1;
            RecType.SelectedIndex = -1;
            RecNote.Text = "";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (RecVehicle.Text == "" || RecCat.SelectedIndex == -1 || RecType.SelectedIndex == -1 || RecNote.Text == "")
            {
                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into RecordsTbl (RecVehicle, RecCat, RecType, RecDate, RecNote) values(@RV,@RC,@RT,@RD,@RN)", Con);
                    cmd.Parameters.AddWithValue("@RV", RecVehicle.Text);
                    cmd.Parameters.AddWithValue("@RC", RecCat.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@RT", RecType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@RD", RecDate.Value.Date);
                    cmd.Parameters.AddWithValue("@RN", RecNote.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been saved Succesfully!", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayRecords();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void RecordsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RecVehicle.Text = RecordsDGV.SelectedRows[0].Cells[1].Value.ToString();
            RecCat.Text = RecordsDGV.SelectedRows[0].Cells[2].Value.ToString();
            RecType.Text = RecordsDGV.SelectedRows[0].Cells[3].Value.ToString();
            RecDate.Text = RecordsDGV.SelectedRows[0].Cells[4].Value.ToString();
            RecNote.Text = RecordsDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (RecVehicle.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(RecordsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (RecVehicle.Text == "" || RecCat.SelectedIndex == -1 || RecType.SelectedIndex == -1 )
            {
                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update RecordsTbl set RecVehicle=@RV, RecCat=@RC, RecType=@RT, RecDate=@RD, RecNote=@RN where RecID=@RecKey", Con);
                    cmd.Parameters.AddWithValue("@RV", RecVehicle.Text);
                    cmd.Parameters.AddWithValue("@RC", RecCat.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@RT", RecType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@RD", RecDate.Value.Date);
                    cmd.Parameters.AddWithValue("@RN", RecNote.Text);
                    cmd.Parameters.AddWithValue("@RecKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been Updated Succesfully!", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayRecords();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
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
                    SqlCommand cmd = new SqlCommand("delete from RecordsTbl where RecID = @RecKey", Con);
                    cmd.Parameters.AddWithValue("@RecKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been deleted Succesfully!", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayRecords();
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

        private void label15_Click(object sender, EventArgs e)
        {
            Registration Obj = new Registration();
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

        private void RecVehicle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
