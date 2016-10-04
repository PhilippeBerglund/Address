using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdressBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // List<Person> personFile = new List<Person>();

        public List<string> UpdateList = new List<string>();

      
        public void buttonSave_Click(object sender, EventArgs e)
        {
           // Person person = new Person
        
                var FirstName = textBoxFirst.Text;
                var SecondName = textBoxSecond.Text;
                var Email = textBoxEmail.Text;
                var Phone = textBoxPhone.Text;
                var Address = textBoxAdress.Text;
                var Zip = textBoxZip.Text;
                var City = textBoxCity.Text;
            

            textBoxFirst.Clear();
            textBoxSecond.Clear();
            textBoxEmail.Clear();
            textBoxPhone.Clear();
            textBoxAdress.Clear();
            textBoxZip.Clear();
            textBoxCity.Clear();


            //person.Save(person.FirstName, person.SecondName, person.Email, person.Phone, person.Address, person.Zip,
            //    person.City);


            string toSave = FirstName + "," + SecondName + "," + Email + "," + Phone + "," +
                            Address + "," + Zip + "," + City;

            using (
                StreamWriter path =
                    new StreamWriter(@"C:\Users\phili\Desktop\Prog16\AdressBook\AdressBook\AddressBookLogg.txt", true))
            {
                path.WriteLine(toSave);
            }

            MessageBox.Show("Save Successful!");

        }



        List<string> LoadFile()
        {
            List<string> personFile = new List<string>();
            string path = "C:\\Users\\phili\\Desktop\\Prog16\\AdressBook\\AdressBook\\AddressBookLogg.txt";
            StreamReader sr = new StreamReader(path);
            string pline;
            while ((
                pline
                    =
                    sr.ReadLine
                        ()) != null)
            {
                personFile.Add(pline);
            }
            sr.Close
                ();
            return
                personFile;

        }



        public List<string> GetNamesFromFile(string combo, string search)

        {
            int index = 0;

            if (combo == "Last Name")
            {
                index = 1;
            }

            if (combo == "Address")
            {
                index = 3;
            }
            if (combo == "City")
            {
                index = 5;
            }

            List<string> contacts = new List<string>();
            string path = "C:\\Users\\phili\\Desktop\\Prog16\\AdressBook\\AdressBook\\AddressBookLogg.txt";
            StreamReader sr = new StreamReader(path);
            string pline;
            while ((pline = sr.ReadLine()) != null)
            {
                string[] array = pline.Split(',');

                if (array[index] == search)
                {
                    contacts.Add(pline);
                }
            }
            sr.Close();
            return contacts;

        }


        public void Search_Click(object sender, EventArgs e)
        {


            // listBoxSearch.Text = contact;
            if (comboBox1.SelectedItem != null && !string.IsNullOrEmpty(textBoxSearch.Text))

            {
                List<string> searchContact = GetNamesFromFile(comboBox1.SelectedItem.ToString(),
                    textBoxSearch.Text.Trim());

                listBoxSearch.DataSource = searchContact;
            }


            // vet ej om behövs -----------------------------------
            //    string[] lines =
            //    File.ReadAllLines(@"C:\Users\phili\Desktop\Prog16\AdressBook\AdressBook\AddressBookLogg.txt");

            //foreach (string output in lines)
            //{

            //    if ()
            //    {


            //    }


            //    List<string> plist = LoadFile();

            //    listBoxSearch.DataSource = plist;



        }

        private void listBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] outList = listBoxSearch.SelectedItem.ToString().Split(',');

            UpdateList = outList.ToList();

            textBoxFirst.Text = outList[0];
            textBoxSecond.Text = outList[1];
            textBoxEmail.Text = outList[2];
            textBoxPhone.Text = outList[3];
            textBoxAdress.Text = outList[4];
            textBoxZip.Text = outList[5];
            textBoxCity.Text = outList[6];

        }



        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            List<string> newSaveList = new List<string>();

            if (listBoxSearch.SelectedItem != null)
            {
                string listString = listBoxSearch.SelectedItem.ToString();

                List<string> backList = LoadFile();
                foreach (var line in backList)
                {
                    if (line != listString)
                    {
                        newSaveList.Add(line);
                    }
                }

                File.WriteAllLines(@"C:\Users\phili\Desktop\Prog16\AdressBook\AdressBook\AddressBookLogg.txt",
                    newSaveList.ToArray());

                var FirstName = textBoxFirst.Text;
                var SecondName = textBoxSecond.Text;
                var Email = textBoxEmail.Text;
                var Phone = textBoxPhone.Text;
                var Address = textBoxAdress.Text;
                var Zip = textBoxZip.Text;
                var City = textBoxCity.Text;



                string toSave = FirstName + "," + SecondName + "," + Email + "," + Phone + "," +
                                Address + "," + Zip + "," + City;

                using (
                    StreamWriter path =
                        new StreamWriter(@"C:\Users\phili\Desktop\Prog16\AdressBook\AdressBook\AddressBookLogg.txt",
                            true))
                {
                    path.WriteLine(toSave);
                }


                MessageBox.Show("Update Successful!");

            }


        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            List<string> newSaveList = new List<string>();

            if (listBoxSearch.SelectedItem != null)
            {
                string listString = listBoxSearch.SelectedItem.ToString();

                List<string> backList = LoadFile();
                foreach (var line in backList)
                {
                    if (line != listString)
                    {
                        newSaveList.Add(line);
                    }
                }

                File.WriteAllLines(@"C:\Users\phili\Desktop\Prog16\AdressBook\AdressBook\AddressBookLogg.txt",
                    newSaveList.ToArray());

                textBoxFirst.Clear();
                textBoxSecond.Clear();
                textBoxEmail.Clear();
                textBoxPhone.Clear();
                textBoxAdress.Clear();
                textBoxZip.Clear();
                textBoxCity.Clear();


                MessageBox.Show("Remove Successful!");


            }



        }
    }
}












    
