using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class DI
    {
        public static SqlConnection Con;
        
        public static void Connect()
        {
            Con = new SqlConnection();
            Con.ConnectionString=@"Data Source=hotarou;Initial Catalog=RestaurantManagement;Integrated Security=True";
            Con.Open();
        }

        public static SqlCommand Command(string sql)
        {
            SqlCommand cmd = DI.Con.CreateCommand();
            cmd.CommandText = sql;
            return cmd;
        }

        public static void Disconnect()
        {
            if(Con.State== ConnectionState.Open)
            {
                Con.Close();
                Con.Dispose();
                Con = null;
            }
        }

        public static DataTable ReadTable(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand();
            adapter.SelectCommand.Connection = DI.Con;
            adapter.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
