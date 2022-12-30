using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public void get_info(string query)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(query, connection);
            try
            {
                connection.Open();
                DataTable table = new DataTable();
                mySql_dataAdapter.Fill(table);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + Environment.NewLine + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string script = "delete from shopping_cart where id_order = '" + textBox1.Text + "';";
            string script1 = "delete from orders where id_order = '" + textBox1.Text + "';";
            if (textBox1.Text != "")
            {
                get_info(script + script1);
                MessageBox.Show("Успешное удаление!");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
