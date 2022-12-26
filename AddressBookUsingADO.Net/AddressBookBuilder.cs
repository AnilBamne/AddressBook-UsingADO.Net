using System;
using System.Collections.Generic;
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
    }
}
