using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffeehouse
{
    public partial class OrderWaiter : Form
    {
        public static MySqlConnection connect = new MySqlConnection("server = 88.206.75.80; port = 3306;" +
        "user = bibi; password = 0987; database = cafedatabase;");
        public OrderWaiter()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO `order` (name, table, client, dish, drink, status)" +
                "values (@name, @table, @client, @dish, @drink, @status)");
            command.Connection = connect;
            command.Parameters.AddWithValue("name", textBox3.Text);
            command.Parameters.AddWithValue("table", textBox1.Text);
            command.Parameters.AddWithValue("client", textBox2.Text);
            command.Parameters.AddWithValue("dish", textBox5.Text);
            command.Parameters.AddWithValue("drink", textBox4.Text);
            command.Parameters.AddWithValue("status", textBox6.Text);
            command.ExecuteNonQuery();
            connect.Close();
            this.Hide();
            Waiter waiter = new Waiter();
            waiter.Show();
        }
    }
}
