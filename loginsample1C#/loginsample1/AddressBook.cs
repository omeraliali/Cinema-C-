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
            if (!Directory.Exists(path + @"\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#"))
               Directory.CreateDirectory(path + @"\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#");
            if (!File.Exists(path + @"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml"))
            {   
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
            foreach (XmlNode xNode in xDoc.SelectNodes("people/Person/Name"))
            {
                Person p = new Person();
                p.Name = xNode.SelectSingleNode("Name").InnerText;
                p.Email = xNode.SelectSingleNode("Email").InnerText;
                p.StreetAddress = xNode.SelectSingleNode("StreetAddress").InnerText;
                p.AditionNotes = xNode.SelectSingleNode("Notes").InnerText;
                p.Birthday = DateTime.FromFileTime(Convert.ToInt64(xNode.SelectSingleNode("Birthday").InnerText));
                people.Add(p);
                listView1.Items.Add(p.Name);



            }

        //}
        }

        private void button2_Click(object sender, EventArgs e)
        {//this event allows you to write the members and only the name of the member appers on the listview after creating the member
            Person p = new Person();
            p.Name = textBox1.Text;
            p.StreetAddress = textBox3.Text;
            p.Email = textBox2.Text;
            p.Birthday = dateTimePicker1.Value;
            p.AditionNotes = textBox4.Text;
            people.Add(p);
            listView1.Items.Add(p.Name);
            // as shown here only the name of the member will come on the listview
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;
             
        }
   

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {                
           // int j = listView1.Items.Count ;
           // int n;
           // int[] i = new int[j];
           // for (n = 0; n < i.Length - 1; n++)
           //{
            if (listView1.SelectedItems.Count > 0)
            {// this code is very important for the 0 integer as it selects it and you can swith to the other member without having an error
                string listItem = listView1.SelectedItems[0].Text;
                textBox1.Text = listItem;
           
                textBox1.Text = people[listView1.SelectedItems[0].Index].Name;
                textBox2.Text = people[listView1.SelectedItems[0].Index].Email;
                textBox3.Text = people[listView1.SelectedItems[0].Index].StreetAddress;
                textBox4.Text = people[listView1.SelectedItems[0].Index].AditionNotes;
                dateTimePicker1.Value = people[listView1.SelectedItems[0].Index].Birthday;
            //}
            }  

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                people.RemoveAt(listView1.SelectedItems[0].Index);

                listView1.Items.Remove(listView1.SelectedItems[0]);
              
            }﻿
            catch { }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string listItem = listView1.SelectedItems[0].Text;
                textBox1.Text = listItem;
           

            people[listView1.SelectedItems[0].Index].Name = textBox1.Text;
            people[listView1.SelectedItems[0].Index].Email = textBox2.Text;
            people[listView1.SelectedItems[0].Index].StreetAddress = textBox3.Text;
            people[listView1.SelectedItems[0].Index].AditionNotes = textBox4.Text;
            people[listView1.SelectedItems[0].Index].Birthday = dateTimePicker1.Value;
            listView1.SelectedItems[0].Text = textBox1.Text;
            }


        }
        private void button4_Click(object sender, EventArgs e)
        {// this event is also important. it helps form closing event below to write the data on the XML file when closing the form
            XmlDocument xDoc = new XmlDocument();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            xDoc.Load(@"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
        }

        private void AddressBook_FormClosing(object sender, FormClosingEventArgs e)
        {
             string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
            //XmlNode xNode = xDoc.SelectSingleNode("people");
           // XmlElement ParentElement = xDoc.CreateElement("people");
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
            xDoc.Save(@"C:\Users\said\Documents\Harhaysa copy\Falguni\Unit 20\loginsample1C#\settings.xml");
               
           
               
           
         
        }




        private void btnAddxml_Click(object sender, EventArgs e)
        {
            
                

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
       
         
}

