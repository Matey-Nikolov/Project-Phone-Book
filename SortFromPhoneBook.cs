namespace Project_PhoneBook
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class SortFromPhoneBook /*: IEnumerable<PhoneBook>*/
    {
        // private List<PhoneBook> phoneList2 { get; set; }

        public void MainSortPrint(List<PhoneBook> phoneList)
        {
            Console.Clear();

            if (phoneList.Count == 0)
            {
                Console.WriteLine("Phone book is empty!");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("1 - Sort by name"); // 100%
            Console.WriteLine("2 - Sort by phone number"); // 100%
            Console.Write("Please enter your choise: ");
            string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    SortByName(phoneList);
                    break;
                case "2":
                    SortByPhoneNumber(phoneList);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine();
                    break;
            }
        }

        static private void SortByName(List<PhoneBook> phoneList)
        {
            Console.Clear();
            Console.WriteLine("1 - Descending order");
            Console.WriteLine("2 - Ascending order");
            Console.Write("Please enter your choise: ");
            string number = Console.ReadLine();

            List<PhoneBook> newSortPhoneList = new List<PhoneBook>();

            if (number == "1")
            {
                int count = 1;
                Console.WriteLine("--------------------------Sort all user from your phone book---------------------------------");
                Console.WriteLine("Number | First Name | Last Name  | Fisrt number      | Second number     | Third number");
                foreach (var AllItem in phoneList.OrderByDescending(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    string firstName = AllItem.FirstName;
                    string lastName = AllItem.LastName;
                    string firstNumber = AllItem.PhoneNumbers["first"];
                    string secondNumber = "";
                    string thirdNumber = "";

                    if (AllItem.PhoneNumbers.ContainsKey("second"))
                        secondNumber = AllItem.PhoneNumbers["second"];

                    if (AllItem.PhoneNumbers.ContainsKey("third"))
                        thirdNumber = AllItem.PhoneNumbers["third"];

                    Console.WriteLine(String.Format("{0,-6} | {1,-10} | {2,-10} | {3,-17} | {4,-17} | {5,-17}", count, firstName, lastName, firstNumber, secondNumber, thirdNumber));

                    newSortPhoneList.Add(AllItem);
                    count++;
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------");
                Console.WriteLine();

                phoneList = newSortPhoneList;
            }
            else if (number == "2")
            {
                int count = 1;
                Console.WriteLine("--------------------------Sort all user from your phone book---------------------------------");
                Console.WriteLine("Number | First Name | Last Name  | Fisrt number      | Second number     | Third number");
                foreach (var AllItem in phoneList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    string firstName = AllItem.FirstName;
                    string lastName = AllItem.LastName;
                    string firstNumber = AllItem.PhoneNumbers["first"];
                    string secondNumber = "";
                    string thirdNumber = "";

                    if (AllItem.PhoneNumbers.ContainsKey("second"))
                        secondNumber = AllItem.PhoneNumbers["second"];

                    if (AllItem.PhoneNumbers.ContainsKey("third"))
                        thirdNumber = AllItem.PhoneNumbers["third"];

                    Console.WriteLine(String.Format("{0,-6} | {1,-10} | {2,-10} | {3,-17} | {4,-17} | {5,-17}", count, firstName, lastName, firstNumber, secondNumber, thirdNumber));

                    newSortPhoneList.Add(AllItem);
                    count++;
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------");
                Console.WriteLine();

                phoneList = newSortPhoneList;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid number!");
                Console.WriteLine();
                return;
            }

            Console.WriteLine();

            using (StreamWriter file = File.CreateText(@"..\..\..\phoneList.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, phoneList);
            }
        }

        static private void SortByPhoneNumber(List<PhoneBook> phoneList)
        {
            Console.Clear();
            Console.WriteLine("Sort by fisrt phone number.");

            List<PhoneBook> newSortPhoneNumberList = new List<PhoneBook>();

            int count = 1;
            Console.WriteLine("--------------------------Sort all user from your phone book---------------------------------");
            Console.WriteLine("Number | First Name | Last Name  | Fisrt number      | Second number     | Third number");
            foreach (var AllItem in phoneList.OrderBy(x => x.PhoneNumbers["first"]))
            {
                string firstName = AllItem.FirstName;
                string lastName = AllItem.LastName;
                string firstNumber = AllItem.PhoneNumbers["first"];
                string secondNumber = "";
                string thirdNumber = "";

                if (AllItem.PhoneNumbers.ContainsKey("second"))
                    secondNumber = AllItem.PhoneNumbers["second"];

                if (AllItem.PhoneNumbers.ContainsKey("third"))
                    thirdNumber = AllItem.PhoneNumbers["third"];

                Console.WriteLine(String.Format("{0,-6} | {1,-10} | {2,-10} | {3,-17} | {4,-17} | {5,-17}", count, firstName, lastName, firstNumber, secondNumber, thirdNumber));

                newSortPhoneNumberList.Add(AllItem);
                count++;
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine();

            phoneList = newSortPhoneNumberList;

            Console.WriteLine();

            using (StreamWriter file = File.CreateText(@"..\..\..\phoneList.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, phoneList);
            }
        }
    }
}