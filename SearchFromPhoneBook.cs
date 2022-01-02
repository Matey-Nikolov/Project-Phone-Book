using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_PhoneBook
{
    public class SearchFromPhoneBook 
    {
        public void MainResearch(List<PhoneBook> phoneList)
        {
            Console.Clear();
            Console.WriteLine("1 - Search by name");
            Console.WriteLine("2 - Search by number");
            Console.Write("Please enter your choise: ");

            string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    break;
                    SearchByName(phoneList);  // Not work
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

        static private void SearchByName(List<PhoneBook> phoneList)
        {
            Console.Write("Enter a full or part of name: ");

            string researchName = Console.ReadLine();

            string pattern = researchName;

            Regex rg = new Regex(pattern);

        }

        static private void SearchByPhoneNumber(List<PhoneBook> phoneList)
        {

            Console.Write("Enter a full or part of phone number - ** *** ****: ");

            string researchPhoneNumber = Console.ReadLine();                // Май не се ползва

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
        }
    }
}