using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Project_PhoneBook
{
    public class MainFuction /*<T>*/
    {
        public List<PhoneBook> Initialization(List<PhoneBook> phoneList) // T
        {
            string fileName = @"..\..\..\phoneList.json";

            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    phoneList = (List<PhoneBook>)serializer.Deserialize(streamReader, typeof(List<PhoneBook>));
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Can not find file {0}.", fileName);
                using (StreamWriter streamWriter = new StreamWriter(fileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(streamWriter, phoneList);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("Invalid directory in the file path.");
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Can not open the file {0}", fileName);
            }

            return phoneList;
        }

        public void MainPrintArguments()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Phone Book Operations:");
            Console.WriteLine("1 - Add"); // 100%
            Console.WriteLine("2 - Search"); // 100%
            Console.WriteLine("3 - Edit user"); // 100%
            Console.WriteLine("4 - Sort phone book"); // 100%
            Console.WriteLine("5 - List phone book"); // 100%
            Console.WriteLine("6 - Delete"); // 100%
            Console.WriteLine("0 - End");   // 100 %
            Console.Write("Please enter your choise: ");
        }

        public List<PhoneBook> AddList(List<PhoneBook>  phoneList) //List<T>
        {
            PhoneBook phoneBook = new PhoneBook();

            Console.Clear();
            Console.WriteLine("You must write first, last name and first phone number!");

            Console.Write("Enter first name*: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name*: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter first phone number* +359 ** *** ****: ");
            string firstPhoneNumber = Console.ReadLine();

            if ((firstName == string.Empty && lastName == string.Empty && firstPhoneNumber == string.Empty) || (firstName != string.Empty && lastName != string.Empty && firstPhoneNumber == string.Empty) || (firstName == string.Empty && lastName == string.Empty && firstPhoneNumber != string.Empty))
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("You must write first, last name and first phone number!");

                Console.Write("Enter first name: ");
                firstName = Console.ReadLine();

                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();

                Console.Write("Enter fisrt phone number +359 ** *** ****: ");
                firstPhoneNumber = Console.ReadLine();
                
                //firstPhoneNumber = Validation(firstPhoneNumber);

                if (firstName == string.Empty && lastName == string.Empty && firstPhoneNumber == string.Empty)
                {
                    Console.WriteLine("Bye!");
                }
            }

            firstPhoneNumber = Validation(firstPhoneNumber);

            Console.Write("Enter second phone number +359 ** *** **** (option): ");
            string secondPhoneNumber = Console.ReadLine();

            if (secondPhoneNumber != string.Empty)
                secondPhoneNumber = Validation(secondPhoneNumber);

            Console.Write("Enter third phone number +359 ** *** **** (option): ");
            string thirdPhoneNumber = Console.ReadLine();

            if (secondPhoneNumber != string.Empty)
                thirdPhoneNumber = Validation(thirdPhoneNumber);


            if (secondPhoneNumber != string.Empty && thirdPhoneNumber == string.Empty)
            {
                phoneBook = new PhoneBook(firstName, lastName, firstPhoneNumber, secondPhoneNumber);
            }
            else if (thirdPhoneNumber != string.Empty)
            {
                phoneBook = new PhoneBook(firstName, lastName, firstPhoneNumber, secondPhoneNumber, thirdPhoneNumber);
            }
            else
            {
                phoneBook = new PhoneBook(firstName, lastName, firstPhoneNumber);
            }

            phoneList.Add(phoneBook);
            Console.Clear();
            return phoneList;
        }

        
        private string Validation(string phoneNumber)
        {
            string pattern = @"^(\+359) ?[0-9]{2} ?[0-9]{3} ?[0-9]{4}$";

            Regex rg = new Regex(pattern);
            Match matchPhoneNumber = rg.Match(phoneNumber);

            string tryAgainPhoneNumber = "";

            if (!matchPhoneNumber.Success)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid phone number!");
                Console.Write("Try again +359 ** *** ****: ");

                tryAgainPhoneNumber = Console.ReadLine();

                matchPhoneNumber = rg.Match(tryAgainPhoneNumber);

                if (!matchPhoneNumber.Success)
                {
                    Console.WriteLine("Bye!");
                    Console.WriteLine();
                    return "";
                }
                else
                    Console.WriteLine();
                    return tryAgainPhoneNumber;
            }

            return phoneNumber;
        }
        

        public int MainPrintAllPhoneList(List<PhoneBook> phoneList)
        {
            //
            // https://www.csharp-examples.net/align-string-with-spaces/
            //

            if (phoneList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Phone bok is empty!");
                return 0;
            }

            int count = 1;
         // Console.Clear();
            Console.WriteLine("--------------------------All user from your phone book------------------------------------");
            Console.WriteLine("Number | First Name | Last Name  | Fisrt number      | Second number     | Third number");
            foreach (var AllItem in phoneList)
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
                count++;
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine();
            return count;
        }

        public void DeleteFromPhoneBook(List<PhoneBook> phoneList)
        {
            if (phoneList.Count == 0)
            {
                Console.WriteLine("Phone book is empty!");
                Console.WriteLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("Print all users from your phone bok.");

            MainPrintAllPhoneList(phoneList);

            Console.Write("Choose number you want to delete from your phone book: ");
            string stringNumberAndCommad = Console.ReadLine();

            if (stringNumberAndCommad == string.Empty)
            {
                Console.Clear();
                Console.WriteLine("Invalid operation!");
                Console.WriteLine();
                return;
            }
            else
            {
                int realNumber = int.Parse(stringNumberAndCommad);

                DeleteUserPrint(phoneList, realNumber);

                Console.Write("Would you like to delete this user? - Yes/No: ");
                stringNumberAndCommad = Console.ReadLine();

                if (stringNumberAndCommad == "Yes" || stringNumberAndCommad == "yes")
                {
                    phoneList.RemoveAt(realNumber - 1);
                }
                else
                {
                    Console.Clear();
                    return;
                }
            }
            Console.Clear();
        }

        static private void DeleteUserPrint(List<PhoneBook> phoneList, int number)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("--------------------------User from your phone book----------------------------------------");
            Console.WriteLine("Number | First Name | Last Name  | Fisrt number      | Second number     | Third number");

            string firstName = phoneList[number - 1].FirstName;
            string lastName = phoneList[number - 1].LastName;
            string firstNumber = phoneList[number - 1].PhoneNumbers["first"];
            string secondNumber = "";
            string thirdNumber = "";

            if (phoneList[number - 1].PhoneNumbers.ContainsKey("second"))
                secondNumber = phoneList[number - 1].PhoneNumbers["second"];

            if (phoneList[number - 1].PhoneNumbers.ContainsKey("third"))
                thirdNumber = phoneList[number - 1].PhoneNumbers["third"];

            Console.WriteLine(String.Format("{0,-6} | {1,-10} | {2,-10} | {3,-17} | {4,-17} | {5,-17}", number, firstName, lastName, firstNumber, secondNumber, thirdNumber));
            
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}