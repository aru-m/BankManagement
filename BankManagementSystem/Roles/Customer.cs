using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Roles
{
    internal class Customer
    {
        public static void run()
        {

            while (true)
            {
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("1. view balance");
                Console.WriteLine("2. deposit money");
                Console.WriteLine("3. withdraw money");
                Console.WriteLine("4. view transaction details");
                Console.WriteLine("5. Logout");
                Console.WriteLine("\t");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("enter your choice to perform operation");
                Console.ForegroundColor = ConsoleColor.White;
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("\t");
                switch (n)
                {
                    case 1:
                        int ans = Operations.view_balance();
                        Console.WriteLine(ans);
                        break;
                    case 2:
                        Operations.deposit_money();
                        break;
                    case 3:
                        Operations.withdraw_money();
                        break;
                    case 4:
                        Operations.view_transaction();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thankyou for using XYZ Bank");
                        Console.ResetColor();
                        //Program.Welcome();
                        return;
                        //break;

                }
            }

        }
    }
}
