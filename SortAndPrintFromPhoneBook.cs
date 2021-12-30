namespace Project_PhoneBook
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SortAndPrintFromPhoneBook /*: IEnumerable<PhoneBook>*/
    {
       // private List<PhoneBook> phoneList2 { get; set; }

        public void MainSortPrint(ref List<PhoneBook> phoneList)
        {
            Console.Clear();
            Console.WriteLine("Sort by first name - 1.");
            Console.WriteLine("Sort by phone number - 2.");

            string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    SortByName(ref phoneList);
                    break;
                case "2":
                    SortByPhoneNumber(ref phoneList);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid numbers!");
                    Console.WriteLine();
                    break;
            }
        }

        static private void SortByName(ref List<PhoneBook> phoneList)
        {
            Console.Clear();
            Console.WriteLine("Descending order - 1.");
            Console.WriteLine("Ascending order - 2.");

            string number = Console.ReadLine();

            if (number == "1")
            {
                foreach (var all in phoneList.OrderBy(x => x.FirstName))
                {
                    Console.WriteLine($"{all.FirstName} {all.LastName}");
                    Console.WriteLine($"    Work phone number: {all.PhoneNumbers["work"]}");

                    if (all.PhoneNumbers.ContainsKey("home"))
                        Console.WriteLine($"    Home phone number: {all.PhoneNumbers["home"]}");
                    else if (all.PhoneNumbers.ContainsKey("other"))
                        Console.WriteLine($"    Other phone number: {all.PhoneNumbers["other"]}");
                }
            }
            else if (number == "2")
            {
                foreach (var all in phoneList.OrderByDescending(x => x.FirstName))
                {
                    Console.WriteLine($"{all.FirstName} {all.LastName}");
                    Console.WriteLine($"    Work phone number: {all.PhoneNumbers["work"]}");

                    if (all.PhoneNumbers.ContainsKey("home"))
                        Console.WriteLine($"    Home phone number: {all.PhoneNumbers["home"]}");
                    else if (all.PhoneNumbers.ContainsKey("other"))
                        Console.WriteLine($"    Other phone number: {all.PhoneNumbers["other"]}");
                }

            }
            else
            {
                Console.WriteLine("Invalid number!");
                return;
            }

        }

        static private void SortByPhoneNumber(ref List<PhoneBook> phoneList)
        {
            foreach (var all in phoneList.OrderBy(x => x.PhoneNumbers["work"]))
            {
                Console.WriteLine($"{all.FirstName} {all.LastName}");
                Console.WriteLine($"    Work phone number: {all.PhoneNumbers["work"]}");

                if (all.PhoneNumbers.ContainsKey("home"))
                    Console.WriteLine($"    Home phone number: {all.PhoneNumbers["home"]}");
                else if (all.PhoneNumbers.ContainsKey("other"))
                    Console.WriteLine($"    Other phone number: {all.PhoneNumbers["other"]}");
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