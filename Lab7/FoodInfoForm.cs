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

namespace Lab7
{
    public partial class FoodInfoForm : Form
    {
        public FoodInfoForm()
        {
            InitializeComponent();
        }

        private void FoodInfoForm_Load(object sender, EventArgs e)
        {
            InitValues();
        }

        private void InitValues()
        {
            string connectionString = "server=localhost; database = RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID, Name from category";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            conn.Open();
            adapter.Fill(ds,"Category");

            cbbCat.DataSource = ds.Tables["Category"];
            cbbCat.DisplayMember = "Name";
            cbbCat.ValueMember = "ID";

            conn.Close();
            conn.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetText()
        {
            txtID.ResetText();
            txtName.ResetText();
            txtNotes.ResetText();
            txtUnit.ResetText();
            cbbCat.ResetText();
            cbbCat.ResetText();
            nudPrice.ResetText();
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormAddCategory form = new FormAddCategory();
            form.ShowDialog();
            InitValues();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{

            //}
            //catch (SqlException exception)
            //{
            //    MessageBox.Show(exception.Message, "Error");
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message, "Error");
            //}
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "EXECUTE InsertFood @id OUTPUT, @name, @unit, @foodCategoryID, @price, @notes";

            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters.Add("@name", SqlDbType.NVarChar, 10000);
            command.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
            command.Parameters.Add("@foodCategoryID", SqlDbType.Int);
            command.Parameters.Add("@Price", SqlDbType.Int);
            command.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

            command.Parameters["@id"].Direction = ParameterDirection.Output;

            command.Parameters["@name"].Value = txtName.Text;
            command.Parameters["@unit"].Value = txtUnit.Text;
            command.Parameters["@foodCategoryID"].Value = cbbCat.SelectedValue;
            command.Parameters["@Price"].Value = nudPrice.Value;
            command.Parameters["@notes"].Value = txtNotes.Text;

            conn.Open();
            int num = command.ExecuteNonQuery();
            if (num > 0)
            {
                string foodID = command.Parameters["@id"].Value.ToString();
                MessageBox.Show($"Thêm  thành công {foodID}", "Message");
                this.ResetText();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            conn.Close();
            conn.Dispose();
        }

        public void DisplayFoodInfor(DataRowView rowView)
        {
            try
            {
                txtID.Text = rowView["ID"].ToString();
                txtName.Text = rowView["Name"].ToString();
                txtUnit.Text = rowView["Unit"].ToString();
                txtNotes.Text = rowView["Notes"].ToString();
                nudPrice.Text = rowView["Price"].ToString();

                for (int index = 0; index < cbbCat.Items.Count; index++)
                {
                    DataRowView cat = cbbCat.Items[index] as DataRowView;
                    if (cat["ID"].ToString() == rowView["FoodCategoryID"].ToString())
                    {
                        cbbCat.SelectedIndex = index;
                        return;
                    }
                }
                cbbCat.SelectedIndex = -1;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Lỗi");
                this.Close();
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security=true;";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "EXECUTE UpdateFood @id, @name, @unit, @foodCategoryID, @price, @notes";

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters.Add("@name", SqlDbType.NVarChar, 10000);
                command.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                command.Parameters.Add("@foodCategoryID", SqlDbType.Int);
                command.Parameters.Add("@Price", SqlDbType.Int);
                command.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                command.Parameters["@id"].Value = int.Parse(txtID.Text);
                command.Parameters["@name"].Value = txtName.Text;
                command.Parameters["@unit"].Value = txtUnit.Text;
                command.Parameters["@foodCategoryID"].Value = cbbCat.SelectedValue;
                command.Parameters["@Price"].Value = nudPrice.Value;
                command.Parameters["@notes"].Value = txtNotes.Text;

                conn.Open();
                int num = command.ExecuteNonQuery();
                if (num > 0)
                {
                    string foodID = command.Parameters["@id"].Value.ToString();
                    MessageBox.Show($"Thêm  thành công {foodID}", "Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }
    }
}
