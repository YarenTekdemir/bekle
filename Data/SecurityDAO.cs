using bekle.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace bekle.Services.Data
{
    public class SecurityDAO
    {
        // String connectionString = @"Data Source=(localdb)\\{MSSQLLocalDB;Database = WEB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        String connectionString = @"Data Source=LAPTOP-4KLGVEG1\SQLEXPRESS;Initial Catalog=WEB;Integrated Security=True ";


        internal bool FindbyUser(UserAccount user)
        {
            bool success = false    ;
            String queryString = "SELECT * FROM Users WHERE username = @Username AND usersurname = @Usersurname  AND password = @Password AND email = @Email  ";
            
            using (SqlConnection connection = new SqlConnection(connectionString) )
            {
           SqlCommand command = new SqlCommand(queryString, connection);
      command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
      command.Parameters.Add("@Usersurname", System.Data.SqlDbType.VarChar, 50).Value = user.Usersurname;
      command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
      command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 50).Value = user.Email;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    { 
                        success = true;
                    }
                    else
                    {
                        success = false; 
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return success;


        }

        internal bool AddUser(UserAccount account)
        {
            string queryString = "INSERT INTO USERS VALUES (@Id,@username,@usersurname,@password,@email)";
            string getIDCount = "SELECT COUNT(Id) FROM USERS";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand getId = new SqlCommand(getIDCount, connection);
            

                    SqlCommand command = new SqlCommand(queryString, connection);
               
                    connection.Open();

                    String ID = getId.ExecuteScalar().ToString();


                    command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 50).Value = ID;
                    command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 50).Value = account.Username;
                    command.Parameters.Add("@usersurname", System.Data.SqlDbType.VarChar, 50).Value = account.Usersurname;
                    command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = account.Password;
                    command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 50).Value = account.Email;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }

                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    return false;
                }
            }

        }



    }
}