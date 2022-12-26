using System;

namespace AddressBookUsingADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book system - Using ADO.Net ");
            while (true)
            {
                AddressBookBuilder builder = new AddressBookBuilder();
                Console.WriteLine("enter option\n1 Check connection\n2 Insert new contact\n0  exit");
                int option=int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //uc1 create addressbook DB
                        builder.CheckConnection();
                        break;
                    case 2:
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
