namespace Project_PhoneBook
{
    using System;
    //
    // Инсталиране на Newtonsoft.Json 
    // Project>Managet NuGet packages...
    // Brows>Search> Newtonsoft.Json
    // Install
    //
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Program
    {
        static void Main()
        {
            List<PhoneBook> phoneList = new List<PhoneBook>();

            List<PhoneBook> PhoneJsonList = new List<PhoneBook>();
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


            Console.WriteLine("Add - 1."); // 90%
            Console.WriteLine("Research - 2."); // 10%
            Console.WriteLine("Change user - 3."); // 5/5
            Console.WriteLine("Sort phone book - 4"); // 2/3
            Console.WriteLine("Delete - 5"); // 0/100
            Console.WriteLine("End - 6.");   // 100 %

            string endOrCommand = Console.ReadLine().ToLower();

            while (endOrCommand != "6")
            {
                string command = endOrCommand;

                switch (command)
                {
                    case "1":
                        Add(phoneList);
                        using (StreamWriter file = File.CreateText(@"..\..\..\phoneList.json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Serialize(file, phoneList);
                        }
                        break;

                    case "2":
                        ResearchFromPhoneBook research = new ResearchFromPhoneBook();
                        research.MainResearch(phoneList);
                        break;

                    case "3":
                        ModificationUserFromPhoneBook<List<PhoneBook>> changes = new ModificationUserFromPhoneBook<List<PhoneBook>>();
                        changes.MainChanges(phoneList);
                        break;

                    case "4":
                        SortAndPrintFromPhoneBook sortPrint = new SortAndPrintFromPhoneBook();
                        sortPrint.MainSortPrint(phoneList);
                        break;
                    case "5":

                        break;

                }

                Console.WriteLine("Add - 1."); // 90%
                Console.WriteLine("Research - 2."); // 10%
                Console.WriteLine("Change user - 3."); // 5/5
                Console.WriteLine("Sort phone book - 4"); // 2/3
                Console.WriteLine("Delete - 5"); // 0/100
                Console.WriteLine("End - 6.");   // 100 %

                endOrCommand = Console.ReadLine();
                Console.Clear();
            }

            // 
            // Serialize PhoneBook List to File in JSON Format (JSON WRITE to FILE)
            //
            // Програмиране за .NET Framework (том 2)
            // Глава 20. Сериализация на данни стр. 459
            //
            // Json.NET - https://www.newtonsoft.com/json/help/html/Introduction.htm 
            // https://www.newtonsoft.com/json/help/html/SerializeWithJsonSerializerToFile.htm 
            //
            // Принципи на програмирането със C# Версия 3.0(май 2018)
            // Глава 15. Текстови файлове  стр. 637
            // Потоци, Текстови потоци
            // using(<stream object>) { … } стр. 648
            //
            //
            //
            //using (StreamWriter file = File.CreateText(@"..\..\..\phoneList.json"))
            // {
            //     JsonSerializer serializer = new JsonSerializer();
            //     serializer.Serialize(file, phoneList);
            //  }

            //
            // Deserialize PhoneBook List from a file in JSON Format (JSON READ from FILE)
            // 
            // https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm
            // 

            //  List<PhoneBook> PhoneJsonList;

            using (StreamReader file = File.OpenText(@"..\..\..\phoneList.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                PhoneJsonList = (List<PhoneBook>)serializer.Deserialize(file, typeof(List<PhoneBook>));
            }

            // Test Console Print
            string json = JsonConvert.SerializeObject(PhoneJsonList, Formatting.Indented);
            Console.WriteLine(json);
        }

        public static void Add(List<PhoneBook> phoneList)
        {
            PhoneBook phoneBook = new PhoneBook();

            Console.Write("Write first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Write last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Write work phone number +359 ** *** ****: ");
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
                workPhoneNumber = Validation(workPhoneNumber);

                if (firstName == string.Empty && lastName == string.Empty && workPhoneNumber == string.Empty)
                {
                    Console.WriteLine("Bye!");
                    return;
                }
            }

            workPhoneNumber = Validation(workPhoneNumber);

            Console.Write("Write home phone number +359 ** *** **** (option): ");
            string homePhoneNumber = Console.ReadLine();
            homePhoneNumber = Validation(homePhoneNumber);
            
            Console.Write("Write mobile phone number +359 ** *** **** (option): ");
            string otherPhoneNumber = Console.ReadLine();
            otherPhoneNumber = Validation(otherPhoneNumber);


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
        }

        static public string Validation(string phoneNumber)
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
    }
}