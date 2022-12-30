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
    public partial class Form4 : Form
    {
        public int ID = 0;
        string query = "select products.id_product as 'ID товара', products.name as 'Наименование товара', product_types.name as 'Тип товара', manufacturers.name as 'Производитель', " +
            "products.article_number as 'Артикул', products.price as 'Цена', products.warranty_period as 'Гарантийный срок', products.in_stock as 'В наличии' from products join product_types " +
            "on products.id_type = product_types.id_type join manufacturers on products.id_manufacturer = manufacturers.id_manufacturer;";
        string query1 = "select id_type as 'ID типа товара', name as 'Наименование' from product_types;";
        string query2 = "select id_manufacturer as 'ID производителя', name as 'Наименование', adress as 'Адрес', num_phone as 'Номер телефона', fio_contact_person as 'ФИО контактного лица' from manufacturers;";
        public Form4(int ID_login)
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
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string script = "update products set id_type = '" + textBox15.Text + "', id_manufacturer = '" + textBox14.Text + "', article_number = '" + textBox13.Text + "', name = '" + textBox12.Text + "', price = '" + textBox11.Text + "', warranty_period = '" + textBox10.Text + "', in_stock = '" + textBox9.Text + "' where id_product = '" + textBox16.Text + "';";
            string script1 = "update products set id_type = '" + textBox15.Text + "'  where id_product = '" + textBox16.Text + "';";
            string script2 = "update products set id_manufacturer = '" + textBox14.Text + "' where id_product = '" + textBox16.Text + "';";
            string script3 = "update products set article_number = '" + textBox13.Text + "' where id_product = '" + textBox16.Text + "';";
            string script4 = "update products set name = '" + textBox12.Text + "' where id_product = '" + textBox16.Text + "';";
            string script5 = "update products set price = '" + textBox11.Text + "' where id_product = '" + textBox16.Text + "';";
            string script6 = "update products set warranty_period = '" + textBox10.Text + "' where id_product = '" + textBox16.Text + "';";
            string script7 = "update products set in_stock = '" + textBox9.Text + "' where id_product = '" + textBox16.Text + "';";
            if (textBox16.Text == "")
            {
                MessageBox.Show("Заполните ID товара!");
            }
            else if (textBox16.Text != "" && textBox15.Text != "" && textBox14.Text != "" && textBox13.Text != "" && textBox12.Text != "" && textBox11.Text != "" && textBox10.Text != "" && textBox9.Text != "")
            {
                get_info(script + query);
                textBox16.Clear();
                textBox15.Clear();
                textBox14.Clear();
                textBox13.Clear();
                textBox12.Clear();
                textBox11.Clear();
                textBox10.Clear();
                textBox9.Clear();
            }
            else if (textBox15.Text != "")
            {
                get_info(script1 + query);
            }
            else if (textBox14.Text != "")
            {
                get_info(script2 + query);
                textBox14.Clear();
            }
            else if (textBox13.Text != "")
            {
                get_info(script3 + query);
                textBox13.Clear();
            }
            else if (textBox12.Text != "")
            {
                get_info(script4 + query);
                textBox12.Clear();
            }
            else if (textBox11.Text != "")
            {
                get_info(script5 + query);
                textBox11.Clear();
            }
            else if (textBox10.Text != "")
            {
                get_info(script6 + query);
                textBox10.Clear();
            }
            else if (textBox9.Text != "")
            {
                get_info(script7 + query);
                textBox9.Clear();
            }
        }

        private void выйтиИзПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Выход", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void выйтиИзСистемыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 Win = new Form1();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Form1")
                    Application.OpenForms[i].Close();
            }
            Win.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string script = "insert into products values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "');";
            get_info(script + query);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            get_info(query);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            get_info(query);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            get_info(query);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            get_info(query1);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            get_info(query2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string script = "delete from products where id_product = '" + textBox17.Text + "';";
            if (textBox17.Text != "")
            {
                get_info(script + query);
                textBox17.Clear();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string script = "update product_types set name = '" + textBox20.Text + "' where id_type = '" + textBox21.Text + "';";
            if (textBox21.Text == "")
            {
                MessageBox.Show("Заполните поле ID типа!");
            }
            else if (textBox21.Text != "" & textBox20.Text != "")
            {
                get_info(script + query1);
                textBox21.Clear();
                textBox20.Clear();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string script = "insert into product_types values('" + textBox18.Text + "', '" + textBox19.Text + "');";
            if (textBox18.Text != "" && textBox19.Text != "")
            {
                get_info(script + query1);
                textBox18.Clear();
                textBox19.Clear();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string script = "delete from product_types where id_type = '" + textBox22.Text + "';";
            if (textBox22.Text != "")
            {
                get_info(script + query1);
                textBox22.Clear();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string script = "insert into manufacturers values ('" + textBox23.Text + "', '" + textBox24.Text + "', '" + textBox25.Text + "', '" + textBox26.Text + "', '" + textBox27.Text + "');";
            if (textBox23.Text != "" && textBox24.Text != "" && textBox25.Text != "" && textBox26.Text != "" && textBox27.Text != "")
            {
                get_info(script + query2);
                textBox23.Clear();
                textBox24.Clear();
                textBox25.Clear();
                textBox26.Clear();
                textBox27.Clear();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string script = "update manufacturers set name = '" + textBox31.Text + "', adress = '" + textBox30.Text + "', num_phone = '" + textBox29.Text + "', fio_contact_person = '" + textBox28.Text + "' where id_manufacturer = '" + textBox32.Text + "';";
            string script1 = "update manufacturers set name = '" + textBox31.Text + "' where id_manufacturer = '" + textBox32.Text + "';";
            string script2 = "update manufacturers set adress = '" + textBox30.Text + "' where id_manufacturer = '" + textBox32.Text + "';";
            string script3 = "update manufacturers set num_phone = '" + textBox29.Text + "' where id_manufacturer = '" + textBox32.Text + "';";
            string script4 = "update manufacturers set fio_contact_person = '" + textBox28.Text + "' where id_manufacturer = '" + textBox32.Text + "';";
            if (textBox32.Text != "" && textBox31.Text != "" && textBox30.Text != "" && textBox29.Text != "" && textBox28.Text != "")
            {
                get_info(script + query2);
                textBox31.Clear();
                textBox30.Clear();
                textBox29.Clear();
                textBox28.Clear();
            }
            else if (textBox31.Text != "")
            {
                get_info(script1 + query2);
                textBox31.Clear();
            }
            else if (textBox30.Text != "")
            {
                get_info(script2 + query2);
                textBox30.Clear();
            }
            else if (textBox29.Text != "")
            {
                get_info(script3 + query2);
                textBox29.Clear();
            }
            else if (textBox28.Text != "")
            {
                get_info(script4 + query2);
                textBox28.Clear();
            }
            else if (textBox32.Text == "")
            {
                MessageBox.Show("Заполните ID производителя!");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string script = "delete from manufacturers where id_manufacturer = '" + textBox33.Text + "';";
            if (textBox33.Text != "")
            {
                get_info(script + query2);
                textBox33.Clear();
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 Win = new Form3(ID);
            this.Close();
            Win.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }

        private void просмотрШаблоновХарактеристикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 Win = new Form5(ID);
            this.Hide();
            Win.Show();
        }

        private void главноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Win = new Form2(ID);
            this.Close();
            Win.Show();
        }
    }
}
