using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_PhoneBook
{
    public class ResearchFromPhoneBook 
    {
        public void MainResearch(List<PhoneBook> phoneList)
        {
            Console.Clear();
            Console.WriteLine("Research by name - 1");
            Console.WriteLine("Research by number - 2");

            string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    break;
                    ResearchByName(phoneList);
                case "2":
                    ResearchByPhoneNumber(phoneList);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid numbers!");
                    Console.WriteLine();
                    break;
            }
        }

        private void ResearchByName(List<PhoneBook> phoneList)
        {
            Console.Write("Enter a full or half name: ");

            string researchName = Console.ReadLine();

            string pattern = "";
        }

        private void ResearchByPhoneNumber(List<PhoneBook> phoneList)
        {

            Console.Write("Enter a full or half phone number - ** *** ****: ");

            string researchPhoneNumber = Console.ReadLine();

            string pattern = @"(\+359)? ?[0-9]{2} ?[0-9]{3} ?[0-9]{4}";

            Regex rg = new Regex(pattern);


            foreach (var phoneNumber in phoneList)
            {
                string workPhoneNumber = phoneNumber.PhoneNumbers["work"];

                bool match = rg.IsMatch(workPhoneNumber);

                if (match)
                {
                    Console.WriteLine($"{phoneNumber.FirstName} {phoneNumber.LastName} -> {phoneNumber.PhoneNumbers["work"]}");
                }
            }

        }
    }
}