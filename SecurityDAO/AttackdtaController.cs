using bekle.Models;
using bekle.Services.Bussines;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bekle.Services.Data
{

    public class AttackdtaController : Controller

    {
        static string userName = Environment.UserName;

        // GET: Attack
        String connectionString = @"Data Source=LAPTOP-4KLGVEG1\SQLEXPRESS;Initial Catalog=WEB;Integrated Security=True ";



        public Attackaccount getAttack(string attackName)
        {
            Attackaccount attack = new Attackaccount();
            string getAttackData = "SELECT * FROM TESTS WHERE test_id = @testID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(getAttackData, connection);
                command.Parameters.Add("@testID", System.Data.SqlDbType.VarChar, 50).Value = attackName;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    attack.test_id = attackName;
                    attack.test_location = reader["test_location"].ToString();
                }
                reader.Close();
                connection.Close();
            }
            return attack;      
        }



        public void insertTest(Attackaccount attack, string result)
        {
            SecurityService service = new SecurityService();
            UserAccount account = service.getActiveUser();

            string insertString = "INSERT INTO USED_TESTS VALUES (@testID,@userID,@test_device,@test_results)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand command = new SqlCommand(insertString, connection);
                    command.Parameters.Add("@testID", System.Data.SqlDbType.VarChar, 50).Value = attack.test_id;
                    command.Parameters.Add("@userID", System.Data.SqlDbType.VarChar, 50).Value = account.ID;
                    command.Parameters.Add("@test_device", System.Data.SqlDbType.VarChar, 50).Value = userName;
                    command.Parameters.Add("@test_results", System.Data.SqlDbType.VarChar, 8000).Value = result;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }




    }


    }


