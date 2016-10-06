using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AdressBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public List<string> UpdateList = new List<string>();


        public void buttonSave_Click(object sender, EventArgs e)
        {
            Person person = new Person();

            if (!string.IsNullOrWhiteSpace(textBoxFirst.Text) 
              || !string.IsNullOrWhiteSpace(textBoxSecond.Text))
            {



                var firstName = textBoxFirst.Text.ToLower();
                var secondName = textBoxSecond.Text.ToLower();
                var email = textBoxEmail.Text.ToLower();
                var phone = textBoxPhone.Text.ToLower();
                var address = textBoxAdress.Text.ToLower();
                var zip = textBoxZip.Text.ToLower();
                var city = textBoxCity.Text.ToLower();


                textBoxFirst.Clear();
                textBoxSecond.Clear();
                textBoxEmail.Clear();
                textBoxPhone.Clear();
                textBoxAdress.Clear();
                textBoxZip.Clear();
                textBoxCity.Clear();


                person.Save(person.FirstName, person.SecondName, person.Email, person.Phone, person.Address, person.Zip,
                    person.City);


                string toSave = firstName + "," + secondName + "," + email + "," + phone + "," +
                                address + "," + zip + "," + city;

                using (
                    StreamWriter writer =
                        new StreamWriter(@"C:\Users\phili\Desktop\Prog16\AdressBook\AdressBook\AddressBookLogg.txt",
                            true))
                {
                    writer.WriteLine(toSave);
                }

                MessageBox.Show("Save Successful!");

            }

            else MessageBox.Show("Please Enter a Name");

        }
        public List<string> GetNamesFromFile(string combo, string search)

        {
            int index = 0;

            if (combo == "First Name")
            {
                index = 0;
            }


            if (combo == "Last Name")
            {
                index = 1;
            }


            if (combo == "Email")
            {
                index = 2;
            }


            if (combo == "Phone")
            {
                index = 3;
            }


            if (combo == "Address")
            {
                index = 4;
            }


            if (combo == "Zip")
            {
                index = 5;
            }


            if (combo == "City")
            {
                index = 6;
            }


            List<string> contacts = new List<string>();
            string path = "C:\\Users\\phili\\Desktop\\Prog16\\AdressBook\\AdressBook\\AddressBookLogg.txt";
            StreamReader streamReader = new StreamReader(path);

            string personLine;
            while ((personLine = streamReader.ReadLine()) != null)
            {
                string[] array = personLine.Split(',');

                if (array[index].Contains(search))
                {
                    contacts.Add(personLine);
                }
            }
            streamReader.Close();
            return contacts;

        }


        public void Search_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem != null && !string.IsNullOrEmpty(textBoxSearch.Text))

            {
                List<string> searchContacts = GetNamesFromFile(comboBox1.SelectedItem.ToString(),
                    textBoxSearch.Text.ToLower().Trim());
                listBoxSearch.DataSource = searchContacts;
            }

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

            //if (outList.Select      //--------------------------------------------
            //{
                
            //}

        }


        List<string> LoadFile()
        {
            List<string> personFile = new List<string>();
            string path = "C:\\Users\\phili\\Desktop\\Prog16\\AdressBook\\AdressBook\\AddressBookLogg.txt";
            StreamReader streamReader = new StreamReader(path);
            string contactLine;

            while ((contactLine = streamReader.ReadLine()) != null)
            {
                personFile.Add(contactLine);
            }
            streamReader.Close
                ();
            return
                personFile;

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

                var firstName = textBoxFirst.Text;
                var secondName = textBoxSecond.Text;
                var email = textBoxEmail.Text;
                var phone = textBoxPhone.Text;
                var address = textBoxAdress.Text;
                var zip = textBoxZip.Text;
                var city = textBoxCity.Text;


                string toSave = firstName + "," + secondName + "," + email + "," + phone + "," +
                                address + "," + zip + "," + city;

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

                if (comboBox1.SelectedItem != null && !string.IsNullOrEmpty(textBoxSearch.Text))

                {
                    List<string> searchContacts = GetNamesFromFile(comboBox1.SelectedItem.ToString(),
                        textBoxSearch.Text.ToLower().Trim());
                    listBoxSearch.DataSource = searchContacts;
                }


            }
        }
    }
}











