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
    public partial class Admin : Form
    {
        public static MySqlConnection connect = new MySqlConnection("server = 88.206.75.80; port = 3306;" +
        "user = bibi; password = 0987; database = cafedatabase;");
        // чет не раб привяз форм
        public Admin()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAdmin add = new AddAdmin();
            add.Show();
            this.Hide();
            
        }
        void Add()
        {
            connect.Open();
            string user = "SELECT*FROM `user`";
            MySqlCommand command = new MySqlCommand(user, connect);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> list = new List<string[]>();
            while (reader.Read())
            {
                list.Add(new string[7]);
                list[list.Count - 1][0] = reader[0].ToString();
                list[list.Count - 1][1] = reader[1].ToString();
                list[list.Count - 1][2] = reader[2].ToString();
                list[list.Count - 1][3] = reader[3].ToString();
                list[list.Count - 1][4] = reader[4].ToString();
                list[list.Count - 1][5] = reader[5].ToString();
                list[list.Count - 1][6] = reader[6].ToString();
            }
            foreach (string[] s in list)
                dataGridView1.Rows.Add(s);
            connect.Close();
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            Add();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeAdmin changeAdmin = new ChangeAdmin();
            changeAdmin.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
