﻿using AddressBookProblem;

internal class Program
{
     static string inventory_filePath = @"D:\Bridgelabz Problem statement\AddressBookProblem\AddressBookProblem\ContactBook.json";
    static string filepath = @"D:\Bridgelabz Problem statement\AddressBookProblem\AddressBookProblem\ContactFile.txt";
    static string ContactCSVfilepath = @"D:\Bridgelabz Problem statement\AddressBookProblem\AddressBookProblem\ContactFile.csv";
    public static void Main(string[] args)
    {


        Console.WriteLine("Welcome to Address book Problem :");
        bool flag = true;
        string key = null, input = null;
        AddressBook addressBook = new AddressBook();
        while (flag)
        {
            Console.WriteLine("Enter the option to proceed \n1. Create Contact \n2. Add to Dictionary \n3. Edit contact  \n4. Delete Details \n5. display\n6. Search By city " +
                "\n7. CityCount \n8. StateCount  \n9. Sort \n10. Read File from text \n11. Write file to text \n12. Read CSV file \n13. Write CSV file" +
                "\n14. Read from JSON \n15. Write to JSON \n16. exit");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Creating contact : -->\n");
                    addressBook.CreateContact();
                    addressBook.WriteToJsonFile(inventory_filePath);
                    break;
                case 2: 
                    addressBook.AddAddressBookToDictionary();
                    addressBook.WriteToJsonFile(inventory_filePath);
                    break;
                case 3:
                    Console.WriteLine("Enter Key");
                    key = Console.ReadLine();
                    Console.WriteLine("Enter name to Edit contact details");
                    input = Console.ReadLine();
                    addressBook.EditContact(key,input);
                    addressBook.WriteToJsonFile(inventory_filePath);
                    break;
                case 4:
                    Console.WriteLine("Enter key\n");
                    key = Console.ReadLine();
                    Console.WriteLine("Enter name to delete contact details");
                   input = Console.ReadLine();
                    addressBook.DeleteContact(key,input);
                    addressBook.WriteToJsonFile(inventory_filePath);
                    break;
                case 5:
                    addressBook.Display();
                    break;
                case 6:
                    addressBook.SearchByCityOrState();
                    break;
                case 7:
                    addressBook.CountCity();
                    break;
                case 8:
                    addressBook.CountState();
                    break;
                case 9:
                    addressBook.Sort();
                    break;
                case 10:
                    addressBook.ReadFromStreamReader(filepath);
                    break;
                case 11:
                    addressBook.ReadFromStreamWriter(filepath);
                    break;
                case 12:
                    addressBook.ReadCSVFile(ContactCSVfilepath);
                    break;
                case 13:
                    addressBook.WriteCSVfile(ContactCSVfilepath);
                    break;
                case 14:
                    addressBook.ReadFromJsonFile(inventory_filePath);
                    break;
                case 15:
                    addressBook.WriteToJsonFile(inventory_filePath);
                    break;
                case 16: 
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Invalid Value");
                    break;




            }
        }

    }
}