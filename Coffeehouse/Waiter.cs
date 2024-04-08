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
    public partial class Waiter : Form
    {
        public static MySqlConnection connect = new MySqlConnection("server = 88.206.75.80; port = 3306;" +
        "user = bibi; password = 0987; database = cafedatabase;");
        public Waiter()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderWaiter waiter = new OrderWaiter();
            waiter.Show();
            this.Hide();
        }
        void Table() 
        {
            connect.Open();
            string order = "SELECT * FROM `order`";
            MySqlCommand command = new MySqlCommand(order, connect);
            MySqlDataReader reader = command.ExecuteReader();
            List<string[]> list = new List<string[]>();
            while (reader.Read())
            {
                list.Add(new string[6]);
                list[list.Count - 1][0] = reader[0].ToString();
                list[list.Count - 1][1] = reader[1].ToString();
                list[list.Count - 1][2] = reader[2].ToString();
                list[list.Count - 1][3] = reader[3].ToString();
                list[list.Count - 1][4] = reader[4].ToString();
                list[list.Count - 1][5] = reader[5].ToString();
            }
            foreach (string[] s in list)
                dataGridView1.Rows.Add(s);
            connect.Close();
        }
        private void Waiter_Load(object sender, EventArgs e)
        {
            Table();
        }
    }
}
