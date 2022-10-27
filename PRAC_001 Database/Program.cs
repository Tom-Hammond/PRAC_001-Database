using System;
using System.IO; 
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Database001_PRAC
{
    class Program
    {
        static void Main(string[] args)
        {

            string connStr = "server=localhost;user=root;database=users;port=3306;password=L3tM31n";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL--- world database");
                conn.Open();
                // Perform database operations 
                string sql = "SELECT LoginID, UserID FROM accounts";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();

                Console.WriteLine("Done the job");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close(); // close the connection 

        }
    }

}
