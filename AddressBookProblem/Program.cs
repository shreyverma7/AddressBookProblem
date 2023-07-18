using AddressBookProblem;

internal class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("Welcome to Address book Problem :");
        bool flag = true;
        string key = null, input = null;
        AddressBook addressBook = new AddressBook();
        while (flag)
        {
            Console.WriteLine("Enter the option to proceed \n1. Create Contact \n2. Add to Dictionary \n3. Edit contact  \n4. Delete Details \n5. display \n6. exit");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Creating contact : -->\n");
                    addressBook.CreateContact();
                    break;
                case 2: 
                    addressBook.AddAddressBookToDictionary();
                    break;
                case 3:
                    Console.WriteLine("Enter Key");
                    key = Console.ReadLine();
                    Console.WriteLine("Enter name to Edit contact details");
                    input = Console.ReadLine();
                    addressBook.EditContact(key,input);
                    break;
                case 4:
                    Console.WriteLine("Enter key\n");
                    key = Console.ReadLine();
                    Console.WriteLine("Enter name to delete contact details");
                   input = Console.ReadLine();
                    addressBook.DeleteContact(key,input);
                    break;
                case 5:
                    addressBook.Display();
                    break;
                case 6: 
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Invalid Value");
                    break;




            }
        }

    }
}