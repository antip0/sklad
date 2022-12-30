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
    public partial class Form6 : Form
    {
        string query = "select orders.id_order as 'ID заказа', customers.id_customer as 'ID клиента', customers.fio_customer as 'ФИО клиента', orders.name as 'Название заказа', employees.fio_employee as 'ФИО сотрудника', orders.date_of_creation as 'Дата создания заказа', orders.total as 'Общая стоимость' from customers join orders on customers.id_customer = orders.id_customer join employees on orders.id_employee = employees.id_employee;";
        string query1 = "select * from customers;";
        public int ID = 0;
        public Form6(int ID_login)
        {
            InitializeComponent();
            get_info(query);
            ID = ID_login;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
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

        private void выйтиИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Выход", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void главноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Win = new Form2(ID);
            this.Close();
            Win.Show();
        }

        private void списокТоваровНаСкладеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 Win = new Form3(ID);
            this.Close();
            Win.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 Win = new Form7();
            Win.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "select customers.id_customer as 'ID клиента', customers.fio_customer as 'ФИО клиента', orders.name as 'Название заказа', orders.date_of_creation as 'Дата создания заказа' from customers join orders on customers.id_customer = orders.id_customer where fio_customer = '" + textBox1.Text + "';";
            string query1 = "select customers.id_customer as 'ID клиента', customers.fio_customer as 'ФИО клиента', orders.name as 'Название заказа', orders.date_of_creation as 'Дата создания заказа' from customers join orders on customers.id_customer = orders.id_customer where orders.name = '" + textBox1.Text + "';";
            try
            {
                if (comboBox1.Text == "Клиенту" && textBox1.Text != "")
                {
                    get_info(query);
                    textBox1.Clear();
                }
                else if (comboBox1.Text == "Заказу" && textBox1.Text != "")
                {
                    get_info(query1);
                    textBox1.Clear();
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполните строку поиска!");
                }
                else if (comboBox1.Text == "")
                {
                    MessageBox.Show("Выберите критерий!");
                }
                else if (comboBox1.Text == "" && textBox1.Text == "")
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

        private void Form6_Load(object sender, EventArgs e)
        {
            
            try
            {
                MySqlConnection connection = DBUtils.GetDBConnection();
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query1, connection);
                MySqlDataReader reader = cmDB.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString("id_customer"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query1 = "select orders.id_order as 'ID заказа', products.article_number as 'Артикул', products.name as 'Наименование товара', products.price as 'Цена', products.in_stock as 'В наличии', shopping_cart.in_shopping_cart as 'Количество товаров в корзине', orders.date_of_creation as 'Дата создания заказа' from customers join orders on customers.id_customer = orders.id_customer join shopping_cart on orders.id_order = shopping_cart.id_order join products on shopping_cart.id_product = products.id_product where customers.id_customer = '" + comboBox2.Text + "';";
            get_info1(query1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 Win = new Form8();
            Win.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            get_info(query);
        }

        private void поискКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 Win = new Form9(ID);
            Win.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query1 = "select orders.id_order as 'ID заказа', products.article_number as 'Артикул', products.name as 'Наименование товара', products.price as 'Цена', products.in_stock as 'В наличии', shopping_cart.in_shopping_cart as 'Количество товаров в корзине', orders.date_of_creation as 'Дата создания заказа' from customers join orders on customers.id_customer = orders.id_customer join shopping_cart on orders.id_order = shopping_cart.id_order join products on shopping_cart.id_product = products.id_product where customers.id_customer = '" + comboBox2.Text + "';";
            if (comboBox2.Text != "")
            {
                get_info1(query1);
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Введите ID клиента!");
            }
            else
            {
                MessageBox.Show("Ничего не найдено!");
            }
        }
    }
}
