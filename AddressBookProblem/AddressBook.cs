﻿using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBookProblem
{
    public class AddressBook
    {
        int Count = 0;
        List<Contact> addressBook = new List<Contact>(); //created list to store multiple contact
        static Dictionary<string ,List<Contact>> dict = new Dictionary<string ,List<Contact>>();  //Like shrey have many contact and many more perple have many  contact
        Dictionary<string, List<Contact>> CityCount = new Dictionary<string, List<Contact>>();
        Dictionary<string, List<Contact>> StateCount = new Dictionary<string, List<Contact>>();
        Dictionary<string, List<Contact>> sort = new Dictionary<string, List<Contact>>();
        public void CreateContact()
        {
            Console.WriteLine("Enter the detais :\n 1.First Name \n2.Last name \n3.Address \n4.City Name \n5.State Name \n.6.Zip code \n7.Phone Number \n8.Email Address ");
            Contact contact = new Contact()
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Address = Console.ReadLine(),
                City = Console.ReadLine(),
                State  = Console.ReadLine(),
                Zip = Convert.ToInt32(Console.ReadLine()),
                PhoneNumber = Convert.ToInt32(Console.ReadLine()),
                Email = Console.ReadLine(),
            };

            foreach (var data in dict)
            {
                foreach (var item in data.Value)
                {
                    if (item.FirstName.Equals(contact.FirstName))
                    {
                        Console.WriteLine("Your name is Already Registred in the Address Book");
                        Count++;
                    }
                }
            }
            if (Count == 0)
            {
                Console.WriteLine(contact.FirstName + " " + contact.LastName + " is added to the contact");
                addressBook.Add(contact);
            }
        }
        public void AddAddressBookToDictionary()
        {
            string uniqueName = Console.ReadLine();
            dict.Add(uniqueName, addressBook);
            addressBook = new List<Contact>();
        }
        public void EditContact(string name, string contactName)
        {
            foreach (var data in dict)
            {
                if (data.Key.Equals(name))
                {
                    foreach (var contact in data.Value)
                    {
                        if (contact.FirstName.Equals(contactName) || contact.LastName.Equals(contactName))
                        {
                            Console.WriteLine("Enter the option to Edit -->  \n1.Last name \n2.Address \n3.City Name \n4.State Name \n.5.Zip code \n6.Phone Number \n7.Email Address ");
                            int option = Convert.ToInt32(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    contact.LastName = Console.ReadLine();
                                    break;
                                case 2:
                                    contact.Address = Console.ReadLine();
                                    break;
                                case 3:
                                    contact.City = Console.ReadLine();
                                    break;
                                   case 4:
                                    contact.State = Console.ReadLine();
                                    break;
                                case 5:
                                    contact.Zip = Convert.ToInt32(Console.ReadLine());
                                    break;
                                case 6:
                                    contact.PhoneNumber = Convert.ToInt32(Console.ReadLine());
                                    break;
                                case 7:
                                    contact.Email = Console.ReadLine();
                                    break;
                            }
                        }
                        else { Console.WriteLine("Not name found"); }
                    }
                }
                else
                {
                    Console.WriteLine("No Dictionary with key exist ");
                }
          
            }
        }
        public void SearchByCityOrState()
        {
            Console.WriteLine("Enter the number to Search\n1.City\n2.State");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                Console.WriteLine("Enter the city to search");
                string city = Console.ReadLine();
                List<Contact> contact = new List<Contact>();
                Console.WriteLine("The persons in the City are: ");
                foreach (var data in dict)
                {
                    contact = data.Value.Where(x => x.City == city).ToList();
                    foreach (var Contact in contact)
                    {
                        Console.WriteLine(Contact.FirstName + " " + Contact.LastName);
                        CityCount.Add(data.Key, contact);
                    }
                }
              
                Console.WriteLine("Enter the Persone Name to Search in the city");
                string name = Console.ReadLine();
                foreach (var Contact in contact)
                {
                    if (Contact.FirstName.Equals(name))
                    {
                        Console.WriteLine("The Person is found in the given city and his phone number is");
                        Console.WriteLine(Contact.FirstName + " " + Contact.LastName + " " + Contact.PhoneNumber);
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter the State to search");
                string state = Console.ReadLine();
                List<Contact> contact = new List<Contact>();
                foreach (var data in dict)
                {
                    contact = data.Value.Where(x => x.State.Equals(state)).ToList();
                }
                foreach (var Contact in contact)
                {
                    Console.WriteLine(Contact.FirstName + " " + Contact.LastName + "is found in that State");
                    StateCount.Add(state, contact);
                }
                Console.WriteLine("Enter the Persone Name to Search in this State");
                string name = Console.ReadLine();
                foreach (var Contact in contact)
                {
                    if (Contact.FirstName.Equals(name))
                    {
                        Console.WriteLine("The Person is found in the given state and his phone number is");
                        Console.WriteLine(Contact.FirstName + " " + Contact.LastName + " " + Contact.PhoneNumber);
                    }
                }
            }
        }

        public void DeleteContact (string name, string contactName)
        {
            Contact contact = new Contact();
            foreach (var data in dict)
            {
                if (data.Key.Equals(name))
                {
                    foreach (var item in data.Value)
                    {
                        if (item.FirstName.Equals(contactName) || item.LastName.Equals(contactName))
                        {
                            contact = item;
                        }

                    }
                    data.Value.Remove(contact);

                }
            }
        }

        public void Display()
        {
            foreach(var data in dict)
            {
                Console.WriteLine(data.Key);
                foreach (var contact in data.Value)
                {
                    Console.WriteLine("View Details \n");
                    Console.WriteLine(contact.FirstName + "\n" + contact.LastName + "\n" + contact.Address + "\n" + contact.City + "\n" + contact.State + "\n" + contact.Zip + "\n" + contact.PhoneNumber + "\n" + contact.Email + "\n");
                }
            }
            
        }
        public void CountCity()
        {
            int cityCount = 0;
            foreach (var data in CityCount)
            {
                Console.WriteLine("Data key --->" + data.Key);
                foreach (var contact in data.Value)
                {
                    Console.WriteLine("First name --->" + contact.FirstName + "\nLast Name ----->" + contact.LastName);
                    cityCount++;
                }
            }
            Console.WriteLine("The Number of the count in the city " + cityCount);
        }
        public void CountState()
        {
            int stateCount = 0;
            foreach (var data in StateCount)
            {
                Console.WriteLine("Data key --->" + data.Key);
                foreach (var contact in data.Value)
                {
                    Console.WriteLine("First name --->" + contact.FirstName + "\nLast Name ----->" + contact.LastName);
                    stateCount++;
                }
            }
            Console.WriteLine("The Number of the count in the State " + stateCount);
        }
        public void Sort()
        {
            Console.WriteLine("Write the number to Sort \n1.Name\n2.City\n3.State\n4.Zip");
            int num = Convert.ToInt32(Console.ReadLine());
            foreach (var data in dict.Values)
            {
                if (num == 1)
                {
                    data.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
                }
                if (num == 2)
                {
                    data.Sort((a, b) => a.City.CompareTo(b.City));
                }
                if (num == 3)
                {
                    data.Sort((a, b) => a.State.CompareTo(b.State));
                }
                if (num == 4)
                {
                    data.Sort((a, b) => a.Zip.CompareTo(b.Zip));
                }
            }
            Display();
        }
        public void ReadFromStreamWriter(string filepath)
        {
            using (StreamWriter stream = File.AppendText(filepath))
            {
                foreach (var data in dict)
                {
                    stream.WriteLine(data.Key);
                    foreach (var contact in data.Value)
                    {
                        stream.WriteLine(contact.FirstName + "," + contact.LastName + "," + contact.Address + "," + contact.City + "," + contact.State + "," + contact.Zip + "," + contact.PhoneNumber
                            + "," + contact.Email);
                    }
                }
                stream.Close();
            }
        }
        public void ReadFromStreamReader(string filepath)
        {
            using (StreamReader stream = File.OpenText(filepath))
            {
                string s = "";
                while ((s = stream.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        public void ReadCSVFile(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            {
                using (var CSV = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = CSV.GetRecords<Contact>().ToList();
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.FirstName + "---" + data.LastName + "---" + data.Address + "---" + data.City + "---" + data.State + "---" + data.Zip + "---" + data.PhoneNumber + "---" + data.Email);
                    }
                }
            }
        }
        public void WriteCSVfile(string filepath)
        {
            using (var writer = new StreamWriter(filepath))
            {
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (var data in dict)
                    {
                        csvExport.WriteRecords(data.Value);
                    }
                }
            }
        }
        public void ReadFromJsonFile(string filepath)
        {
            var json = File.ReadAllText(filepath);
            dict = JsonConvert.DeserializeObject<Dictionary<string, List<Contact>>>(json);
            Display();
        }
        public void WriteToJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(dict);
            File.WriteAllText(filePath, json);
        }
    }
}
