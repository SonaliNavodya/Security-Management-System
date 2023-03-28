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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
            DisplayInventory();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void RegPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASD\Documents\SecurityDepartmentDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayInventory()
        {
            Con.Open();
            string Query = "Select * from InventoryTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            InventoryDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Clear()
        {
            InItem.Text = "";
            InQty.Text = "";
            InPrice.Text = "";
            InDep.Text = "";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            int Qty;
            float PPU;

            if (InItem.Text == "" || InQty.Text == "" || InPrice.Text == "" || InDep.Text == "")
            {
                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!int.TryParse(InQty.Text, out Qty))
            {
                MessageBox.Show("Quntity should contains Only Numeric Values!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!float.TryParse(InPrice.Text, out PPU))
            {
                MessageBox.Show("Price should contains Only Numeric Values!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into InventoryTbl (InItem, InQty, InPrice, InDate, InDep) values(@II,@IQ,@IP,@ID,@IDep)", Con);
                    cmd.Parameters.AddWithValue("@II", InItem.Text);
                    cmd.Parameters.AddWithValue("@IQ", InQty.Text);
                    cmd.Parameters.AddWithValue("@IP", InPrice.Text);
                    cmd.Parameters.AddWithValue("@ID", InDate.Value.Date);
                    cmd.Parameters.AddWithValue("@IDep", InDep.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been Saved Succesfully!", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayInventory();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void Edit_Click(object sender, EventArgs e)
        {
            if (InItem.Text == "" || InQty.Text == "" || InPrice.Text == "" || InDep.Text == "")
            {
                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update InventoryTbl set InItem=@II, InQty=@IQ, InPrice=@IP, InDate=@ID, InDep=@IDep where InID = @IKey", Con);
                    cmd.Parameters.AddWithValue("@II", InItem.Text);
                    cmd.Parameters.AddWithValue("@IQ", InQty.Text);
                    cmd.Parameters.AddWithValue("@IP", InPrice.Text);
                    cmd.Parameters.AddWithValue("@ID", InDate.Value.Date);
                    cmd.Parameters.AddWithValue("@IDep", InDep.Text);
                    cmd.Parameters.AddWithValue("@IKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been Updated Succesfully!", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayInventory();
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
                    SqlCommand cmd = new SqlCommand("delete from InventoryTbl where InID = @IKey", Con);
                    cmd.Parameters.AddWithValue("@IKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been deleted Succesfully!", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    DisplayInventory();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void InventoryDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            InItem.Text = InventoryDGV.SelectedRows[0].Cells[1].Value.ToString();
            InQty.Text = InventoryDGV.SelectedRows[0].Cells[2].Value.ToString();
            InPrice.Text = InventoryDGV.SelectedRows[0].Cells[3].Value.ToString();
            InDate.Text = InventoryDGV.SelectedRows[0].Cells[4].Value.ToString();
            InDep.Text = InventoryDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (InItem.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(InventoryDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            HomeNew Obj = new HomeNew();
            Obj.Show();
            this.Hide();
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

        private void label4_Click(object sender, EventArgs e)
        {
            login Obj = new login();
            Obj.Show();
            this.Hide();
        }

        private void InItem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
