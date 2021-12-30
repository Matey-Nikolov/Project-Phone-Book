using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PhoneBook
{
    public class ModificationUserFromPhoneBook<T> /*: IEnumerable<T> // <T> */
    {
        public void Changes(List<PhoneBook> phoneList)
        {
            Console.Clear();
            Console.WriteLine("We will print all users.");

            Console.WriteLine();

            PrintAllUsers(phoneList);

            Console.WriteLine();
            
            Console.WriteLine("Fisrt name - 1.");
            Console.WriteLine("Last name - 2.");
            Console.WriteLine("Work number - 3.");
            Console.WriteLine("Home number - 4.");
            Console.WriteLine("Other number - 5.");

           
            Console.Write("Enter a number with the corresponding change you want to make: ");
            string modificalCommand = Console.ReadLine();


            switch (modificalCommand)
            {
                case "1":
                    ModificationFirstName(phoneList, modificalCommand);
                    break;
                case "2":
                    ModificationLastName(phoneList, modificalCommand);
                    break;
                case "3":
                    ModificationWorkNumber(phoneList);
                    break;
                case "4":
                    ModificationHomeNumber(phoneList);
                    break;
                case "5":
                    ModificationOtherNummber(phoneList);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("No changes.");
                    Console.WriteLine();
                    break;
            }


        }

        static private void PrintAllUsers(List<PhoneBook> phoneList)
        {
            foreach (var all in phoneList)
            {
                Console.WriteLine($"{all.FirstName} {all.LastName}");
                Console.WriteLine($"    Work phone number: {all.PhoneNumbers["work"]}");

                if (all.PhoneNumbers.ContainsKey("home"))
                    Console.WriteLine($"    Home phone number: {all.PhoneNumbers["home"]}");
                else if (all.PhoneNumbers.ContainsKey("other"))
                    Console.WriteLine($"    Other phone number: {all.PhoneNumbers["other"]}");
            }
        }

        static private void DuplicatePasteInOriginalList(List<PhoneBook> foundDuplicateNames, List<PhoneBook> phoneList, string firstOrLastName, string modificalCommand)
        {
            Console.WriteLine("Duplicate name!");


            switch (modificalCommand)
            {
                case "1":
                    int count = 1;
                    Console.WriteLine("All touching names with their working mobile numbers.");
                    Console.WriteLine();
                    foreach (var item in foundDuplicateNames)
                    {
                        Console.WriteLine($"{count} -> {item.FirstName} - phone number {item.PhoneNumbers["work"]}");
                        count++;
                    }

                    Console.Write("Choose with number: ");
                    int number = int.Parse(Console.ReadLine());
                    Console.Write("Enter the new name: ");
                    string newName = Console.ReadLine();

                    for (int found = 0; found <= foundDuplicateNames.Count; found++)
                    {
                        if (found == number)
                        {
                            Console.WriteLine($"{foundDuplicateNames[found - 1].FirstName} -> {newName}");
                        }
                    }

                    Console.WriteLine();

                    int countDuplicateFirstOrLastName = 0;
                    for (int nFirstName = 0; nFirstName < phoneList.Count; nFirstName++)
                    {
                        if (phoneList[nFirstName].FirstName == firstOrLastName)
                            countDuplicateFirstOrLastName++;

                        if (countDuplicateFirstOrLastName == number)
                        {
                            phoneList[nFirstName].FirstName = newName;
                        }
                    }
                    break;

                case "2":
                    count = 1;
                    Console.WriteLine("All touching names with their working mobile numbers.");
                    Console.WriteLine();
                    foreach (var item in foundDuplicateNames)
                    {
                        Console.WriteLine($"{count} -> {item.LastName} - phone number {item.PhoneNumbers["work"]}");
                        count++;
                    }

                    Console.Write("Choose with number: ");
                    number = int.Parse(Console.ReadLine());
                    Console.Write("Enter the new name: ");
                    newName = Console.ReadLine();

                    for (int found = 0; found <= foundDuplicateNames.Count; found++)
                    {
                        if (found == number)
                        {
                            Console.WriteLine($"{foundDuplicateNames[found - 1].LastName} -> {newName}");
                        }
                    }
                    
                    Console.WriteLine();

                    countDuplicateFirstOrLastName = 0;
                    for (int nLastName = 0; nLastName < phoneList.Count; nLastName++)
                    {
                        if (phoneList[nLastName].LastName == firstOrLastName)
                            countDuplicateFirstOrLastName++;

                        if (countDuplicateFirstOrLastName == number)
                        {
                            phoneList[nLastName].LastName = newName;
                        }
                    }
                    break;
            }

            
        }

        static private void ModificationFirstName(List<PhoneBook> phoneList, string modificalCommand) // <T>
        {

            Console.Write("Enter the first name you want to change it: ");
            string firstName = Console.ReadLine();

            List<PhoneBook> foundDuplicateNames = new List<PhoneBook>();

            for (int i = 0; i < phoneList.Count; i++)
            {
                if (phoneList[i].FirstName == firstName)
                    foundDuplicateNames.Add(phoneList[i]);
            }


            if (foundDuplicateNames.Count != 1 && foundDuplicateNames.Count > 0)
            {
                DuplicatePasteInOriginalList(foundDuplicateNames, phoneList, firstName, modificalCommand);
            }
            else
            {
                for (int j = 0; j < phoneList.Count; j++)
                {
                    if (phoneList[j].FirstName == firstName)
                    {
                        Console.Write("Enter the new name: ");
                        string newName = Console.ReadLine();
                        
                        Console.WriteLine($"Old name: {phoneList[j].FirstName} -> new name: {firstName}");
                        Console.WriteLine();
                        phoneList[j].FirstName = newName;
                        break;
                    }
                }
            }

        }

        static private void ModificationLastName(List<PhoneBook> phoneList, string modificalCommand) // <T>
        {
            Console.Write("Enter the last name you want to change it: ");
            string lastName = Console.ReadLine();

            List<PhoneBook> foundDuplicateNames = new List<PhoneBook>();

            for (int i = 0; i < phoneList.Count; i++)
            {
                if (phoneList[i].LastName == lastName)
                    foundDuplicateNames.Add(phoneList[i]);
            }


            if (foundDuplicateNames.Count != 1 && foundDuplicateNames.Count > 0)
            {
                DuplicatePasteInOriginalList(foundDuplicateNames, phoneList, lastName, modificalCommand);
            }
            else
            {
                for (int j = 0; j < phoneList.Count; j++)
                {
                    if (phoneList[j].LastName == lastName)
                    {
                        Console.Write("Enter the new name: ");
                        string newName = Console.ReadLine();

                        Console.WriteLine($"Old name: {phoneList[j].FirstName} -> new name: {lastName}");
                        Console.WriteLine();
                        phoneList[j].LastName = newName;
                        break;
                    }
                }
            }
        }

        static private void ModificationWorkNumber(List<PhoneBook> phoneList) // <T>
        {
            Console.Write("Enter the work phone number you want to change it: ");
            string workPhoneNumber = Console.ReadLine();

            foreach (var phoneNumber in phoneList)
            {
                if (phoneNumber.PhoneNumbers["work"] == workPhoneNumber)
                {
                    Console.Write("Enter the new phone number: ");
                    string newPhoneNumber = Console.ReadLine();

                    Console.Write($"Old phone number: {phoneNumber.PhoneNumbers["work"]} -> new phone number {newPhoneNumber}");
                    Console.WriteLine();
                    phoneNumber.PhoneNumbers["work"] = newPhoneNumber;
                    return;
                }
            }

            Console.WriteLine("Invalid phone number!");
        }

        static private void ModificationHomeNumber(List<PhoneBook> phoneList) // <T>
        {
            Console.Write("Enter the home phone number you want to change it: ");
            string workPhoneNumber = Console.ReadLine();

            foreach (var phoneNumber in phoneList)
            {
                if (phoneNumber.PhoneNumbers["home"] == workPhoneNumber)
                {
                    Console.Write("Enter the new phone number: ");
                    string newPhoneNumber = Console.ReadLine();

                    Console.Write($"Old phone number: {phoneNumber.PhoneNumbers["home"]} -> new phone number {newPhoneNumber}");
                    Console.WriteLine();
                    phoneNumber.PhoneNumbers["home"] = newPhoneNumber;
                    return;
                }
            }
                    Console.WriteLine("Invalid phone number!");
        }

        static private void ModificationOtherNummber(List<PhoneBook> phoneList) // <T>
        {
            Console.Write("Enter the other phone number you want to change it: ");
            string workPhoneNumber = Console.ReadLine();

            foreach (var phoneNumber in phoneList)
            {
                if (phoneNumber.PhoneNumbers["other"] == workPhoneNumber)
                {
                    Console.Write("Enter the new phone number: ");
                    string newPhoneNumber = Console.ReadLine();

                    Console.Write($"Old phone number: {phoneNumber.PhoneNumbers["other"]} -> new phone number {newPhoneNumber}");
                    Console.WriteLine();
                    phoneNumber.PhoneNumbers["other"] = newPhoneNumber;
                    return;
                }
            }
            Console.WriteLine("Invalid phone number!");
        }


    }
}