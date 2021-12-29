﻿namespace Project_PhoneBook
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
                    PhoneJsonList = (List<PhoneBook>)serializer.Deserialize(streamReader, typeof(List<PhoneBook>));
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











          



            string endOrCommand = Console.ReadLine();

            while (endOrCommand != "End")
            {
                string command = endOrCommand;

                switch (command)
                {
                    case "Add":
                        Console.WriteLine("Write first name.");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Write last name.");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Write phone number.");
                        string workPhoneNumber = Console.ReadLine();

                        PhoneBook phoneBook = new PhoneBook(firstName, lastName, workPhoneNumber);

                        phoneList.Add(phoneBook);
                        break;

                    case "Modifical":
                        Console.WriteLine("Fisrt name - 1.");
                        Console.WriteLine("Last name - 2.");
                        Console.WriteLine("Work number - 3.");
                        Console.WriteLine("Home number - 4.");
                        Console.WriteLine("Mobile number - 5.");

                        string modificalCommand = Console.ReadLine();

                        ModificationUserFromPhoneBook<List<PhoneBook>> modification = new ModificationUserFromPhoneBook<List<PhoneBook>>();


                        switch (modificalCommand)
                        {
                            case "1":
                                modification.ModificationFirstName(phoneList);
                                break;
                            case "2":
                                modification.ModificationLastName(phoneList);
                                break;
                            case "3":
                                modification.ModificationWorkNumber(phoneList);
                                break;
                            case "4":
                                break;
                            case "5":
                                break;
                        }

                        //  phoneList.Add(phoneBook);
                        break;

                    case "RemoveFirstName":

                        Console.WriteLine("Write first name for remove.");
                        string removeFirstName = Console.ReadLine();

                        List<PhoneBook> foundDuplicateFirstName = new List<PhoneBook>();

                        for (int i = 0; i < phoneList.Count; i++)
                        {
                            if (phoneList[i].FirstName == removeFirstName)
                                foundDuplicateFirstName.Add(phoneList[i]);
                        }


                        if (foundDuplicateFirstName.Count != 1)
                        {
                            Console.WriteLine("Duplicate name!");

                            int count = 1;
                            foreach (var item in foundDuplicateFirstName)
                            {
                                Console.WriteLine($"{count} -> {item.FirstName} - phone number {item.PhoneNumbers["work"]}");
                                count++;
                            }

                            Console.WriteLine("Choose with numbers ");
                            int number = int.Parse(Console.ReadLine());

                            phoneList[number].FirstName = null;
                        }
                        else
                        {
                            for (int j = 0; j < phoneList.Count; j++)
                            {
                                if (phoneList[j].FirstName == removeFirstName)
                                    phoneList[j].FirstName = null;

                                    break;
                            }
                        }
                        break;
                    case "RemoveLastName":

                        Console.WriteLine("Write last name for remove.");
                        string removeLastName = Console.ReadLine();

                        List<PhoneBook> foundDuplicateLastName = new List<PhoneBook>();

                        for (int i = 0; i < phoneList.Count; i++)
                        {
                            if (phoneList[i].FirstName == removeLastName)
                                foundDuplicateLastName.Add(phoneList[i]);
                        }


                        if (foundDuplicateLastName.Count != 1)
                        {
                            Console.WriteLine("Duplicate name!");

                            int count = 1;
                            foreach (var item in foundDuplicateLastName)
                            {
                                Console.WriteLine($"{count} -> {item.FirstName} - phone number {item.PhoneNumbers["work"]}");
                                count++;
                            }

                            Console.WriteLine("Choose with numbers ");
                            int number = int.Parse(Console.ReadLine());

                            phoneList[number].FirstName = null;
                        }
                        else
                        {
                            for (int j = 0; j < phoneList.Count; j++)
                            {
                                if (phoneList[j].FirstName == removeLastName)
                                    phoneList[j].FirstName = null;

                                break;
                            }
                        }
                        break;

                    case "DeletePhoneNumber":

                        Console.WriteLine("Write phone number. This is the permanent delete number.");
                        string pernamentDeletePhoneNumber = Console.ReadLine();
                        Console.WriteLine("Write work/home/mobile.");
                        string workHomeOrMobile = Console.ReadLine();

                        foreach (var item in phoneList)
                        {
                            if (item.PhoneNumbers[workHomeOrMobile] == pernamentDeletePhoneNumber)
                            {
                                item.PhoneNumbers[workHomeOrMobile] = null;
                            }
                        }
                        break;

                }


                endOrCommand = Console.ReadLine();
            }







            /*
            List<PhoneBook> phoneList = new List<PhoneBook>()
            {
                new PhoneBook{ FirstName = "One", LastName = "One",
                        PhoneNumbers = new Dictionary<string, string>
                                    {
                                        { "work","1234"},
                                        { "home","5678"}
                                    }},
                new PhoneBook{ FirstName = "Two", LastName = "Two",
                    PhoneNumbers = new Dictionary<string, string>
                                    {
                                        { "work","1234"},
                                        { "home","5678"}
                                    }},
                new PhoneBook{ FirstName = "Four", LastName = "Four",
                    PhoneNumbers = new Dictionary<string, string>
                                    {
                                        { "work","1234"},
                                    }},
                new PhoneBook{ FirstName = "End", LastName = "Name",
                    PhoneNumbers = new Dictionary<string, string>
                                    {
                                        { "work","1234"},
                                        { "home","5678"},
                                        { "mobile","5678"}
                                    }},
            };
            */






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

            using (StreamWriter file = File.CreateText(@"..\..\..\phoneList.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, phoneList);
            }

            //
            // Deserialize PhoneBook List from a file in JSON Format (JSON READ from FILE)
            // 
            // https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm
            // 

            List<PhoneBook> PhoneJsonList;

            using (StreamReader file = File.OpenText(@"..\..\..\phoneList.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                PhoneJsonList = (List<PhoneBook>)serializer.Deserialize(file, typeof(List<PhoneBook>));
            }

            // Test Console Print
            string json = JsonConvert.SerializeObject(PhoneJsonList, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
