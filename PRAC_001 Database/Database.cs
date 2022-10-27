using System;
using System.Collections.Generic;
using System.Text;
using Database001_PRAC;
using MySql.Data;
using MySql.Data.MySqlClient; 

namespace PRAC_001_Database
{
    public class Database
    {
        public static string connStr = "server=localhost;user=root;database=users;port=3306;password=HullUni2022";
        public static MySqlConnection conn = new MySqlConnection(connStr);


        public static void ConnectToDatabase()
        {
           try
           {
                Console.WriteLine("Connecting to MySQL --- " + conn.Database + " database");
                conn.Open();
           }

           catch (Exception ex)
           {
                Console.WriteLine(ex.ToString());
           }
        }

        public static void DisplayTableData()
        {
                int userChoice = 0;
                string sql = null;


            Console.Clear();
                Console.WriteLine("The following tables are in the database");
                Console.WriteLine("1: Accounts");
                Console.WriteLine("2: Location");
                Console.WriteLine("3: User Details");
                Console.WriteLine("Please selct a value between 1 and 3");
                userChoice = Program.GetUserInput(1, 3);

                

            try
            {


                switch (userChoice)
                {
                    case 1:
                        sql = "SELECT LoginID, UserID FROM accounts";
                        MySqlCommand accountsCMD = new MySqlCommand(sql, conn);
                        MySqlDataReader accounts = accountsCMD.ExecuteReader();
                        Console.WriteLine("LoginID  ||  UserID");
                        Console.WriteLine("====================");
                        while (accounts.Read())
                        {
                            Console.WriteLine(accounts[0] + " || " + accounts[1]);
                        }
                        accounts.Close();
                        break;

                    case 2:
                        sql = "SELECT ID, Location";
                        MySqlCommand locationCMD = new MySqlCommand(sql, conn);
                        MySqlDataReader location = locationCMD.ExecuteReader();
                        Console.WriteLine("ID  ||  Location  ");
                        Console.WriteLine("==================");
                        while (location.Read())
                        {
                            Console.WriteLine(location[0] + " || " + location[1]);
                        }
                        location.Close();

                        break;

                    case 3:
                        sql = "SELECT ID, Surname, Forname, Title, Phone, Email FROM userdetails";
                        MySqlCommand userdetailsCMD = new MySqlCommand(sql, conn);
                        MySqlDataReader userdetails = userdetailsCMD.ExecuteReader();
                        Console.WriteLine("ID  ||  Surname  ||  Forname  ||  Title  ||  Position ||  Phone  ||  Email");
                        Console.WriteLine("===========================================================================");
                        while (userdetails.Read())
                        {
                            Console.WriteLine(userdetails[0] + " || " + userdetails[1] + " || " + userdetails[2] + " || " + userdetails[3] + " || " + userdetails[4] + " || " + userdetails[5]);
                        }
                        userdetails.Close();

                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

          
        }

        public static void EditRecord()
        {
            int userChoice = 0;
            string sql = null;


            Console.Clear();
            Console.WriteLine("The following tables in the database and can be edited");
            Console.WriteLine("1: Location");
            Console.WriteLine("2: User Details");
            Console.WriteLine("Please selct a value between 1 and 2");
            userChoice = Program.GetUserInput(1, 2);

            int index = 1;
            int count = 0;
            int recordToUpdate = 0;
            string newDataText = "";

            try
            {
                switch (userChoice)
                {
                    

                    case 1:
                        List<string> ID = new List<string>();
                        List<string> Location = new List<string>();

                        index = 1;
                        count = 0;
                        recordToUpdate = 0;
                        newDataText = "";
                        

                        sql = "SELECT ID, Location";
                        MySqlCommand locationCMD = new MySqlCommand(sql, conn);
                        MySqlDataReader location = locationCMD.ExecuteReader();
                        Console.WriteLine("ID  ||  Location  ");
                        Console.WriteLine("==================");
                        while (location.Read())
                        {
                            Console.WriteLine(index + ": " + location[0] + " || " + location[1]);
                            ID.Add(location[0].ToString());
                            Location.Add(location[1].ToString());
                            count++; 
                        }

                        Console.WriteLine("Please choose a record to update the record");
                        recordToUpdate = Program.GetUserInput(1, count) - 1;

                        Console.WriteLine("ID is not updateable due to key settings");
                        Console.WriteLine("You can chnage the location feild");
                        Console.WriteLine("Please enter new data for the location feild");
                        newDataText = Console.ReadLine();

                        
                        sql = "INSERT INTO Location (ID, Location) VALUES ('"+ ID[recordToUpdate] + "', '" + newDataText + "')";
                        locationCMD.ExecuteReader(); 
                        location.Close();

                        break;

                    case 2:
                        userChoice = 0;
                        index = 1;
                        count = 0;
                        recordToUpdate = 0;
                        newDataText = "";
                        List<string> userID = new List<string>();
                        List<string> surname = new List<string>();
                        List<string> forname = new List<string>();
                        List<string> title = new List<string>();
                        List<string> Position = new List<string>();
                        List<string> Phone = new List<string>();
                        List<string> Email = new List<string>();

                        sql = "SELECT ID, Surname, Forname, Title, Position, Phone, Email FROM userdetails";
                        MySqlCommand userdetailsCMD = new MySqlCommand(sql, conn);
                        MySqlDataReader userdetails = userdetailsCMD.ExecuteReader();
                        Console.WriteLine("ID  ||  Surname  ||  Forname  ||  Title  ||  Position ||  Phone  ||  Email");
                        Console.WriteLine("===========================================================================");
                        while (userdetails.Read())
                        {
                            Console.WriteLine(index + ": " + userdetails[0] + " || " + userdetails[1] + " || " + userdetails[2] + " || " + userdetails[3] + " || " + userdetails[4] + " || " + userdetails[5]);
                            userID.Add(userdetails[0].ToString());
                            surname.Add(userdetails[1].ToString());
                            forname.Add(userdetails[2].ToString());
                            title.Add(userdetails[3].ToString());
                            Position.Add(userdetails[4].ToString());
                            Phone.Add(userdetails[5].ToString());
                            Email.Add(userdetails[6].ToString());
                            index++;
                        }

                        sql = "";

                        Console.WriteLine("Please choose a record to update the record");
                        recordToUpdate = Program.GetUserInput(1, index - 1) - 1;


                        Console.WriteLine("\n\nWhich field would you like to update");
                        Console.WriteLine("ID is not updateable due to key settings");
                        Console.WriteLine("1: Surname");
                        Console.WriteLine("2: Forname");
                        Console.WriteLine("3: Title");
                        Console.WriteLine("4: Position");
                        Console.WriteLine("5: Phone Number");
                        Console.WriteLine("6: Email");
                        userChoice = Program.GetUserInput(1, 6);

                        switch (userChoice)
                        {
                            case 1:
                                Console.WriteLine("Please enter a new Surname");
                                newDataText = Console.ReadLine();
                                sql = "INSERT INTO userdetails (Surname) VALUES ('" + newDataText + "')";
                                userdetailsCMD.CommandText = sql; 
                                break;

                            case 2:
                                Console.WriteLine("Please enter a new Forname");
                                newDataText = Console.ReadLine();
                                sql = "INSERT INTO userdetails (Forname) VALUES ('" + newDataText + "')";
                                userdetailsCMD.ExecuteReader();
                                break;

                            case 3:
                                Console.WriteLine("Please enter a new Title");
                                newDataText = Console.ReadLine();
                                sql = "INSERT INTO userdetails (Forname) VALUES ('" + newDataText + "')";
                                userdetailsCMD.ExecuteReader();
                                break;

                            case 4:
                                Console.WriteLine("Please enter a new Position");
                                newDataText = Console.ReadLine();
                                sql = "INSERT INTO userdetails (Forname) VALUES ('" + newDataText + "')";
                                userdetailsCMD.ExecuteReader();
                                break;

                            case 5:
                                int phoneNum = 0;
                                Console.WriteLine("Please enter a new Phone Number");
                                while (phoneNum == 0)
                                {
                                    try
                                    {
                                        phoneNum = int.Parse(Console.ReadLine());
                                        if (phoneNum >11 || phoneNum <=0)
                                        {
                                            phoneNum = 0;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        phoneNum = 0;
                                    }
                                    
                                }
                                newDataText = phoneNum.ToString();
                                sql = "INSERT INTO userdetails (Phone) VALUES ('" + newDataText + "')";
                                userdetailsCMD.ExecuteReader();
                                break;

                            case 6:
                                Console.WriteLine("Please enter a new Email");
                                newDataText = Console.ReadLine();
                                

                                userdetailsCMD.CommandText = "UPDATE Student SET Address = @add";
                                userdetailsCMD.Parameters.AddWithValue("@add", newDataText);
                    
                                break;
                        
                        }



                        userdetails.Close();

                        break;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error has occored");
                Program.ReturnToMenuOrExit();
            }

        }

        public static void RunQuery()
        {


        }

        public static void AddRecord()
        {

        }

    }
}
