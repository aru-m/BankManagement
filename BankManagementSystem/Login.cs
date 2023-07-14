using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    internal class Login
    {
        public static void login()
        {
            Console.Write("Enter your id ");
            int id=int.Parse(Console.ReadLine());

            Console.Write("Enter your password: ");
            string password = GetPasswordInput();

            LoggedinUserDetails.LoggedinUserID = id;
            LoggedinUserDetails.LoggedinUserType = userType(id,password);
          
        }
        static string GetPasswordInput()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                // Ignore any key that is not a visible character
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter && !char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                //enables to delete the last key and move cursor one space back
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }

        public static string userType(int id,string pass)
        {
            string userRole = "";
            string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            string q = "Select Password from UserDetails Where user_ID=" + id;
            SqlCommand cmd1 = new SqlCommand(q, con);
            cmd1.Parameters.AddWithValue("@id", id);
            string pswd = Convert.ToString(cmd1.ExecuteScalar());
            con.Close(); ;

            if (pass.Equals(pswd))
            {
                con.Open();
                string query = "SELECT Role FROM UserDetails where user_ID=" + id;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                var returnValue = cmd.ExecuteScalar();
                if (returnValue != null)
                    userRole = returnValue.ToString();
                con.Close();
                return userRole;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password didnot match");
                Console.ForegroundColor= ConsoleColor.White;
                return "";
            }
        }
    }
}
