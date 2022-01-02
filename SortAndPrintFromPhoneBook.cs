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

    public class SortAndPrintFromPhoneBook /*: IEnumerable<PhoneBook>*/
    {
       // private List<PhoneBook> phoneList2 { get; set; }

        public void MainSortPrint(List<PhoneBook> phoneList)
        {
            Console.Clear();
            Console.WriteLine("Sort by first name then by last name - 1."); // 2/2
            Console.WriteLine("Sort by phone number - 2."); // 1/3

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
                    Console.WriteLine("Invalid numbers!");
                    Console.WriteLine();
                    break;
            }
        }

        static private void SortByName(List<PhoneBook> phoneList)
        {
            Console.Clear();
            Console.WriteLine("Descending order - 1.");
            Console.WriteLine("Ascending order - 2.");

            string number = Console.ReadLine();
            List<PhoneBook> newSortPhoneList = new List<PhoneBook>();

            if (number == "1")
            {
                foreach (var all in phoneList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    Console.WriteLine($"{all.FirstName} {all.LastName}");
                    Console.WriteLine($"    Work phone number: {all.PhoneNumbers["first"]}");

                    if (all.PhoneNumbers.ContainsKey("home"))
                        Console.WriteLine($"    Home phone number: {all.PhoneNumbers["second"]}");
                    else if (all.PhoneNumbers.ContainsKey("other"))
                        Console.WriteLine($"    Other phone number: {all.PhoneNumbers["third"]}");

                    newSortPhoneList.Add(all);
                }
            }
            else if (number == "2")
            {
                foreach (var all in phoneList.OrderByDescending(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    Console.WriteLine($"{all.FirstName} {all.LastName}");
                    Console.WriteLine($"    Work phone number: {all.PhoneNumbers["first"]}");

                    if (all.PhoneNumbers.ContainsKey("home"))
                        Console.WriteLine($"    Home phone number: {all.PhoneNumbers["second"]}");
                    else if (all.PhoneNumbers.ContainsKey("other"))
                        Console.WriteLine($"    Other phone number: {all.PhoneNumbers["third"]}");

                    newSortPhoneList.Add(all);
                }
            }
            else
            {
                Console.WriteLine("Invalid number!");
                return;
            }


            using (StreamWriter file = File.CreateText(@"..\..\..\phoneList.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, newSortPhoneList);
            }
        }

        static private void SortByPhoneNumber(List<PhoneBook> phoneList)
        {
            Console.Clear();
            Console.WriteLine("Sort by fisrt phone number.");

            List<PhoneBook> newSortPhoneNumberList = new List<PhoneBook>();

            foreach (var all in phoneList.OrderBy(x => x.PhoneNumbers["first"]))
            {
                Console.WriteLine($"{all.FirstName} {all.LastName}");
                Console.WriteLine($"    Work phone number: {all.PhoneNumbers["first"]}");

                if (all.PhoneNumbers.ContainsKey("home"))
                    Console.WriteLine($"    Home phone number: {all.PhoneNumbers["second"]}");
                else if (all.PhoneNumbers.ContainsKey("other"))
                    Console.WriteLine($"    Other phone number: {all.PhoneNumbers["third"]}");
            }
        }


        /*
        
        public IEnumerator<PhoneBook> GetEnumerator()
        {
            for (int i = 0; i < phoneList2.Count; i++)
            {
                yield return phoneList2[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        */
    }
}