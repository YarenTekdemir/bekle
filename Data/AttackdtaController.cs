using bekle.Models;
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
        // GET: Attack
        String connectionString = @"Data Source=LAPTOP-4KLGVEG1\SQLEXPRESS;Initial Catalog=WEB;Integrated Security=True ";



        internal bool AddTest(Attackaccount attack, UserAccount account)
        {
            string insertString = "INSERT INTO USED_TEST VALUES (@userid,@test_id,@test_device,@testdesc)";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))

                {

                    SqlCommand command = new SqlCommand(insertString, connection);

                    command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 50).Value = attack.user_id;
                    command.Parameters.Add("@test_id", System.Data.SqlDbType.VarChar, 50).Value = attack.test_id;
                    command.Parameters.Add("@test_device", System.Data.SqlDbType.VarChar, 50).Value = attack.test_device;
                    command.Parameters.Add("@test_desc", System.Data.SqlDbType.VarChar, 50).Value = attack.test_desc;

                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }

        }

    }

}
