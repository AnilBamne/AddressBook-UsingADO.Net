using System;

namespace AddressBookUsingADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book system - Using ADO.Net ");
            AddressBookBuilder addressBookBuilder = new AddressBookBuilder();
            AddressBookModel addressBookModel = new AddressBookModel();
            while (true)
            {
                AddressBookBuilder builder = new AddressBookBuilder();
                Console.WriteLine("enter option\n1 Check connection\n2 AddNewContactToAddressBook DB\n3 EditExistingContatc\n4 DeleteExistingContatc\n0  exit");
                int option=int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //uc1 create addressbook DB
                        builder.CheckConnection();
                        break;
                    case 2:
                        //uc2 Add new contact to Address book
                        
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
                        //uc3 Edit existing contact
                        addressBookModel.FirstName = "Vijay";
                        addressBookModel.LastName = "Deverkonda";
                        addressBookModel.Address = "Hyd";
                        addressBookModel.City = "Hydrabad";
                        addressBookModel.State = "TS";
                        addressBookModel.Zip = 234234;
                        addressBookModel.PhoneNo = 85629485;
                        addressBookModel.Email = "VijayD@gmail.com";
                        addressBookModel.AddressBookType = "Actor";
                        addressBookModel.AddressBookName = "celebs";
                        addressBookBuilder.EditExistingContatc(addressBookModel,"Vijay");
                        break;
                    case 4:
                        //uc4 delete contact fron BD
                        addressBookModel.FirstName = "Vijay";
                        addressBookBuilder.DeleteExistingContatc(addressBookModel);
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
