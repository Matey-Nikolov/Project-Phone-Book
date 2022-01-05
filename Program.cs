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

            MainFuction main = new MainFuction(); // <List<PhoneBook>>

            phoneList = main.Initialization(phoneList);
            main.MainPrintArguments();

            string endOrCommand = Console.ReadLine();

            while (endOrCommand != "0")
            {
                switch (endOrCommand)
                {
                    case "1":
                        phoneList = main.AddList(phoneList);
                        break;

                    case "2":
                        SearchFromPhoneBook searchList = new SearchFromPhoneBook();
                        searchList.MainSearch(phoneList);
                        break;

                    case "3":
                        EditUserFromPhoneBook<List<PhoneBook>> editList = new EditUserFromPhoneBook<List<PhoneBook>>();
                        editList.MainEdit(phoneList);
                        break;

                    case "4":
                        SortFromPhoneBook sortList = new SortFromPhoneBook();
                        sortList.MainSortPrint(phoneList);
                        break;

                    case "5":
                        main.MainPrintAllPhoneList(phoneList);
                        break;

                    case "6":
                        main.DeleteFromPhoneBook(phoneList);
                        break;
                }
                main.MainPrintArguments();
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
            //{
            //     JsonSerializer serializer = new JsonSerializer();
            //     serializer.Serialize(file, phoneList);
            //}

            //
            // Deserialize PhoneBook List from a file in JSON Format (JSON READ from FILE)
            // 
            // https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm
            // 

            using (StreamWriter file = File.CreateText(@"..\..\..\phoneList.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, phoneList);
            }

            List<PhoneBook> PhoneJsonList = new List<PhoneBook>();

            using (StreamReader file = File.OpenText(@"..\..\..\phoneList.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                PhoneJsonList = (List<PhoneBook>)serializer.Deserialize(file, typeof(List<PhoneBook>));
            }

            Console.Clear();
            Console.WriteLine("Bye.");

           // Test Console Print
          //  string json = JsonConvert.SerializeObject(PhoneJsonList, Formatting.Indented);
         //   Console.WriteLine(json);
        }


        
    }
}