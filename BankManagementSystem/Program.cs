using BankManagementSystem;
using BankManagementSystem.Roles;
using System;

class Program
{
    public static void Main(string[] args)
    {

        // Welcome();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\t\t\t\t\t Welcome to XYZ Bank");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Please login to continue.");
        Login.login();
        Console.ForegroundColor= ConsoleColor.White;
        Console.WriteLine("\t");

        int logid = LoggedinUserDetails.LoggedinUserID;
        string roleType = LoggedinUserDetails.LoggedinUserType;

        if (roleType == "Admin")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Admin role authenticated. Access Granted");
            Console.ForegroundColor = ConsoleColor.White;
            Admin.run();
        }
        else if (roleType == "Employee")
            {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee role authenticated. Access Granted");
            Console.ForegroundColor = ConsoleColor.White;
            Employe.run();
            }
        else if (roleType == "Customer")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Customer role authenticated. Access Granted");
            Console.ForegroundColor = ConsoleColor.White;
            Customer.run();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unknown role authenticated.Access denied");
            Console.ForegroundColor = ConsoleColor.White;
        }
     


    }
}