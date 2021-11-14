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
    public partial class AccountForm : Form
    {
        private List<int> indexs;

        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "Select AccountName,FullName,Email,Tell from Account";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Account");
            da.Fill(dt);
            dgvAccount.DataSource = dt;
            //TranslateToVietnamese();
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
            TranslateToVietnamese();
            //query = "";
        }

        private void TranslateToVietnamese()
        {
            dgvAccount.Columns["AccountName"].HeaderText = "Tên tài khoản";
            dgvAccount.Columns["FullName"].HeaderText = "Tên người dùng";
            dgvAccount.Columns["Email"].HeaderText = "Email";
            dgvAccount.Columns["Tell"].HeaderText = "Số điên thoại";
        }

        private void dgvAccount_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DataGridViewRow currow = dgvAccount.Rows[e.RowIndex];
            //if(e.RowIndex>=0 && !indexs.Contains(e.RowIndex))
            //{
            //    indexs.Add(e.RowIndex);
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ModifyAccount form = new ModifyAccount();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dgvAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvAccount.Rows[e.RowIndex];
            ModifyAccount form = new ModifyAccount();
            form.LoadUser(row.Cells[0].Value.ToString());
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void tsmiRole_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count < 0) return;
            DataGridViewRow row = dgvAccount.SelectedRows[0];
            RoleForm roleForm = new RoleForm(row.Cells[0].Value.ToString());
            roleForm.ShowDialog();
        }

        private void tmsiDiary_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count < 0) return;
            //MessageBox.Show(dgvAccount.SelectedRows[0].Cells[0].ToString());
            DiaryForm diaryForm = new DiaryForm(dgvAccount.SelectedRows[0].Cells[0].Value.ToString());
            diaryForm.ShowDialog();
        }
    }
}
