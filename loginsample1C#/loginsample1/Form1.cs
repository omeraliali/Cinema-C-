using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace loginsample1
{
    public partial class Form1 : Form
    {
        public string user { get; private set; }
        OleDbConnection conn = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 6;
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\Account.accdb; Persist Security Info=False;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                         
                conn.Open();
                label1.Text = "Connection successful";
                conn.Close();
            }
            catch (Exception eb)
            {
                MessageBox.Show("Error" + eb);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = conn;
            command.CommandText = "Select *from Member where Username= '" + textBox1.Text + "'and Password= '" + textBox2.Text + "'";
            OleDbDataReader read = command.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count++;
            }
            if (count==1)
            {
                MessageBox.Show("Login successful");
                user = textBox1.Text;
                conn.Close();
                conn.Dispose();
                command.Dispose();
                this.Hide();
                btnTable f2 = new btnTable(this);
                f2.ShowDialog();


            }
            else
            {
                MessageBox.Show("Error Wrong Details");

            }
            if (count > 1)
            {
                MessageBox.Show("Duplicate username");
               

            }
            else
            {
                MessageBox.Show("login successful");
                
            }
            conn.Close();
            read.Close();
            
            command.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
