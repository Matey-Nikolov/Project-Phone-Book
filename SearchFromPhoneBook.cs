namespace Project_PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;


    public class SearchFromPhoneBook 
    {
        public void MainResearch(List<PhoneBook> phoneList)
        {
            Console.Clear();

            if (phoneList.Count == 0)
            {
                Console.WriteLine("Phone book is empty!");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("1 - Search by name");
            Console.WriteLine("2 - Search by number");
            Console.Write("Please enter your choise: ");

            string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    SearchByName(phoneList);  // Work
                    break;
                case "2":
                    SearchByPhoneNumber(phoneList); // Work
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid selection!");
                    Console.WriteLine();
                    break;
            }
        }
        static private void SearchByPhoneNumber(List<PhoneBook> phoneList)
        {
            Console.WriteLine();
            Console.Write("Enter a full or part of phone number: ");

            string researchPhoneNumber = Console.ReadLine();

            string pattern = researchPhoneNumber;

            Regex rg = new Regex(pattern);


            foreach (var phoneNumber in phoneList)
            {
                string workPhoneNumber = phoneNumber.PhoneNumbers["first"];

                bool match = rg.IsMatch(workPhoneNumber);

                if (match)
                {
                    Console.WriteLine($"{phoneNumber.FirstName} {phoneNumber.LastName} -> {phoneNumber.PhoneNumbers["first"]}");
                }
            }
            Console.WriteLine();
        }

        private void SearchByName(List<PhoneBook> phoneList)
        {
            Console.WriteLine();
            Console.Write("Enter a full or part of name: ");

            string researchName = Console.ReadLine();

            string pattern = researchName;

            Regex rg = new Regex(pattern);


            foreach (var users in phoneList)
            {
                string user = users.FirstName + " " + users.LastName;

                bool match = rg.IsMatch(user);

                if (match)
                {
                    Console.WriteLine($"{users.FirstName} {users.LastName} -> {users.PhoneNumbers["first"]}");
                }
            }
            Console.WriteLine();
        }
    }
}