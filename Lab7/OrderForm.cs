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
    public partial class OrderForm : Form
    {
        string query="";

        public OrderForm()
        {
            InitializeComponent();
            LoadBills();
        }

        private void LoadBills()
        {
            if (query == "") { query = "SELECT * FROM BILLS"; }
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Bills");
            da.Fill(dt);
            dgvBills.DataSource = dt;
            TranslateToVietnamese();
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
            query = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = $"set dateformat dmy select * from Bills where CHECKOUTDATE = '{dtpFrom.Value.ToString("dd/MM/yyyy")}'";
            TotalAmount();
            LoadBills();
        }

        private void TotalAmount()
        {
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"set dateformat dmy select sum(amount) as AMOUNT from[BILLS] where[CheckoutDate] = '{dtpFrom.Value.ToString("dd/MM/yyyy")}'";
            sqlConnection.Open();
            tsslTotal.Text = "Tổng doanh thu: " + sqlCommand.ExecuteScalar().ToString();
            //sqlConnection.
        }

        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBills.Rows[e.RowIndex];
            OrderDetailForm form = new OrderDetailForm();
            if (row.Cells[0].Value.ToString() == "") return;
            form.LoadBillsDetail(Convert.ToInt32(row.Cells[0].Value));
            form.ShowDialog();
        }

        private void TranslateToVietnamese()
        {
            dgvBills.Columns["ID"].HeaderText = "Mã số";
            dgvBills.Columns["Name"].HeaderText = "Tên";
            dgvBills.Columns["TableID"].HeaderText = "Mã bàn";
            dgvBills.Columns["Amount"].HeaderText = "Số tiền";
            dgvBills.Columns["Discount"].HeaderText = "Giảm giá";
            dgvBills.Columns["Tax"].HeaderText = "Thuế";
            dgvBills.Columns["Status"].HeaderText = "Trạng thái";
            dgvBills.Columns["CheckoutDate"].HeaderText = "Ngày trả";
            dgvBills.Columns["Account"].HeaderText = "Tài khoảng";
        }
    }
}
