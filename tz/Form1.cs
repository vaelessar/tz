using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace tz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string constring = "Host=localhost;Username=postgres;Password=123;Database=postgres";
        string query;
        private void button1_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(constring);
            connection.Open();
            query = $"INSERT INTO public.texts(parag) VALUES('{richTextBox1.Text}');";
            var command = new NpgsqlCommand(query, connection);
            var write = command.ExecuteNonQuery();
            connection.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(constring);
            connection.Open();
            query = $"SELECT parag FROM public.texts WHERE id={textBox1.Text};";
            var command = new NpgsqlCommand(query, connection);
            var reader = command.ExecuteReader();
            if (reader.Read()) richTextBox1.Text = String.Format("{0}", reader[0]);
            else MessageBox.Show("Something's wrong");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = null;
        }
    }
}
