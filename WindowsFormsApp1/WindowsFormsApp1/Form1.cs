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
    public partial class Form1 : Form
    {
        string query = "select * from employees;";
        public Form1()
        {
            InitializeComponent();
        }
        public void get_info(string query)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 5000;
            t.Start();
            t.Tick += new EventHandler(t_Tick);
            try
            {
                MySqlConnection connection = DBUtils.GetDBConnection();
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmDB.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("fio_employee"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }
        void t_Tick(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select id_employee from employees join authorization on employees.id_authorization = authorization.id_authorization where fio_employee = '" + comboBox1.Text + "' and password = '" + textBox1.Text + "';";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {                   
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                int result = 0;
                result = Convert.ToInt32(cmDB.ExecuteScalar());
                if (result > 0)
                {
                    label2.Visible = true;
                    label2.Text = "Авторизация прошла успешно!";
                    MessageBox.Show("Здравствуйте, " + comboBox1.Text + "!");
                    Form2 Win = new Form2(result);
                    Win.Owner = this;
                    this.Hide();
                    Win.Show();
                    textBox1.Clear();
                    cmDB.ExecuteNonQuery();
                }
                else if (String.IsNullOrWhiteSpace(textBox1.Text) && String.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    label1.Visible = true;
                    label1.Text = "Поля ФИО и Пароль не заполнены!";
                }
                else if (String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    label1.Visible = true;
                    label1.Text = "Поле Пароль не заполнено!";
                }
                else if (String.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    label1.Visible = true;
                    label1.Text = "Выберите ФИО сотрудника!";
                }
                else if (result == 0)
                {
                    label1.Visible = true;
                    label1.Text = "Введен неправильный пароль!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Выход", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
