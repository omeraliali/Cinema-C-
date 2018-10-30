using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Word;



namespace loginsample1
{
    
    public partial class AddressBook : Form
    {

        public AddressBook()
        {
            InitializeComponent();
        }

       
        List<Person> people = new List<Person>();
        private void AddressBook_Load(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(path + @"C:\Users\saida\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml"))
                //Directory.CreateDirectory(path + @"C:\Users\said\Documents\Harhaysa copy - Copy\New Prive folder\loginsample1C#\settings.xml");
                if (!File.Exists(path + @"C:\Users\saida\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml"))
                {
                }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\saida\Documents\HNC\Falguni\Unit 20\loginsample1C#\settings.xml");
            foreach (XmlNode xNode in xDoc.SelectNodes("People/Person"))
            {
                Person p = new Person();
                p.Name = xNode.SelectSingleNode("Name").InnerText;
                p.Email = xNode.SelectSingleNode("Email").InnerText;
                p.StreetAddress = xNode.SelectSingleNode("Address").InnerText;
                p.AditionNotes = xNode.SelectSingleNode("Notes").InnerText;
                p.Birthday = DateTime.FromFileTime(Convert.ToInt64(xNode.SelectSingleNode("Birthday").InnerText));
                people.Add(p);
                listView1.Items.Add(p.Name);



            }
            }

        //this is commented out becouse there is another Addbtn down below
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    {
        //        XmlDocument xDoc = new XmlDocument();
        //        xDoc.Load(@"C:\Users\said\Documents\Harhaysa copy - Copy\New Prive folder\loginsample1C#\settings.xml");
        //        //with the code below i can also use for showing the data with txt box
        //        MessageBox.Show/*(xDoc.SelectSingleNode("People / Person / Name").InnerText);*/("YOU ARE ABOUT TO VIEW ALL THE DATA FOR SILC MEMBERS");
        //        foreach (XmlNode xNode in xDoc.SelectNodes("People/Person"))
        //        {

        //            Person p = new Person();
        //            p.Name = xNode.SelectSingleNode("Name").InnerText;
        //            p.Email = xNode.SelectSingleNode("Email").InnerText;
        //            p.StreetAddress = xNode.SelectSingleNode("Address").InnerText;
        //            p.AditionNotes = xNode.SelectSingleNode("Notes").InnerText;
        //            p.Birthday = DateTime.FromFileTime(Convert.ToInt64(xNode.SelectSingleNode("Birthday").InnerText));
        //            people.Add(p);
        //            // here the name will be shown in the list view
        //            listView1.Items.Add(xNode.SelectSingleNode("Name").InnerText);
        //            //listView1.Items.Add(xNode.SelectSingleNode("Email").InnerText);
        //            //listView1.Items.Add(xNode.SelectSingleNode("Address").InnerText);


        //            //listView1.Items.Add(p.Name);
        //        }
        //    }
        //}



        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }
        void Remove()
        {
            try
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
                people.RemoveAt(listView1.SelectedItems[0].Index);
            }
            catch { }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string listItem = listView1.SelectedItems[0].Text;
                textBox1.Text = listItem;
           

            people[listView1.SelectedItems[0].Index].Name = textBox1.Text;
            people[listView1.SelectedItems[0].Index].Email = textBox2.Text;
            people[listView1.SelectedItems[0].Index].StreetAddress = txtBoxStreetAddress.Text;
            people[listView1.SelectedItems[0].Index].AditionNotes = txtBoxAdionNotes.Text;
            people[listView1.SelectedItems[0].Index].Birthday = dateTimePicker1.Value;
            listView1.SelectedItems[0].Text = textBox1.Text;
            }


        }
        private void button4_Click(object sender, EventArgs e)
        {// this event is also important. it helps form closing event below to write the data on the XML file when closing the form
           string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //XmlDocument xDoc = new XmlDocument();
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //xDoc.Load(@"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
        

        //private void AddressBook_FormClosing(object sender, FormClosingEventArgs e)



            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\saida\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
            XmlNode xNode = xDoc.SelectSingleNode("people");
            XmlElement ParentElement = xDoc.CreateElement("people");
            //xNode.RemoveAll();
            foreach (Person p in people)
            {
                XmlNode xTop = xDoc.CreateElement("Person");
                XmlNode xName = xDoc.CreateElement("Name");
                XmlNode xEmail = xDoc.CreateElement("Email");
                XmlNode xAddress = xDoc.CreateElement("Address");
                XmlNode xNotes = xDoc.CreateElement("Notes");
                XmlNode xBirthday = xDoc.CreateElement("Birthday");
                xName.InnerText = p.Name;
                xEmail.InnerText = p.Email;
                xAddress.InnerText = p.StreetAddress;
                xNotes.InnerText = p.AditionNotes;
                xBirthday.InnerText = p.Birthday.ToFileTime().ToString();
                xTop.AppendChild(xName);
                xTop.AppendChild(xEmail);
                xTop.AppendChild(xAddress);
                xTop.AppendChild(xNotes);
                xTop.AppendChild(xBirthday);
                xDoc.DocumentElement.AppendChild(xTop);
            }
            xDoc.Save(@"C:\Users\saida\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");    
        }


 
        private void btnShowMember_Click(object sender, EventArgs e)
        
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"C:\Users\saida\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
                //with the code below i can also use for showing the data with txt box
                MessageBox.Show/*(xDoc.SelectSingleNode("People / Person / Name").InnerText);*/("YOU ARE ABOUT TO VIEW ALL THE DATA FOR SILC MEMBERS");
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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
                 XmlDocument xDoc = new XmlDocument();
                 xDoc.Load(@"C:\Users\saida\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
                //with the code below i can also use for showing the data with txt box
                MessageBox.Show/*(xDoc.SelectSingleNode("People / Person / Name").InnerText);*/("YOU ARE ABOUT TO VIEW ALL THE DATA FOR SILC MEMBERS");
                foreach (XmlNode xNode in xDoc.SelectNodes("People/Person"))
                {

                    Person p = new Person();
                    p.Name = xNode.SelectSingleNode("Name").InnerText;
                    p.Email = xNode.SelectSingleNode("Email").InnerText;
                    p.StreetAddress = xNode.SelectSingleNode("Address").InnerText;
                    p.AditionNotes = xNode.SelectSingleNode("Notes").InnerText;
                    p.Birthday = DateTime.FromFileTime(Convert.ToInt64(xNode.SelectSingleNode("Birthday").InnerText));
                    people.Add(p);
                    // here the name will be shown in the list view
                    listView1.Items.Add(xNode.SelectSingleNode("Name").InnerText);
                    //listView1.Items.Add(xNode.SelectSingleNode("Email").InnerText);
                    //listView1.Items.Add(xNode.SelectSingleNode("Address").InnerText);


                    //listView1.Items.Add(p.Name);
                }
            }
        // this code below works together with btnAd above
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (listView1.SelectedItems.Count > 0)
            {// this code is very important for the 0 integer as it selects it and you can swith to the other member without having an error
                string listItem = listView1.SelectedItems[0].Text;
                textBox1.Text = listItem;

                textBox1.Text = people[listView1.SelectedItems[0].Index].Name;
                textBox2.Text = people[listView1.SelectedItems[0].Index].Email;
                txtBoxStreetAddress.Text = people[listView1.SelectedItems[0].Index].StreetAddress;
                txtBoxAdionNotes.Text = people[listView1.SelectedItems[0].Index].AditionNotes;
                dateTimePicker1.Value = people[listView1.SelectedItems[0].Index].Birthday;

            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //this event allows you to write the members and only the name of the member appers on the listview after creating the member
            Person p = new Person();
            p.Name = textBox1.Text;
            p.StreetAddress = txtBoxStreetAddress.Text;
            p.Email = textBox2.Text;
            p.Birthday = dateTimePicker1.Value;
            p.AditionNotes = txtBoxAdionNotes.Text;
            people.Add(p);
            listView1.Items.Add(p.Name);
            // as shown here only the name of the member will come on the listview
            textBox1.Text = "";
            textBox2.Text = "";
            txtBoxStreetAddress.Text = "";
            txtBoxAdionNotes.Text = "";
            dateTimePicker1.Value = DateTime.Now;
             
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            try
            {
                people.RemoveAt(listView1.SelectedItems[0].Index);
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            catch { }



            //string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //XmlDocument xDoc = new XmlDocument();
            //xDoc.Load(@"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
            ////XmlNode xNode = xDoc.SelectSingleNode("people");
            //// XmlElement ParentElement = xDoc.CreateElement("people");
            ////xNode.RemoveAll();
            //foreach (Person p in people)
            //{
            //    XmlNode xTop = xDoc.CreateElement("Person");
            //    XmlNode xName = xDoc.CreateElement("Name");
            //    XmlNode xEmail = xDoc.CreateElement("Email");
            //    XmlNode xAddress = xDoc.CreateElement("Address");
            //    XmlNode xNotes = xDoc.CreateElement("Notes");
            //    XmlNode xBirthday = xDoc.CreateElement("Birthday");
            //    xName.InnerText = p.Name;
            //    xEmail.InnerText = p.Email;
            //    xAddress.InnerText = p.StreetAddress;
            //    xNotes.InnerText = p.AditionNotes;
            //    xBirthday.InnerText = p.Birthday.ToFileTime().ToString();
            //    xTop.AppendChild(xName);
            //    xTop.AppendChild(xEmail);
            //    xTop.AppendChild(xAddress);
            //    xTop.AppendChild(xNotes);
            //    xTop.AppendChild(xBirthday);
            //    xDoc.DocumentElement.AppendChild(xTop);



            //}
            //xDoc.Save(@"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
               
           
               
           
         
        }

        private void AddressBook_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void AddressBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\saida\Documents\HNC\Falguni\Unit 20\loginsample1C#\settings.xml");
           
            //this code below empty existing xml file to avoid duplicate 
            XmlNode xNode = xDoc.SelectSingleNode("People");
            XmlElement ParentElement = xDoc.CreateElement("People");
            xNode.RemoveAll();
            
            foreach (Person p in people)
            {
                XmlNode xTop = xDoc.CreateElement("Person");
                XmlNode xName = xDoc.CreateElement("Name");
                XmlNode xEmail = xDoc.CreateElement("Email");
                XmlNode xAddress = xDoc.CreateElement("Address");
                XmlNode xNotes = xDoc.CreateElement("Notes");
                XmlNode xBirthday = xDoc.CreateElement("Birthday");
                xName.InnerText = p.Name;
                xEmail.InnerText = p.Email;
                xAddress.InnerText = p.StreetAddress;
                xNotes.InnerText = p.AditionNotes;
                xBirthday.InnerText = p.Birthday.ToFileTime().ToString();
                xTop.AppendChild(xName);
                xTop.AppendChild(xEmail);
                xTop.AppendChild(xAddress);
                xTop.AppendChild(xNotes);
                xTop.AppendChild(xBirthday);
                xDoc.DocumentElement.AppendChild(xTop);



            }
            xDoc.Save(@"C:\Users\saida\Documents\HNC\Falguni\Unit 20\loginsample1C#\settings.xml");
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
         

        public class Person
        {
            public string Name
            {
                get;
                set;
            }
            public string Email
            {
                get;
                set;
            }
            public string StreetAddress
            {
                get;
                set;
            }
            public string AditionNotes
            {
                get;
                set;
            }
            public DateTime Birthday
            {
                get;
                set;

           
            }
           
 
        }
       
         


