using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffeehouse
{
    public partial class Form1 : Form
    {
        public static MySqlConnection connect = new MySqlConnection("server = 88.206.75.80; port = 3306;" +
        "user = bibi; password = 0987; database = cafedatabase;");
        public Form1()
        {
            InitializeComponent();
        }
        string name;
        string password;
        string role;
        string status;
        void Avtoriz() {

            string nameUser = textBox1.Text;
            string passwordUser = textBox2.Text;
            connect.Open();
            string user = "SELECT*FROM user";
            MySqlCommand command = new MySqlCommand(user, connect);
            MySqlDataReader reader = command.ExecuteReader();
            for (int a = 0; a < 3; a++)
            {
                while (reader.Read() && name != nameUser)
                {
                    name = reader.GetString(0);
                    password = reader.GetString(3);
                    role = reader.GetString(1);
                    status = reader.GetString(4);
                    break;
                }
            }

            if (password == passwordUser && name == nameUser && status != "уволен")
            {
                switch (role)
                {
                    case "admin":
                        Admin ad = new Admin();
                        ad.Show();
                        this.Hide();
                        break;
                    case "cook":
                        Cook co = new Cook();
                        co.Show();
                        this.Hide();
                        break;
                    case "waiter":
                        Waiter wai = new Waiter();
                        wai.Show();
                        this.Hide();
                        break;
                }
            }
            else
                MessageBox.Show("введены некорректные данные!");
            connect.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Avtoriz();
        }
    }
}
