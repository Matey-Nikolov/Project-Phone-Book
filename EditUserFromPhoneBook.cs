using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PhoneBook
{
    public class EditUserFromPhoneBook<T>
    {
        public void MainEdit(List<PhoneBook> phoneList)
        {
            Console.Clear();
            Console.WriteLine("We will print all users.");

            MainFuction mainPrintAll = new MainFuction();
            int count =  mainPrintAll.MainPrintAllPhoneList(phoneList);

            if (count == 0)
            {
                Console.WriteLine();
                return;
            }

            Console.Write("Enter the number of the user you want to edit: ");
            int editNumber = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Edit operation for this user.");
            Console.WriteLine("1 - Fisrt name");
            Console.WriteLine("2 - Last name");
            Console.WriteLine("3 - First number");
            Console.WriteLine("4 - Second number");
            Console.WriteLine("5 - Third number");

            Console.Write("Enter a number for edit: ");
            int editCommand = int.Parse(Console.ReadLine());


            switch (editCommand)
            {
                case 1:
                    EditFirstName(phoneList, editNumber);
                    break;
                case 2:
                    EditSecondName(phoneList, editNumber);
                    break;
                case 3:
                    EditFirstPhoneNumber(phoneList, editNumber);
                    break;
                case 4:
                    EditSecondPhoneNumber(phoneList, editNumber);
                    break;
                case 5:
                    EditThirdPhoneNumber(phoneList, editNumber);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("No edits.");
                    Console.WriteLine();
                    break;
            }


        }

        static private void EditThirdPhoneNumber(List<PhoneBook> phoneList, int editNumber)
        {
            if (!phoneList[editNumber - 1].PhoneNumbers.ContainsKey("third"))
            {
                Console.Clear();
                Console.WriteLine("No third phone number!");
                Console.WriteLine();
                return;
            }

            string thirdPhoneNumber = phoneList[editNumber - 1].PhoneNumbers["third"];

            Console.Clear();
            Console.Write("Enter a new phone number +359 ** *** ****: ");
            string newThirdPhoneNumber = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"{thirdPhoneNumber} -> {newThirdPhoneNumber}");
            Console.WriteLine();

            phoneList[editNumber - 1].PhoneNumbers["third"] = newThirdPhoneNumber;
        }

        static private void EditSecondPhoneNumber(List<PhoneBook> phoneList, int editNumber)
        {
            if (!phoneList[editNumber - 1].PhoneNumbers.ContainsKey("second"))
            {
                Console.Clear();
                Console.WriteLine("No second phone number!");
                Console.WriteLine();
                return;
            }

            string secondPhoneNumber = phoneList[editNumber - 1].PhoneNumbers["second"];

            Console.Clear();
            Console.Write("Enter a new phone number +359 ** *** ****: ");
            string newSecondPhoneNumber = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"{secondPhoneNumber} -> {newSecondPhoneNumber}");
            Console.WriteLine();

            phoneList[editNumber - 1].PhoneNumbers["second"] = newSecondPhoneNumber;
        }

        static private void EditFirstPhoneNumber(List<PhoneBook> phoneList, int editNumber)
        {
            string firstPhoneNumber = phoneList[editNumber - 1].PhoneNumbers["first"];
            
            Console.Clear();
            Console.Write("Enter a new phone number +359 ** *** ****: ");
            string newFirstPhoneNumber = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"{firstPhoneNumber} -> {newFirstPhoneNumber}");
            Console.WriteLine();

            phoneList[editNumber - 1].PhoneNumbers["first"] = newFirstPhoneNumber;
        }

        static private void EditSecondName(List<PhoneBook> phoneList, int editNumber)
        {
            string lastName = phoneList[editNumber - 1].LastName;

            Console.Clear();
            Console.Write("Enter a new name: ");
            string newLastName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"{lastName} -> {newLastName}");
            Console.WriteLine();

            phoneList[editNumber - 1].FirstName = newLastName;
        }

        static private void EditFirstName(List<PhoneBook> phoneList, int editNumber)
        {
            string firstName = phoneList[editNumber - 1].FirstName;

            Console.Clear();
            Console.Write("Enter a new name: ");
            string newFirstName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"{firstName} -> {newFirstName}");
            Console.WriteLine();

            phoneList[editNumber - 1].FirstName = newFirstName;
        }
    }
}