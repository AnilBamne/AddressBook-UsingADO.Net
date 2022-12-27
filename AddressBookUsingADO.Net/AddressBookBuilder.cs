using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUsingADO.Net
{
    public class AddressBookBuilder
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True;";
        SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// Establishing connection with database
        /// </summary>
        public void CheckConnection()
        {
            try
            {
                this.connection.Open();
                Console.WriteLine("Connection established succesfully");
                this.connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// uc2 : Adding new contact to address book DataBase
        /// </summary>
        /// <param name="addressBookModel"></param>
        public void AddNewContactToAddressBook(AddressBookModel addressBookModel)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddNewContact", this.connection);
                    this.connection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", addressBookModel.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", addressBookModel.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", addressBookModel.Address);
                    sqlCommand.Parameters.AddWithValue("@City", addressBookModel.City);
                    sqlCommand.Parameters.AddWithValue("@State", addressBookModel.State);
                    sqlCommand.Parameters.AddWithValue("@Zip", addressBookModel.Zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNo", addressBookModel.PhoneNo);
                    sqlCommand.Parameters.AddWithValue("@Email", addressBookModel.Email);
                    sqlCommand.Parameters.AddWithValue("@AddressBookName", addressBookModel.AddressBookName);
                    sqlCommand.Parameters.AddWithValue("@AddressBookType", addressBookModel.AddressBookType);
                    
                    var count=sqlCommand.ExecuteNonQuery();
                    this.connection.Close();
                    if (count != 0)
                    {
                        Console.WriteLine("Contact added successfully");
                    }
                    else
                    {
                        Console.WriteLine("No data added");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public void UpdateExistingContatc(AddressBookModel addressBookModel,String firstName)
        {
            try
            {
                using (this.connection)
                {
                    string query = @"Update AddressBookTable Set LastName=@LastName,Address=@Address,City=@City,
                    State=@State,Zip=@Zip,PhoneNo=@PhoneNo,Email=@Email,AddressBookName=@AddressBookName,
                    AddressBookType=@AddressBookType  where Firstname=@FirstName";

                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    
                    sqlCommand.Parameters.AddWithValue("@FirstName", addressBookModel.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", addressBookModel.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", addressBookModel.Address);
                    sqlCommand.Parameters.AddWithValue("@City", addressBookModel.City);
                    sqlCommand.Parameters.AddWithValue("@State", addressBookModel.State);
                    sqlCommand.Parameters.AddWithValue("@Zip", addressBookModel.Zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNo", addressBookModel.PhoneNo);
                    sqlCommand.Parameters.AddWithValue("@Email", addressBookModel.Email);
                    sqlCommand.Parameters.AddWithValue("@AddressBookName", addressBookModel.AddressBookName);
                    sqlCommand.Parameters.AddWithValue("@AddressBookType", addressBookModel.AddressBookType);

                    var count=sqlCommand.ExecuteNonQuery();
                    this.connection.Close();
                    if (count != 0)
                    {
                        Console.WriteLine("Contact Updated successfully");
                    }
                    else
                    {
                        Console.WriteLine("No data added");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
