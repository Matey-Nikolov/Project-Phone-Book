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
            Console.WriteLine("1 - Add"); // 90%
            Console.WriteLine("2 - Search"); // 10%
            Console.WriteLine("3 - Edit user"); // 5/5
            Console.WriteLine("4 - Sort phone book"); // 2/3
            Console.WriteLine("5 - List phone book"); // 0/0
            Console.WriteLine("6 - Delete"); // 0/100
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
            string workPhoneNumber = Console.ReadLine();


            if ((firstName == string.Empty && lastName == string.Empty && workPhoneNumber == string.Empty) || (firstName != string.Empty && lastName != string.Empty && workPhoneNumber == string.Empty))
            {
                Console.Clear();
                Console.WriteLine("You must write first, last name and work phone number!");

                Console.Write("Write first name: ");
                firstName = Console.ReadLine();

                Console.Write("Write last name: ");
                lastName = Console.ReadLine();

                Console.Write("Write work phone number +359 ** *** ****:: ");
                workPhoneNumber = Console.ReadLine();
                //  workPhoneNumber = Validation(workPhoneNumber);

                if (firstName == string.Empty && lastName == string.Empty && workPhoneNumber == string.Empty)
                {
                    Console.WriteLine("Bye!");
                }
            }

            //  workPhoneNumber = Validation(workPhoneNumber);

            Console.Write("Enter home phone number +359 ** *** **** (option): ");
            string homePhoneNumber = Console.ReadLine();
            //  homePhoneNumber = Validation(homePhoneNumber);

            Console.Write("Enter mobile phone number +359 ** *** **** (option): ");
            string otherPhoneNumber = Console.ReadLine();
            //   otherPhoneNumber = Validation(otherPhoneNumber);


            if (homePhoneNumber != string.Empty && otherPhoneNumber == string.Empty)
            {
                phoneBook = new PhoneBook(firstName, lastName, workPhoneNumber, homePhoneNumber);
            }

            if (otherPhoneNumber != string.Empty)
            {
                phoneBook = new PhoneBook(firstName, lastName, workPhoneNumber, homePhoneNumber, otherPhoneNumber);
            }
            else
            {
                phoneBook = new PhoneBook(firstName, lastName, workPhoneNumber);
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

        public void MainPrintAllPhoneList(List<PhoneBook> phoneList)
        {
            // 
            // https://stackoverflow.com/questions/856845/how-to-best-way-to-draw-table-in-console-app-c
            //
            //
            // https://www.csharp-console-examples.com/basic/c-datatable-examples/
            //


            foreach (var AllItem in phoneList)
            {
                int count = 1;

                using (DataTable dt = new DataTable("Test"))
                {

                    dt.TableName = "Users";

                    dt.Columns.Add("Number", typeof(int));
                    dt.Columns.Add("FirstName", typeof(string));
                    dt.Columns.Add("LastName", typeof(string));
                    dt.Columns.Add("First number", typeof(string));

                    dt.Rows.Add(count, AllItem.FirstName, AllItem.LastName, AllItem.PhoneNumbers["work"]); // first

                    if (AllItem.PhoneNumbers["home"]== string.Empty && AllItem.PhoneNumbers["home"] == string.Empty)
                    {
                        dt.Rows.Add(count, AllItem.FirstName, AllItem.LastName, AllItem.PhoneNumbers["work"]); // first
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine("ID: {0}\tFirst Name: {1} \t Last Name: {2} \t fist number: {3}", dr[0], dr[1], dr[2], dr[3]);
                    }
                }

                count++;
            }
        }
    }
}