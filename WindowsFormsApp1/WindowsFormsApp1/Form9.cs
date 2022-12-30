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
    public partial class Form9 : Form
    {
        public int ID = 0;
        string query = "select id_customer as 'ID клиента', fio_customer as 'ФИО', birthday as 'Дата рождения', num_phone as 'Номер телефона', series as 'Серия паспорта', number as 'Номер паспорта', date_of_issue as 'Дата выдачи', issuing_authority as 'Орган выдачи' from customers join passport on customers.id_passport = passport.id_passport;";
        public Form9(int ID_login)
        {
            InitializeComponent();
            ID = ID_login;
            get_info(query);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string script = "select id_customer as 'ID клиента', fio_customer as 'ФИО', birthday as 'Дата рождения', num_phone as 'Номер телефона', series as 'Серия паспорта', number as 'Номер паспорта', date_of_issue as 'Дата выдачи', issuing_authority as 'Орган выдачи' from customers join passport on customers.id_passport = passport.id_passport where fio_customer = '" + textBox1.Text + "';";
            string script1 = "select id_customer as 'ID клиента', fio_customer as 'ФИО', birthday as 'Дата рождения', num_phone as 'Номер телефона', series as 'Серия паспорта', number as 'Номер паспорта', date_of_issue as 'Дата выдачи', issuing_authority as 'Орган выдачи' from customers join passport on customers.id_passport = passport.id_passport where series = '" + textBox1.Text + "';";
            string script2 = "select id_customer as 'ID клиента', fio_customer as 'ФИО', birthday as 'Дата рождения', num_phone as 'Номер телефона', series as 'Серия паспорта', number as 'Номер паспорта', date_of_issue as 'Дата выдачи', issuing_authority as 'Орган выдачи' from customers join passport on customers.id_passport = passport.id_passport where number = '" + textBox1.Text + "';";
            try
            {
                if (comboBox1.Text == "ФИО" && textBox1.Text != "")
                {
                    get_info(script);
                    textBox1.Clear();
                }
                else if (comboBox1.Text == "Серии паспорта" && textBox1.Text != "")
                {
                    get_info(script1);
                    textBox1.Clear();
                }
                else if (comboBox1.Text == "Номеру паспорта" && textBox1.Text != "")
                {
                    get_info(script2);
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

        private void button3_Click(object sender, EventArgs e)
        {
            get_info(query);
        }
    }
}
