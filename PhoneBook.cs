namespace Project_PhoneBook
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject]
    public class PhoneBook: IEnumerable<PhoneBook>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Dictionary<string, string> PhoneNumbers { get; set; }
        public List<PhoneBook> phoneListAllPrint = new List<PhoneBook>();
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

        public IEnumerator<PhoneBook> GetEnumerator() // Work
        {
            for (int i = 0; i < phoneListAllPrint.Count; i++)
            {
                yield return phoneListAllPrint[i];
            }

            /* Test Print
            for (int i = 0; i < phoneListAllPrint.Count; i++)
            {
                yield return phoneListAllPrint[i];
            }
            */
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}