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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coffeehouse
{
    public partial class ChangeAdmin : Form
    {
        public static MySqlConnection connect = new MySqlConnection("server = 88.206.75.80; port = 3306;" +
        "user = bibi; password = 0987; database = cafedatabase;");
        public ChangeAdmin()
        {
            InitializeComponent();
        }
        
        private void ChangeAdmin_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO user (name, role, status)" +
                "values (@name, @role, @telephone, @pass, @status)");
            command.Connection = connect;
            command.Parameters.AddWithValue("name", textBox1.Text);
            command.Parameters.AddWithValue("role", textBox2.Text);
            command.Parameters.AddWithValue("telephone", textBox3.Text);
            command.Parameters.AddWithValue("pass", textBox4.Text);
            command.Parameters.AddWithValue("status", textBox5.Text);
            command.ExecuteNonQuery();
            connect.Close();
            this.Hide();
            Admin admin = new Admin();
            admin.Show();
        }
    }
}
