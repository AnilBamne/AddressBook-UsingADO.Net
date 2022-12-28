using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Loader;
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

        /// <summary>
        /// Ability to edit existing contact
        /// </summary>
        /// <param name="addressBookModel"></param>
        /// <param name="firstName"></param>
        public void EditExistingContatc(AddressBookModel addressBookModel,String firstName)
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

        /// <summary>
        /// Ability to delete existing contact by persons name
        /// </summary>
        /// <param name="addressBookModel"> object of AddressBookModel</param>
        public void DeleteExistingContatc(AddressBookModel addressBookModel)
        {
            try
            {
                using (this.connection)
                {
                    string query = @"Delete From AddressBookTable where Firstname=@FirstName";

                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    sqlCommand.Parameters.AddWithValue("@FirstName", addressBookModel.FirstName);

                    var count = sqlCommand.ExecuteNonQuery();
                    this.connection.Close();
                    if (count != 0)
                    {
                        Console.WriteLine("Contact deleted successfully");
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

        /// <summary>
        /// Ability to show all data
        /// </summary>
        /// <param name="addressBookModel"> object of AddressBookModel</param>
        public void ShowAllDataInDataBase()
        {
            try
            {
                AddressBookModel addressBookModel  =new AddressBookModel();
                using (this.connection)
                {
                    string query = @"Select * From AddressBookTable;";

                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader=sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while(sqlDataReader.Read())
                        {
                            addressBookModel.FirstName=sqlDataReader.GetString(0);
                            addressBookModel.LastName=sqlDataReader.GetString(1);
                            addressBookModel.Address=sqlDataReader.GetString(2);
                            addressBookModel.City=sqlDataReader.GetString(3);
                            addressBookModel.State = sqlDataReader.GetString(4);
                            addressBookModel.Zip = sqlDataReader.GetInt32(5);
                            addressBookModel.PhoneNo = sqlDataReader.GetInt32(6);
                            addressBookModel.Email = sqlDataReader.GetString(7);
                            addressBookModel.AddressBookType = sqlDataReader.GetString(8);
                            addressBookModel.AddressBookName = sqlDataReader.GetString(9);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", addressBookModel.FirstName,addressBookModel.LastName,addressBookModel.Address,addressBookModel.City,addressBookModel.State,addressBookModel.Zip,addressBookModel.PhoneNo,addressBookModel.Email,addressBookModel.AddressBookName,addressBookModel.AddressBookType);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
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
