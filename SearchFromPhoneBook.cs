namespace Project_PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;


    public class SearchFromPhoneBook 
    {
        public void MainSearch(List<PhoneBook> phoneList)
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

            string firstName = "";
            string lastName = "";
            string firstPhoneNumber = "";
            string secondPhoneNumber = "";
            string thirdPhoneNumber = "";

            Console.WriteLine();
            Console.WriteLine("----------------------------All matches from your phone book-------------------------------");
            Console.WriteLine("Number | First Name | Last Name  | Fisrt number      | Second number     | Third number");
            foreach (var phoneNumber in phoneList)
            {
                firstName = phoneNumber.FirstName;
                lastName = phoneNumber.LastName;

                firstPhoneNumber = phoneNumber.PhoneNumbers["first"];
                secondPhoneNumber = "";
                thirdPhoneNumber = "";

                if (phoneNumber.PhoneNumbers.ContainsKey("second"))
                    secondPhoneNumber = phoneNumber.PhoneNumbers["second"];

                if (phoneNumber.PhoneNumbers.ContainsKey("third"))
                    thirdPhoneNumber = phoneNumber.PhoneNumbers["third"];

                bool matchFirst = rg.IsMatch(firstPhoneNumber);
                bool matchSecond = rg.IsMatch(secondPhoneNumber);
                bool matchthird = rg.IsMatch(thirdPhoneNumber);

                ValoidationMatches(matchFirst, matchSecond, matchthird, firstName, lastName, firstPhoneNumber, secondPhoneNumber, thirdPhoneNumber);
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        static private void ValoidationMatches(bool matchFirst, bool matchSecond, bool matchthird, string firstName, string lastName, string firstPhoneNumber, string secondPhoneNumber, string thirdPhoneNumber)
        {
            if (matchFirst && matchSecond && matchthird)
            {
                PrintSortPhoneNumberAndName(firstName, lastName, firstPhoneNumber, secondPhoneNumber, thirdPhoneNumber);
            }
            else if (matchFirst && matchSecond == false && matchthird == false)
            {
                PrintSortPhoneNumberAndName(firstName, lastName, firstPhoneNumber, "", "");
            }
            else if (matchFirst == false && matchSecond != false && matchthird == false)
            {
                PrintSortPhoneNumberAndName(firstName, lastName, "", secondPhoneNumber, "");
            }
            else if (matchFirst == false && matchSecond == false && matchthird != false)
            {
                PrintSortPhoneNumberAndName(firstName, lastName, "", "", thirdPhoneNumber);
            }
            else if (matchFirst != false && matchSecond != false && matchthird == false)
            {
                PrintSortPhoneNumberAndName(firstName, lastName, firstPhoneNumber, secondPhoneNumber, "");
            }
            else if (matchFirst == false && matchSecond != false && matchthird != false)
            {
                PrintSortPhoneNumberAndName(firstName, lastName, "", secondPhoneNumber, thirdPhoneNumber);
            }
            else if (matchFirst != false && matchSecond != false && matchthird == false)
            {
                PrintSortPhoneNumberAndName(firstName, lastName, firstPhoneNumber, secondPhoneNumber, "");
            }
            else if (matchFirst != false && matchSecond == false && matchthird != false)
            {
                PrintSortPhoneNumberAndName(firstName, lastName, firstPhoneNumber, "", thirdPhoneNumber);
            }
        }


        private void SearchByName(List<PhoneBook> phoneList)
        {
            Console.WriteLine();
            Console.Write("Enter a full or part of name: ");

            string researchName = Console.ReadLine();

            string pattern = researchName;
            string firstName = "";
            string lastName = "";
            string firstPhoneNumber = "";
            string secondPhoneNumber = "";
            string thirdPhoneNumber = "";

            Regex rg = new Regex(pattern);

            Console.WriteLine();
            Console.WriteLine("----------------------------All matches from your phone book-------------------------------");
            Console.WriteLine("Number | First Name | Last Name  | Fisrt number      | Second number     | Third number");
            foreach (var users in phoneList)
            {
                string user = users.FirstName + " " + users.LastName;

                firstName = users.FirstName;
                lastName = users.LastName;

                bool match = rg.IsMatch(user);

                firstPhoneNumber = users.PhoneNumbers["first"];
                secondPhoneNumber = "";
                thirdPhoneNumber = "";

                if (users.PhoneNumbers.ContainsKey("second"))
                    secondPhoneNumber = users.PhoneNumbers["second"];

                if (users.PhoneNumbers.ContainsKey("third"))
                    thirdPhoneNumber = users.PhoneNumbers["third"];

                if (match)
                {
                    PrintSortPhoneNumberAndName(firstName, lastName, firstPhoneNumber, secondPhoneNumber, thirdPhoneNumber);
                }
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        static private void PrintSortPhoneNumberAndName(string firstName, string lastName, string firstNumber, string secondNumber, string thirdNumber)
        {
            int count = 1;
            Console.WriteLine(String.Format("{0,-6} | {1,-10} | {2,-10} | {3,-17} | {4,-17} | {5,-17}", count, firstName, lastName, firstNumber, secondNumber, thirdNumber));
        }
    }
}