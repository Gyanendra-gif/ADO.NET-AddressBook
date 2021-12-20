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
                Console.WriteLine("Enter your Choice Number to Execute the Program Press- 1-Addition of Contact,  2-Updation of Contact, 3-Deletion of Contact, 4-View, 5-Exit");
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
                        Console.WriteLine("Enter Your Id Which you want to update");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Your Name");
                        string FirstName = Console.ReadLine();                                               
                        bool res = addressBookConfig.UpdateContact(id, FirstName);
                        if (res == true)     
                            Console.WriteLine("Updated Successfully");                        
                        else                        
                            Console.WriteLine("Not Updated");                        
                        break;
                    case 3:
                        flag = false;
                        break;
                }
            }
        }
    }
}