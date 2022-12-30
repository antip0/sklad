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
    public partial class Form8 : Form
    {
        public Form8()
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
            string script = "insert into orders values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "');";
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                get_info(script);
                MessageBox.Show("Успешное добавление!");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
