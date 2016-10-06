

namespace AdressBook
{
    public class Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }

        public void Save(string fName, string sName, string mail, string fone,
            string addrezz, string zipp, string cityy)
        {
            FirstName = fName;
            SecondName = sName;
            Email = mail;
            Phone = fone;
            Address = addrezz;
            Zip = zipp;
            City = cityy;
        }
    }


}
