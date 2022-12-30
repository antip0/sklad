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
    public partial class Form5 : Form
    {
        public int ID = 0;
        string query = "select * from product_types;";
        public Form5(int ID_login)
        {
            InitializeComponent();
            ID = ID_login;
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
                dataGridView1.DataSource = table;
                dataGridView1.ClearSelection();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = DBUtils.GetDBConnection();
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmDB.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("name"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select specifications.name from specifications join product_types on specifications.id_type = product_types.id_type where product_types.name = '" + comboBox1.Text + "';";
            get_info(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into specifications (id_type, name) values ('" + textBox1.Text + "', '" + textBox2.Text + "');";
            string query1 = "select specifications.name from specifications join product_types on specifications.id_type = product_types.id_type where product_types.name = '" + comboBox1.Text + "'; ";
            get_info(query + query1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "update specifications set id_type = '" + textBox4.Text + "', name = '" + textBox3.Text + "' where id_specification = '" + textBox5.Text + "';";
            string query1 = "select specifications.name from specifications join product_types on specifications.id_type = product_types.id_type where product_types.name = '" + comboBox1.Text + "';";
            string query2 = "update specifications set id_type = '" + textBox4.Text + "' where id_specification = '" + textBox5.Text + "';";
            string query3 = "update specifications set name = '" + textBox3.Text + "' where id_specification = '" + textBox5.Text + "';";
            if (textBox4.Text != "")
            {
                get_info(query2 + query1);
            }
            else if (textBox3.Text != "")
            {
                get_info(query3 + query1);
            }
            else if (textBox4.Text != "" && textBox3.Text != "")
            {
                get_info(query + query1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "select product_types.id_type, product_types.name, specifications.id_specification, specifications.name from specifications join product_types on specifications.id_type = product_types.id_type where product_types.name = '" + comboBox1.Text + "';";
            get_info(query);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "select product_types.id_type, product_types.name, specifications.id_specification, specifications.name from specifications join product_types on specifications.id_type = product_types.id_type where product_types.name = '" + comboBox1.Text + "';";
            get_info(query);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "select product_types.id_type, product_types.name, specifications.id_specification, specifications.name from specifications join product_types on specifications.id_type = product_types.id_type where product_types.name = '" + comboBox1.Text + "';";
            get_info(query);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "delete from specifications where id_specification = '" + textBox6.Text + "';";
            string query1 = "select specifications.name from specifications join product_types on specifications.id_type = product_types.id_type where product_types.name = '" + comboBox1.Text + "';";
            get_info(query + query1);
        }


        private void программаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 Win = new Form3(ID);
            this.Close();
            Win.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 Win = new Form3(ID);
            this.Close();
            Win.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 Win = new Form3(ID);
            this.Close();
            Win.Show();
        }

        private void выйтиИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 Win = new Form1();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Form1")
                    Application.OpenForms[i].Close();
            }
            Win.Show();
        }

        private void выйтиИзПрограммыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Выход", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 Win = new Form3(ID);
            this.Close();
            Win.Show();
        }

        private void добавитьТоварToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 Win = new Form4(ID);
            this.Hide();
            Win.Show();
        }

        private void выйтиИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Win = new Form2(ID);
            this.Close();
            Win.Show();
        }
    }
}
