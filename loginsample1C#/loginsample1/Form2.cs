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
    public partial class btnTable : Form
    {

        Form1 _f1;
        OleDbConnection conn = new OleDbConnection();
        DataTable dt = new DataTable();

        public btnTable(Form1 f1_)
        {
            InitializeComponent();

            this._f1 = f1_;
            label5.Text = "Welcome  " + this._f1.user;

            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\Account.accdb; Persist Security Info=False;";
        }


        List<Person> people = new List<Person>();
        private void Form2_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //if (!Directory.Exists(path + @"\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#"))
            //    Directory.CreateDirectory(path + @"\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#");
            if (!File.Exists(path + @"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml"))
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
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
            foreach (XmlNode xNode in xDoc.SelectNodes("Poeple/Person/Name"))
            {

                Person p = new Person();
                p.Name = xNode.SelectSingleNode("Name").InnerText;
                p.Email = xNode.SelectSingleNode("Email").InnerText;
                p.StreetAddress = xNode.SelectSingleNode("StreetAddress").InnerText;
                p.AditionNotes = xNode.SelectSingleNode("Notes").InnerText;
                p.Birthday = DateTime.FromFileTime(Convert.ToInt64(xNode.SelectSingleNode("Birthday").InnerText));
                people.Add(p);
                listView1.Items.Add(p.Name);
                listView1.Items.Add(p.Email);
                listView1.Items.Add(p.StreetAddress);
                listView1.Items.Add(p.Name);
            }
        }




    }

}

