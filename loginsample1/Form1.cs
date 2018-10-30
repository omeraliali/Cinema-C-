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
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\saida\Documents\HNC\Falguni\Unit 20\loginsample1C#\Account.accdb; Persist Security Info=False;";
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
                BtnTable f2 = new BtnTable(this);
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //i have used pieces of the commented code below and aded path name @ and Doc1.docx at the end also changed Application application to Application app
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            string path = (@"C:\Users\saida\Documents\HNC\Falguni\Unit 20\loginsample1C#\Doc1.docx");
            app.Visible = true;
            app.Documents.Open(path);
            ////OpenFileDialog ofd = new OpenFileDialog();
            ////ofd.Filter = "DOCX|*.docx";
            ////if (ofd.ShowDialog() == DialogResult.OK)
            ////{
            ////    // set the file name from the open file dialog
            ////    // object fileName = openFileDialog1.FileName;
            ////object readOnly = true;
            ////    object isVisible = true;

            //    //{
            //        // Open a doc file.
            //        Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            //        Document document = application.Documents.Open("C:\\Users\\said\\Documents\\Harhaysa copy - Copy\\Falguni\\Unit 20\\loginsample1C#");
          
        }
    }
}
