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
    public partial class Form3 : Form
    {
        public int ID = 0;
        string query = "select products.id_product as 'ID товара', products.name as 'Наименование продукта', article_number as 'Артикул', product_types.name as 'Тип товара', manufacturers.name as 'Производитель', products.price as 'Цена'," +
            " products.warranty_period as 'Гарантийный срок', products.in_stock as 'В наличии' from products join product_types on products.id_type = product_types.id_type " +
            "join manufacturers on products.id_manufacturer = manufacturers.id_manufacturer;";
        string query1 = "select * from products;";
        public Form3(int ID_login)
        {
            InitializeComponent();
            get_info(query);
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
                MessageBox.Show("" + Environment.NewLine + ex.Message);
            }
        }
        public void get_info1(string query)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(query, connection);
            try
            {
                connection.Open();
                DataTable table = new DataTable();
                mySql_dataAdapter.Fill(table);
                dataGridView2.DataSource = table;
                dataGridView2.ClearSelection();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + Environment.NewLine + ex.Message);
            }
        }

        private void добавитьТоварToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 Win = new Form4(ID);
            this.Hide();
            Win.Show();
        }

        private void просмотрШаблоновХарактеристикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 Win = new Form5(ID);
            this.Hide();
            Win.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = DBUtils.GetDBConnection();
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query1, connection);
                MySqlDataReader reader = cmDB.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString("article_number"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select products.id_product as 'ID товара', products.name as 'Наименование продукта', article_number as 'Артикул', product_types.name as 'Тип товара', manufacturers.name as 'Производитель', products.price as 'Цена'," +
            " products.warranty_period as 'Гарантийный срок', products.in_stock as 'В наличии' from products join product_types on products.id_type = product_types.id_type " +
            "join manufacturers on products.id_manufacturer = manufacturers.id_manufacturer where article_number = '" + textBox1.Text + "';";
            string query1 = "select products.id_product as 'ID товара', products.name as 'Наименование продукта', article_number as 'Артикул', product_types.name as 'Тип товара', manufacturers.name as 'Производитель', products.price as 'Цена'," +
            " products.warranty_period as 'Гарантийный срок', products.in_stock as 'В наличии' from products join product_types on products.id_type = product_types.id_type " +
            "join manufacturers on products.id_manufacturer = manufacturers.id_manufacturer where products.name = '" + textBox1.Text + "';";
            string query2 = "select products.id_product as 'ID товара', products.name as 'Наименование продукта', article_number as 'Артикул', product_types.name as 'Тип товара', manufacturers.name as 'Производитель', products.price as 'Цена'," +
            " products.warranty_period as 'Гарантийный срок', products.in_stock as 'В наличии' from products join product_types on products.id_type = product_types.id_type " +
            "join manufacturers on products.id_manufacturer = manufacturers.id_manufacturer where manufacturers.name = '" + textBox1.Text + "';";
            try
            {
                if (comboBox1.Text == "Артикулу" && textBox1.Text != "")
                {
                    get_info(query);
                    textBox1.Clear();
                }
                else if (comboBox1.Text == "Наименованию" && textBox1.Text != "")
                {
                    get_info(query1);
                    textBox1.Clear();
                }
                else if (comboBox1.Text == "Производителю" && textBox1.Text != "")
                {
                    get_info(query2);
                    textBox1.Clear();
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполните строку поиска!");
                }
                else if (comboBox1.Text != "")
                {
                    MessageBox.Show("Выберите критерий!");
                }
                else if (comboBox1.Text != "" && textBox1.Text != "")
                {
                    MessageBox.Show("Выберите критерий и заполните строку поиска!");
                }
                else
                {
                    MessageBox.Show("Ничего не найдено!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void выходИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Выход", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query2 = "select specifications.name, description_spec.description from products join product_types on products.id_type = product_types.id_type join specifications on product_types.id_type = specifications.id_type join description_spec on specifications.id_specification = description_spec.id_specification where article_number = '" + comboBox2.Text + "';";
            get_info1(query2);
        }

        private void главноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Win = new Form2(ID);
            this.Close();
            Win.Show();
        }

        private void программаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string script = "update products set in_stock = '" + textBox3.Text + "' where id_product = '" + textBox2.Text + "';";
            {
                get_info(script);
                get_info(query);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string script = "select specifications.name, description_spec.description from products join product_types on products.id_type = product_types.id_type join specifications on product_types.id_type = specifications.id_type join description_spec on specifications.id_specification = description_spec.id_specification where specifications.name = '" + textBox4.Text + "';";
            string script1 = "select specifications.name, description_spec.description from products join product_types on products.id_type = product_types.id_type join specifications on product_types.id_type = specifications.id_type join description_spec on specifications.id_specification = description_spec.id_specification where products.id_product = '" + textBox5.Text + "';";
            if (textBox4.Text != "")
            {
                get_info1(script);
                textBox4.Clear();
            }
            else if (textBox5.Text != "")
            {
                get_info1(script1);
                textBox5.Clear();
            }
        }
    }
}
