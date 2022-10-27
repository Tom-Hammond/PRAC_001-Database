using System;
using System.IO; 
using MySql.Data;
using MySql.Data.MySqlClient;
using PRAC_001_Database;

namespace Database001_PRAC
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.ConnectToDatabase();
            MainMenu();
            ReturnToMenuOrExit();

        }

        static void MainMenu()
        {
            int userChoice = 0;
            Console.Clear();
            Console.WriteLine("Welcome to the database system");
            Console.WriteLine("You are connected to the " + Database.conn.Database + " database\n");
            Console.WriteLine("Please select what you would like to do");
            Console.WriteLine("1: Veiw table");
            Console.WriteLine("2: Edit record in table");
            Console.WriteLine("3: Run a query");
            Console.WriteLine("4: Add a record");
            Console.WriteLine("5: Exit");
            userChoice = GetUserInput(1, 5);

            switch (userChoice)
            {
                case 1:
                    Database.DisplayTableData();
                    break; 

                case 2:
                    Database.EditRecord();
                    break;

                case 3:
                    MainMenu();
                    break;

                case 4:
                    MainMenu();
                    break;
                case 5:
                    Environment.Exit(1);
                    break;

            }



        }

        public static void ReturnToMenuOrExit()
        {
            int userChoice = 0;

            while (userChoice == 0)
            {
                Console.WriteLine("\n\nDo you want to perfrom another action or exit the program");
                Console.WriteLine("1: Return to menu");
                Console.WriteLine("2: Exit Program");
                userChoice = GetUserInput(1, 2); 

                switch (userChoice)
                {
                    case 1:
                        MainMenu();
                        break;

                    case 2:
                        Environment.Exit(1);
                        break;
                   
                }
            }
           
        }


        static public int GetUserInput(int min, int max)
        {
            string userString = null;
            int userChoiceNumber = 0;
            bool isChoiceVaild = false;
            do
            {
                Console.WriteLine("Enter a value between {0} and {1}", min, max);

                try
                {

                    userString = Console.ReadLine();
                    userChoiceNumber = int.Parse(userString);
                    
                        if ((userChoiceNumber % 1) != 0)
                        {
                            isChoiceVaild = false;
                            Console.WriteLine("{0} is not a whole number", userChoiceNumber);
                            continue;
                        }

                    





                    if (userChoiceNumber >= min && userChoiceNumber <= max)
                    {
                        isChoiceVaild = true;
                    }
                    else
                    {
                        Console.WriteLine("{0} is not between {1} and {2}", userChoiceNumber, min, max);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("{0} is not a number", userString);
                    isChoiceVaild = false;
                    continue; 
                }

            } while (isChoiceVaild == false);
            
            return userChoiceNumber;

        }


    }

}
