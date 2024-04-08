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
    public partial class AddAdmin : Form
    {
        public static MySqlConnection connect = new MySqlConnection("server = 88.206.75.80; port = 3306;" +
        "user = bibi; password = 0987; database = cafedatabase;");
        public AddAdmin()
        {
            InitializeComponent();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            MySqlCommand command = new MySqlCommand("REPLACE INTO user ()"); 
        }

        private void AddAdmin_Load(object sender, EventArgs e)
        {
            Users();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO user (name, role, telephone,pass, status)" +
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
        void Users() 
        {
            connect.Open();
            string user = "SELECT*FROM user";
            MySqlCommand command = new MySqlCommand(user, connect);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> list = new List<string[]>();
            while (reader.Read())
            {
                list.Add(new string[2]);
                list[list.Count - 1][0] = reader[0].ToString();
                list[list.Count - 1][1] = reader[1].ToString();
            }
            foreach (string[] s in list)
            {
                comboBox1.Items.Add(s[0]);
                comboBox2.Items.Add(s[1]);
            }
                
                
            connect.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
