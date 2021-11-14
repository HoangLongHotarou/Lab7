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
    public partial class OrderDetailForm : Form
    {
        public OrderDetailForm()
        {
            InitializeComponent();
        }

        public void LoadBillsDetail(int id)
        {
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = $"SELECT B.ID,B.[InvoiceID],C.[NAME],B.[Quantity],B.[Quantity]*C.[Price] as Total FROM [BillDetails] as B,[FOOD] as C WHERE [InvoiceID] = {id} AND [FoodID] = C.ID";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Bill Detail");
            da.Fill(dt);
            dgvBills.DataSource = dt;
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
            TranslateToVietnamese();
        }

        private void TranslateToVietnamese()
        {
            dgvBills.Columns["ID"].HeaderText = "Mã số";
            dgvBills.Columns["InvoiceID"].HeaderText = "Mã Bills";
            dgvBills.Columns["NAME"].HeaderText = "Tên";
            dgvBills.Columns["Quantity"].HeaderText = "Số lượng";
        }
    }
}
