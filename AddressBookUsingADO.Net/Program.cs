using System;

namespace AddressBookUsingADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book system - Using ADO.Net ");
            AddressBookBuilder addressBookBuilder = new AddressBookBuilder();
            while (true)
            {
                AddressBookBuilder builder = new AddressBookBuilder();
                Console.WriteLine("enter option\n1 Check connection\n2 AddNewContactToAddressBook DB\n0  exit");
                int option=int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //uc1 create addressbook DB
                        builder.CheckConnection();
                        break;
                    case 2:
                        //uc2 Add new contact to Address book
                        AddressBookModel addressBookModel = new AddressBookModel();
                        addressBookModel.FirstName = "Vijay";
                        addressBookModel.LastName = "Deverkonda";
                        addressBookModel.Address = "Hyd";
                        addressBookModel.City = "Hydrabad";
                        addressBookModel.State = "Telangana";
                        addressBookModel.Zip = 234234;
                        addressBookModel.PhoneNo = 85629485;
                        addressBookModel.Email = "VijayDeverkonda@gmail.com";
                        addressBookModel.AddressBookType = "Actor";
                        addressBookModel.AddressBookName = "A";
                        addressBookBuilder.AddNewContactToAddressBook(addressBookModel);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
