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
using System.IO;
using System.Xml;


namespace loginsample1
{
    public partial class BtnTable : Form
    {
        Form1 _f1;
        OleDbConnection conn = new OleDbConnection();
        DataTable dt = new DataTable();

       public BtnTable(Form1 f1_)
        {
            InitializeComponent();

            this._f1 = f1_;
            label5.Text = "Welcome  " + this._f1.user;
            //this is the connection with acces databaser used by login form
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\saida\Documents\HNC\Falguni\Unit 20\loginsample1C#\Account.accdb; Persist Security Info=False;";
        }

        // this list is the list with XML database
        List<Person> people = new List<Person>();
        private void Form2_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); 
            if (!Directory.Exists(path + @"C:\Users\saida\Documents\HNC\Falguni\Unit 20\loginsample1C#\settings.xml"))
               // Directory.CreateDirectory(path + @"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
            if (!File.Exists(path + @"C:\Users\said\Documents\HNC\Falguni\Unit 20\loginsample1C#\settings.xml"))
            {

            }
        }
        //{
        //           string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //           if (!Directory.Exists(path + @"\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#"))
        //              Directory.CreateDirectory(path + @"\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#");
        //           if (!File.Exists(path + @"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml"))
        //            //{
        //            //    XmlDocument xDoc = new XmlDocument();
        //               //this piece of code allows you to create your XML file within the project file
        //           {
        //               //XmlTextWriter xW = new XmlTextWriter(@"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml", Encoding.UTF8);
        //               //xW.WriteStartElement("People");
        //               //xW.WriteEndElement();
        //               //xW.Close();

        //           }

        //           XmlDocument xDoc = new XmlDocument();
        //           xDoc.Load(@"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
        //           foreach (XmlNode xNode in xDoc.SelectNodes("people/Person/Name"))
        //           {
        //               Person p = new Person();
        //               p.Name = xNode.SelectSingleNode("Name").InnerText;
        //               p.Email = xNode.SelectSingleNode("Email").InnerText;
        //               p.StreetAddress = xNode.SelectSingleNode("StreetAddress").InnerText;
        //               p.AditionNotes = xNode.SelectSingleNode("Notes").InnerText;
        //               p.Birthday = DateTime.FromFileTime(Convert.ToInt64(xNode.SelectSingleNode("Birthday").InnerText));
        //               people.Add(p);
        //               listView1.Items.Add(p.Name);



        //           }

        //       //}
        //       }


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AddressBook ss = new AddressBook();
            ss.Show();
        }

        private void btnShowMember_Click(object sender, EventArgs e)
        //{
            //this works but opens the OpenFileDialog first
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "XML|*.xml";
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\saida\Documents\HNC\Falguni\Unit 20\loginsample1C#\settings.xml");
            //with the code below i can also use for showing the data with txt box
            MessageBox.Show/*(xDoc.SelectSingleNode("People / Person / Name").InnerText);*/("YOU ARE ABOUT TO VIEW ALL THE DATA FOR SILC CINEMA");
            foreach (XmlNode xNode in xDoc.SelectNodes("People/Person"))
            {

                Person p = new Person();
                p.Name = xNode.SelectSingleNode("Name").InnerText;
                p.Email = xNode.SelectSingleNode("Email").InnerText;
                p.StreetAddress = xNode.SelectSingleNode("Address").InnerText;
                p.AditionNotes = xNode.SelectSingleNode("Notes").InnerText;
                p.Birthday = DateTime.FromFileTime(Convert.ToInt64(xNode.SelectSingleNode("Birthday").InnerText));
                people.Add(p);
                //here the name will be shown in the list view
                listView1.Items.Add(xNode.SelectSingleNode("Name").InnerText);
             }
            }
        //}
        //private void button4__Click(object sender, EventArgs e)
        //{
        //    Person p = new Person();
        //    p.Name = textBox1.Text;
        //    //p.StreetAddress = StreetAddress;
        //    p.Email = textBox2.Text;
        //    p.Birthday = dateTimePicker1.Value;
        //    p.AditionNotes = txtBoxAdionNotes.Text;
        //    people.Add(p);
        //    listView1.Items.Add(p.Name);
        //    // as shown here only the name of the member will come on the listview and then cleares the texts
        //    textBox1.Text = "";
        //    textBox2.Text = "";
        //    //txtBoxStreetAddress.Text = "";
        //    txtBoxAdionNotes.Text = "";
        //    dateTimePicker1.Value = DateTime.Now;
        //}

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {       
                if (listView1.SelectedItems.Count > 0)
                {// this code is very important for the 0 integer as it selects it and you can swith to the other member without having an error
                    string listItem = listView1.SelectedItems[0].Text;
                    textBox1.Text = listItem;

                    textBox1.Text = people[listView1.SelectedItems[0].Index].Name;
                    textBox2.Text = people[listView1.SelectedItems[0].Index].Email;
                    textBox3.Text = people[listView1.SelectedItems[0].Index].StreetAddress;
                    txtBoxAdionNotes.Text = people[listView1.SelectedItems[0].Index].AditionNotes;
                    dateTimePicker1.Value = people[listView1.SelectedItems[0].Index].Birthday;
                }


            
        }

        private void txtBoxAdionNotes_TextChanged(object sender, EventArgs e)
        {

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

