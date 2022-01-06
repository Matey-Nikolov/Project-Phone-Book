namespace Project_PhoneBook
{
    using System.Collections.Generic;

    public class PhoneBook: 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Dictionary<string, string> PhoneNumbers { get; set; }

        public PhoneBook() { }

        public PhoneBook(string FirstName, string LastName, string first)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            PhoneNumbers = new Dictionary<string, string>
                                {
                                    { "first", first}
                                };
        }

        public PhoneBook(string FirstName, string LastName, string fisrt, string second)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            PhoneNumbers = new Dictionary<string, string>
                                {
                                    { "first", fisrt},
                                    { "second", second}
                                };
        }

        public PhoneBook(string FirstName, string LastName, string fisrt, string second, string third)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            PhoneNumbers = new Dictionary<string, string>
                                {
                                    { "first", fisrt},
                                    { "second", second},
                                    { "third", third}
                                };
        }
    }
}