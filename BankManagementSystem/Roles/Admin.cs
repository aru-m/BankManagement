using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Roles
{
    internal class Admin
    {
        public static void run()
        {
            while (true)
            {
                Console.WriteLine("Please choose one of the following options");

                Console.WriteLine("1. Register new Employee");
                Console.WriteLine("2. Create new Branch");
                Console.WriteLine("3. Update Employee details");
                Console.WriteLine("4. View Branch details");
                Console.WriteLine("5. View Customer details");
                Console.WriteLine("6. View Employee details");
                Console.WriteLine("7. Logout");
                Console.WriteLine("\t");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("enter your choice to perform operation");
                Console.ForegroundColor = ConsoleColor.White;
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("\t");

                switch (n)
                {


                    case 1:
                        Operations.register_employee();
                        break;
                    case 2:
                        Operations.create_branch();
                        break;
                    case 3:
                        Operations.update_Employee();
                        break;
                    case 4:
                        Operations.view_branch();
                        break;
                    case 5:
                        Operations.view_customer();
                        break;
                    case 6:
                        Operations.view_employee();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thankyou for using XYZ Bank");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                }
            }
        }
    }
}
