namespace Project_PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhoneBook
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Dictionary<string, string> PhoneNumbers { get; set; }

        public PhoneBook() { }

        public PhoneBook(string FirstName, string LastName, string work)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            PhoneNumbers = new Dictionary<string, string>
                                {
                                    { "work",work}
                                };
        }

        public PhoneBook(string FirstName, string LastName, string work, string home)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            PhoneNumbers = new Dictionary<string, string>
                                {
                                    { "work",work},
                                    { "home",home}
                                };
        }

        public PhoneBook(string FirstName, string LastName, string work, string home, string other)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            PhoneNumbers = new Dictionary<string, string>
                                {
                                    { "work",work},
                                    { "home",home},
                                    { "other",other}
                                };
        }

    }
}