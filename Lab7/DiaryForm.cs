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
    public partial class DiaryForm : Form
    {
        string accountName;

        public DiaryForm(string accountName)
        {
            InitializeComponent();
            this.accountName = accountName;
            LoadDate();
        }

        private void LoadDate()
        {
            DI.Connect();
            string sql = $"set dateformat dmy select distinct([CheckoutDate]) from [Bills] where [Account] = N'{accountName}'";
            SqlDataAdapter adapter = new SqlDataAdapter(DI.Command(sql));
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DI.Disconnect();
            lbDate.DataSource = dt;
            lbDate.DisplayMember = "CheckoutDate";
            lbDate.ValueMember = "CheckoutDate";
        }

        private void LoadTotal()
        {

        }

        private void lbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            DI.Connect();
            string date = "";
            if(lbDate.SelectedValue is DataRowView)
            {
                DataRowView rowView = lbDate.SelectedValue as DataRowView;
                date = rowView["CheckoutDate"].ToString();
            }
            else
            {
                date = lbDate.SelectedValue.ToString();
            }
            string query = $"set dateformat mdy select * from Bills where CHECKOUTDATE = '{date}' and Account = N'{accountName}'";
            dgvListFood.DataSource = DI.ReadTable(query);
            lbTotal.Text = "Tổng số lượng: " + dgvListFood.Rows.Count;
            //Amount 
            query = $"set dateformat mdy select SUM([Amount]) from Bills where CHECKOUTDATE = '{date}' and Account = N'{accountName}' group by Account";
            string count = DI.Command(query).ExecuteScalar().ToString();
            DI.Disconnect();
            lbAmount.Text = "Tổng tiền: "+count;
        }
    }
}
