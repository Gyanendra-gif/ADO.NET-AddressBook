using System;

namespace ADO.NET_AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ADO.NET Address Book");
            AddressBookConfig addressBookConfig = new AddressBookConfig();
            Contact contact = new Contact();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter your Choice Number to Execute the Program Press- 1-Addition of Contact, 2-Deletion of Contact, 3-Updation of Contact, 4-View, 5-Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        contact.FirstName = "Ram";
                        contact.LastName = "Singh";
                        contact.Address = "Rewa";
                        contact.City = "Satna";
                        contact.State = "M.P";
                        contact.ZipCode = 123456;
                        contact.Phone = 1234567890;
                        contact.Email = "xyz@gmail.com";
                        var result = addressBookConfig.AddContact(contact);
                        if (result != null)                        
                            Console.WriteLine("Data of Customer Added Successfully");
                        else
                            Console.WriteLine("Provide Data According to Coloumn");                        
                        break;
                    case 2:
                        flag = false;
                        break;
                }
            }
        }
    }
}