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
    public partial class Form1 : Form
    {
        private DataTable foodTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadCategory()
        {
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT ID,NAME FROM CATEGORY";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            conn.Open();

            adapter.Fill(dt);

            conn.Close();
            conn.Dispose();

            cbbCategory.DataSource = dt;
            cbbCategory.DisplayMember = "Name";
            cbbCategory.ValueMember = "ID";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadCategory();
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex == -1) return;
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Food Where FoodCategoryID = @categoryID";

            command.Parameters.Add("@categoryID", SqlDbType.Int);

            if (cbbCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView = cbbCategory.SelectedValue as DataRowView;
                command.Parameters["@categoryID"].Value = rowView["ID"];
            }
            else
            {
                command.Parameters["@categoryID"].Value = cbbCategory.SelectedValue;
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            foodTable = new DataTable();
            conn.Open();
            adapter.Fill(foodTable);
            
            conn.Close();
            conn.Dispose();
            dgvFoodList.DataSource = foodTable;
            TranslateToVietnamese();
            lbQuantity.Text = "Số lượng: " + foodTable.Rows.Count.ToString();
            lbCat.Text = "Loại: " + cbbCategory.Text;
        }

        private void TranslateToVietnamese()
        {
            dgvFoodList.Columns["ID"].HeaderText = "Mã số";
            dgvFoodList.Columns["Name"].HeaderText = "Tên món ăn";
            dgvFoodList.Columns["Unit"].HeaderText = "Đơn vị tính";
            dgvFoodList.Columns["FoodCategoryID"].HeaderText = "Loại";
            dgvFoodList.Columns["Price"].HeaderText = "Đơn giá";
            dgvFoodList.Columns["Notes"].HeaderText = "Ghi chú";
        }

        private void tsmCalculateQuantity_Click(object sender, EventArgs e)
        {
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT @numSaleFood = sum(Quantity) FROM Billdetails Where FoodID = @foodID";

            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                //Truyen tham so
                command.Parameters.Add("@foodID", SqlDbType.Int);
                command.Parameters["@foodID"].Value = rowView["ID"];

                command.Parameters.Add("@numSaleFood", SqlDbType.Int);
                command.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

                conn.Open();
                command.ExecuteNonQuery();
                string result = command.Parameters["@numSaleFood"].Value.ToString();
                MessageBox.Show($"Tổng số lượng món {rowView["Name"]} đã bán là {result} {rowView["Unit"]}");
                conn.Close();
            }
            conn.Dispose();
            command.Dispose();
        }


        private void tsmAddFood_Click(object sender, EventArgs e)
        {
            FoodInfoForm foodForm = new FoodInfoForm();
            foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
            foodForm.Show(this);
        }

        private void foodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = -1;
            cbbCategory.SelectedIndex = index;
        }

        private void tsmUpdateFood_Click(object sender, EventArgs e)
        {
            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                FoodInfoForm foodForm = new FoodInfoForm();
                foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);

                foodForm.Show(this);
                foodForm.DisplayFoodInfor(rowView);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null) return;

            string filterExpression = $"Name like '%{txtSearch.Text}%'";
            string sortExpression = "Price DESC";
            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;

            DataView foodView = new DataView(foodTable, filterExpression, sortExpression, rowStateFilter);
            dgvFoodList.DataSource = foodView;
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm();
            accountForm.ShowDialog();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog();
        }
    }
}
