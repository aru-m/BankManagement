using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Roles
{
    internal class Employe
    {
        public static void run()
        {
            while (true)
            {
                Console.WriteLine("for Employee");
                Console.WriteLine("0. Register new Customer");
                Console.WriteLine("1. To create account of new bank customer");
                Console.WriteLine("2. View customer details");
                Console.WriteLine("3. Update customer details");
                Console.WriteLine("4. view transaction details of particular customer");
                Console.WriteLine("5. View all transactions of today ");
                Console.WriteLine("6. Logout");
                Console.WriteLine("\t");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("enter your choice to perform operation");
                Console.ForegroundColor = ConsoleColor.White;
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("\t");
                switch (n)
                {
                    case 0:
                        Operations.register_cust();
                        break;
                    case 1:
                        Operations.create_account();
                        break;
                    case 2:
                        Operations.view_customer();
                        break;
                    case 3:
                        Operations.update_customer();
                        break;
                    case 4:
                        Operations.view_trans_for_acc();
                        break;
                    case 5:
                       
                        Operations.Report();
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thankyou for using XYZ Bank");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;

                }
            }
        }
    }

}
