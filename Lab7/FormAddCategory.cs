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
    public partial class FormAddCategory : Form
    {
        public FormAddCategory()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ////Create object connectionString
            //string connectionString = "server=localhost; database = RestaurantManagement; Integrated Security = true;";
            //SqlConnection sqlConnection = new SqlConnection(connectionString);

            ////Create object execute command
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = "INSERT INTO Category(Name,[Type]) VALUES (N'" + txtName.Text + "'," + txtType.Text + ")";

            ////Open and connect database
            //sqlConnection.Open();

            ////Execute command by ExecuteNonQuery
            //int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            ////Close connect
            //sqlConnection.Close();

            //if (numOfRowsEffected == 1)
            //{
            //    MessageBox.Show("Thêm món ăn thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Đã có lỗi xải ra. Vui lòng thử lại");
            //}

            string connectionString = "server=hotarou; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "exec CATEGORY_INSERT @id out, @name, @type";

            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters.Add("@name", SqlDbType.NVarChar, 10000);
            command.Parameters.Add("@type", SqlDbType.Int);
            command.Parameters["@id"].Direction = ParameterDirection.Output;
            command.Parameters["@name"].Value = txtName.Text;
            command.Parameters["@type"].Value = txtType.Text;

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
            this.Close();
        }
    }
}
