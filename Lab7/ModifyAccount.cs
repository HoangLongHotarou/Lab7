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
    public partial class ModifyAccount : Form
    {
        private bool checkUpdate = false;

        public ModifyAccount()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkUpdate == true)
            {
                UpdateInfor();
            }
            else
            {
                InsertInfor();
            }
        }

        internal void InsertInfor()
        {
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "set dateformat dmy EXECUTE ACCOUNT_INSERT @AccountName,@Password,@FullName,@Email,@Tell,@DateCreated";

            command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100);
            command.Parameters.Add("@Password", SqlDbType.NVarChar, 200);
            command.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000);
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 1000);
            command.Parameters.Add("@Tell", SqlDbType.NVarChar, 200);
            command.Parameters.Add("@DateCreated", SqlDbType.SmallDateTime);

            command.Parameters["@AccountName"].Value = txtAccountName.Text;
            command.Parameters["@Password"].Value = txtPass.Text;
            command.Parameters["@FullName"].Value = txtFullName.Text;
            command.Parameters["@Email"].Value = txtEmail.Text;
            command.Parameters["@Tell"].Value = txtNumber.Text;
            command.Parameters["@DateCreated"].Value = DateTime.Now.ToString("dd/MM/yyyy");

            conn.Open();
            int num = command.ExecuteNonQuery();
            if (num > 0)
            {
                string accountName = command.Parameters["@AccountName"].Value.ToString();
                MessageBox.Show($"Thêm  thành công {accountName}", "Message");
                this.ResetText();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            conn.Close();
            conn.Dispose();
        }

        internal void UpdateInfor()
        {
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "set dateformat dmy EXECUTE ACCOUNT_Update @AccountName,@Password,@FullName,@Email,@Tell";

            command.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100);
            command.Parameters.Add("@Password", SqlDbType.NVarChar, 200);
            command.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000);
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 1000);
            command.Parameters.Add("@Tell", SqlDbType.NVarChar, 200);

            command.Parameters["@AccountName"].Value = txtAccountName.Text;
            command.Parameters["@Password"].Value = txtPass.Text;
            command.Parameters["@FullName"].Value = txtFullName.Text;
            command.Parameters["@Email"].Value = txtEmail.Text;
            command.Parameters["@Tell"].Value = txtNumber.Text;

            conn.Open();
            int num = command.ExecuteNonQuery();
            if (num > 0)
            {
                string accountName = command.Parameters["@AccountName"].Value.ToString();
                MessageBox.Show($"Cập nhật thành công {accountName}", "Message");
                this.ResetText();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            conn.Close();
            conn.Dispose();
        }

        public void LoadUser(string account)
        {
            checkUpdate = true;
            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security = true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            string query = $"SELECT [AccountName], [Password], [FullName], [Email], [Tell], [DateCreated] FROM [Account] WHERE [AccountName] = N'{account}'";
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader read1 = sqlCommand.ExecuteReader();
            while (read1.Read())
            {
                txtAccountName.Text = read1["AccountName"].ToString();
                txtPass.Text = read1["Password"].ToString();
                txtFullName.Text = read1["FullName"].ToString();
                txtEmail.Text = read1["Email"].ToString();
                txtNumber.Text = read1["Tell"].ToString();
            }
            sqlConnection.Close();
        }
    }
}
