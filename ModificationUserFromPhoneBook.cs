using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PhoneBook
{
    public class ModificationUserFromPhoneBook<T>
    {

        public void ModificationFirstName(List<PhoneBook> phoneList) // <T>
        {
            Console.WriteLine("Enter the first name you want to change it.");
            string firstName = Console.ReadLine();

            List<PhoneBook> foundDuplicateName = new List<PhoneBook>();

            for (int i = 0; i < phoneList.Count; i++)
            {
                if (phoneList[i].FirstName == firstName)
                    foundDuplicateName.Add(phoneList[i]);
            }


            if (foundDuplicateName.Count != 1)
            {
                Console.WriteLine("Duplicate name!");

                int count = 1;
                foreach (var item in foundDuplicateName)
                {
                    Console.WriteLine($"{count} -> {item.FirstName} - phone number {item.PhoneNumbers["work"]}");
                    count++;
                }

                Console.WriteLine("Choose with numbers.");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new name.");
                string newName = Console.ReadLine();

                phoneList[number].FirstName = newName;
            }
            else
            {
                for (int j = 0; j < phoneList.Count; j++)
                {
                    if (phoneList[j].FirstName == firstName)
                    {
                        Console.WriteLine("Enter the new name.");
                        string newName = Console.ReadLine();
                        phoneList[j].FirstName = newName;
                    }
                    break;
                }
            }

        }

        public void ModificationLastName(List<PhoneBook> phoneList) // <T>
        {
            Console.WriteLine("Enter the last name you want to change it.");
            string lastName = Console.ReadLine();

            List<PhoneBook> foundDuplicateName = new List<PhoneBook>();

            for (int i = 0; i < phoneList.Count; i++)
            {
                if (phoneList[i].FirstName == lastName)
                    foundDuplicateName.Add(phoneList[i]);
            }


            if (foundDuplicateName.Count != 1)
            {
                Console.WriteLine("Duplicate name!");

                int count = 1;
                foreach (var item in foundDuplicateName)
                {
                    Console.WriteLine($"{count} -> {item.LastName} - phone number {item.PhoneNumbers["work"]}");
                    count++;
                }

                Console.WriteLine("Choose with numbers.");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new name.");
                string newName = Console.ReadLine();

                phoneList[number].LastName = newName;
            }
            else
            {
                for (int j = 0; j < phoneList.Count; j++)
                {
                    if (phoneList[j].LastName == lastName)
                    {
                        Console.WriteLine("Enter the new name.");
                        string newName = Console.ReadLine();
                        phoneList[j].LastName = newName;
                    }
                    break;
                }
            }
        }

        public void ModificationWorkNumber(List<PhoneBook> phoneList) // <T>
        {
            Console.WriteLine("Enter the work phone number you want to change it.");
            string workPhoneNumber = Console.ReadLine();

            foreach (var phoneNumber in phoneList)
            {
                if (phoneNumber.PhoneNumbers["work"] == workPhoneNumber)
                {
                    Console.WriteLine("Enter the new phone number.");
                    string newPhoneNumber = Console.ReadLine();

                    phoneNumber.PhoneNumbers["work"] = newPhoneNumber;
                }
                else
                {
                    Console.WriteLine("Invalid phone number!");
                    return;
                }
            }

        }

        public void ModificationHomeNUmber(List<PhoneBook> phoneList) // <T>
        {
            Console.WriteLine("Enter the home phone number you want to change it.");
            string workPhoneNumber = Console.ReadLine();

            foreach (var phoneNumber in phoneList)
            {
                if (phoneNumber.PhoneNumbers["home"] == workPhoneNumber)
                {
                    Console.WriteLine("Enter the new phone number.");
                    string newPhoneNumber = Console.ReadLine();

                    phoneNumber.PhoneNumbers["home"] = newPhoneNumber;
                }
                else
                {
                    Console.WriteLine("Invalid phone number!");
                    return;
                }
            }
        }

        public void ModificationMobileNUmber(List<PhoneBook> phoneList) // <T>
        {
            Console.WriteLine("Enter the mobile phone number you want to change it.");
            string workPhoneNumber = Console.ReadLine();

            foreach (var phoneNumber in phoneList)
            {
                if (phoneNumber.PhoneNumbers["mobile"] == workPhoneNumber)
                {
                    Console.WriteLine("Enter the new phone number.");
                    string newPhoneNumber = Console.ReadLine();

                    phoneNumber.PhoneNumbers["mobile"] = newPhoneNumber;
                }
                else
                {
                    Console.WriteLine("Invalid phone number!");
                    return;
                }
            }
        }
    }
}