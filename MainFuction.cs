using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.WriteLine("3 - Edit user"); // 0/5
            Console.WriteLine("4 - Sort phone book"); // 2/3
            Console.WriteLine("5 - List phone book"); // 100%
            Console.WriteLine("6 - Delete"); // 100%
            Console.WriteLine("0 - End");   // 100 %
            Console.Write("Please enter your choise: ");
        }

        public List<PhoneBook> AddList(List<PhoneBook>  phoneList) //List<T>
        {
            
            PhoneBook phoneBook = new PhoneBook();

            Console.Write("Enter first name*: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name*: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter first phone number* +359 ** *** ****: ");
            string firstPhoneNumber = Console.ReadLine();


            if ((firstName == string.Empty && lastName == string.Empty && firstPhoneNumber == string.Empty) || (firstName != string.Empty && lastName != string.Empty && firstPhoneNumber == string.Empty))
            {
                Console.Clear();
                Console.WriteLine("You must write first, last name and work phone number!");

                Console.Write("Enter first name: ");
                firstName = Console.ReadLine();

                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();

                Console.Write("Enter fisrt phone number +359 ** *** ****: ");
                firstPhoneNumber = Console.ReadLine();
                //  workPhoneNumber = Validation(workPhoneNumber);

                if (firstName == string.Empty && lastName == string.Empty && firstPhoneNumber == string.Empty)
                {
                    Console.WriteLine("Bye!");
                }
            }

            //  workPhoneNumber = Validation(workPhoneNumber);

            Console.Write("Enter second phone number +359 ** *** **** (option): ");
            string secondPhoneNumber = Console.ReadLine();
            //  homePhoneNumber = Validation(homePhoneNumber);

            Console.Write("Enter third phone number +359 ** *** **** (option): ");
            string thirdPhoneNumber = Console.ReadLine();
            //   otherPhoneNumber = Validation(otherPhoneNumber);


            if (secondPhoneNumber != string.Empty && thirdPhoneNumber == string.Empty)
            {
                phoneBook = new PhoneBook(firstName, lastName, firstPhoneNumber, secondPhoneNumber);
            }

            if (thirdPhoneNumber != string.Empty)
            {
                phoneBook = new PhoneBook(firstName, lastName, firstPhoneNumber, secondPhoneNumber, thirdPhoneNumber);
            }
            else
            {
                phoneBook = new PhoneBook(firstName, lastName, firstPhoneNumber);
            }

            phoneList.Add(phoneBook);
            return phoneList;
            
        }

        /*
        private string Validation(string phoneNumber)
        {
            string pattern = @"(\+359) ?[0-9]{2} ?[0-9]{3} ?[0-9]{4}";

            if (phoneNumber != string.Empty)
            {
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
                        return "";
                    }
                    else
                        return tryAgainPhoneNumber;
                }
            }

            return phoneNumber;
        }
        */

        public int MainPrintAllPhoneList(List<PhoneBook> phoneList)
        {
            //
            // https://www.csharp-examples.net/align-string-with-spaces/
            //

            int count = 1;
         // Console.Clear();
            Console.WriteLine("--------------------------All user from your phone bok-------------------------------------");
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

        public void RemoveFromPhoneBook(List<PhoneBook> phoneList)
        {
            if (phoneList.Count == 0)
            {
                Console.WriteLine("Empty phone book!");
                return;
            }

            Console.Clear();
            Console.WriteLine("Print all users from your phone bok.");

            MainPrintAllPhoneList(phoneList);

            Console.Write("Choose number you want to delete from your phone book: ");
            int number = int.Parse(Console.ReadLine());

            phoneList.RemoveAt(number);
        }
    }
}