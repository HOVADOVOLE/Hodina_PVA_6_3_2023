using MySql.Data;
using MySql.Data.MySqlClient;

namespace Rename_Later
{
    public partial class Form1 : Form
    {
        string command;

        MySqlConnection conn;
        MySqlCommand cmd = new MySqlCommand();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connection = "server=localhost;uid=root;pwd=;database=sakila";
            conn = new MySqlConnection(connection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            command = $"INSERT INTO actor(first_name) VALUES('{textBox1.Text}');";
            cmd = new MySqlCommand(command, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            listBox1.Items.Clear();

            command = "Select first_name from actor";
            cmd = new MySqlCommand(command, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add($"{reader.GetString(0)}");
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string name = listBox1.SelectedItem.ToString();
            
            command = $"delete from actor where first_name = '{name}'";
            

            cmd = new MySqlCommand(command, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}