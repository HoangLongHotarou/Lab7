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
    public partial class RoleForm : Form
    {
        private Dictionary<string, int> roles;
        string account;
        //private string roleName;
        //int roleID;

        public RoleForm(string account)
        {
            this.account = account;
            roles = new Dictionary<string, int>();
            InitializeComponent();
            LoadRole();
        }

        private void LoadRole()
        {
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT * From Role ";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            DisplayRole(reader);
            sqlConnection.Close();
            sqlConnection.Open();
            RoleAccount(ref sqlCommand);
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private void RoleAccount(ref SqlCommand cmd)
        {
            cmd.CommandText = $"Select RoleID from RoleAccount where AccountName = N'{account}'";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                foreach (ListViewItem item in lvRole.Items)
                {
                    if (reader["RoleID"].ToString() == item.Text.ToString())
                    {
                        item.Checked = true;
                    }
                }
            }
        }

        private void DisplayRole(SqlDataReader reader)
        {
            lvRole.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                item.SubItems.Add(reader["RoleName"].ToString());
                item.SubItems.Add(reader["Path"].ToString());
                item.SubItems.Add(reader["Notes"].ToString());
                lvRole.Items.Add(item);
            }
        }

        private void RoleForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveRole_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost; database = RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"Delete from [RoleAccount]  where [AccountName] = N'{account}'";
            sqlConnection.Open();
            int numOfRowsEffected = 0;
            numOfRowsEffected += sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            foreach (ListViewItem item in lvRole.CheckedItems)
            {
                sqlCommand.CommandText = $"INSERT [RoleAccount] ([RoleID], [AccountName], [Actived], [Notes]) VALUES ({item.Text.ToString()}, N'{account}', 1, NULL)";
                sqlConnection.Open();
                numOfRowsEffected = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            if (numOfRowsEffected > 0)
            {
                MessageBox.Show("Chỉnh sửa thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnModifyRole_Click(object sender, EventArgs e)
        {
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"exec modify_role @id, N'{txtRole.Text}',N'{txtPath.Text}',N'{txtNotes.Text}'";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int);
            sqlCommand.Parameters["@id"].Direction = ParameterDirection.Output;
            sqlConnection.Open();
            int numRowAffected = sqlCommand.ExecuteNonQuery();
            if (numRowAffected > 0)
            {
                MessageBox.Show($"Đã lưu thành công {sqlCommand.Parameters["@id"].Value.ToString()}");
                txtRole.ResetText();
                txtPath.ResetText();
                txtNotes.ResetText();
                LoadRole();
            }
            else
            {
                MessageBox.Show("Adding food failed");
            }
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvRole_Click(object sender, EventArgs e)
        {
            
        }

        private void lvRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRole.SelectedItems.Count <= 0) return;
            ListViewItem item = lvRole.SelectedItems[0];
            txtRole.Text = item.SubItems[1].Text;
            txtPath.Text = item.SubItems[2].Text;
            txtNotes.Text = item.SubItems[3].Text;
        }
    }
}
