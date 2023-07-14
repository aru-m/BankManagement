using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace BankManagementSystem
{
    public class Operations
    {
        //admin roles

        public static void register_employee()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter city");
            string city = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Console.WriteLine("enter role");
            string role = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            string phone_no = Console.ReadLine();
            Console.WriteLine("enter password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter branch id");
            int br_id = int.Parse(Console.ReadLine());
            string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection con = new SqlConnection(cs);
            string query = "INSERT INTO UserDetails (Name,Phone_no,City,Password,Email,Role) VALUES(@name, @phone_no, @city,@password,@email,@role)";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@phone_no", phone_no);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@role", role);

            cmd.ExecuteNonQuery();
            //to get the current id of registered employee
            string query2 = " SELECT TOP 1 [user_ID] FROM UserDetails ORDER BY [user_ID] DESC";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            int userid = Convert.ToInt32(cmd2.ExecuteScalar());
            con.Close();

            DateTime createdOn = DateTime.Now;

            con.Open();

            string queryy = "Insert into Employee (Employee_ID,Branch_ID,Created_by,Created_on) VALUES(@userid,@br_id,@LoggedinUserID,@createdOn)";
            SqlCommand cmdd = new SqlCommand(queryy, con);
            cmdd.Parameters.AddWithValue("@userid", userid);
            cmdd.Parameters.AddWithValue("@createdOn", createdOn);
            cmdd.Parameters.AddWithValue("@br_id", br_id);
            cmdd.Parameters.AddWithValue("@LoggedinUserID", LoggedinUserDetails.LoggedinUserID);
            cmdd.ExecuteNonQuery();

            con.Close();
            Console.WriteLine("--------------------------------------------------");
        }
        public static void create_branch()
        {
            Console.WriteLine("Enter branch name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter branch city");
            string city = Console.ReadLine();

            string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection con = new SqlConnection(cs);
            string query = "INSERT INTO Branch (Branch_Name,Branch_City) VALUES(@name,@city)";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.ExecuteNonQuery();

            con.Close();
            Console.WriteLine("--------------------------------------------------");
        }

        public static void update_Employee()
        {

            int idd;
            Console.WriteLine("enter the id you want to update data for");
            idd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter new branch id");
            int br_id = Convert.ToInt32(Console.ReadLine());

            //DataSet ds = DbConnection.runUserQuery("UPDATE Branch SET Branch_Name = '" + name + "', Branch_City = '" + city + "' WHERE Branch_ID = " + idd);
            // Console.WriteLine("--------------------------------------------------");


            DateTime updatedOn = DateTime.Now;
            string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection con = new SqlConnection(cs);
            //string query = "UPDATE UserDetails SET Name = @name,Phone_no=@phone_no,City = @city,Email =@email,Role=@role,Password-@password WHERE user_ID = " + idd;
            string query = "UPDATE Employee SET Branch_ID=@br_id,Updated_by=@LoggedinUserID,Updated_on=@updatedOn WHERE Employee_ID=" + idd;
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@idd", idd);
            cmd.Parameters.AddWithValue("@br_id", br_id);
            cmd.Parameters.AddWithValue("@LoggedinUserID", LoggedinUserDetails.LoggedinUserID);
            cmd.Parameters.AddWithValue("@updatedOn", updatedOn);

            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("--------------------------------------------------");
        }

        public static void view_branch()
        {
            DataSet ds = DbConnection.runUserQuery("SELECT Branch_ID,Branch_Name,Branch_City FROM Branch");
            Console.WriteLine("Branch Details are:-->");
           

            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            string data = String.Format("{0,-20} {1,-15} {2,-15} ", "|Branch_ID", "|Branch_Name", "|Branch_City", "|");
            Console.WriteLine(data);
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow db in table.Rows)
                {
                    data = String.Format("{0,-20} {1,-10} {2,-10} ", "|" + db[0], "|" + db[1], "|" + db[2], "|");
                    Console.WriteLine(data);
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                }
            }
        }


        public static void view_employee()
        {
            DataSet ds = DbConnection.runUserQuery("SELECT Name,Phone_no,City,Password,Email,Role FROM UserDetails WHERE Role='Employee'");
            Console.WriteLine("Employee details are:-->");
            
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            string data = String.Format("{0,-20} {1,-10} {2,-10} {3,-20} {4,-20} {5,-10} {6}", "|Name", "|Phone No", "|City", "|Password", "|Email", "|Role", "|");
            Console.WriteLine(data);
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow db in table.Rows)
                {
                    data = String.Format("{0,-20} {1,-10} {2,-10} {3,-20} {4,-20} {5,-10} {6}", "|" + db[0], "|" + db[1], "|" + db[2], "|" + db[3], "|" + db[4], "|" + db[5], "|");
                    Console.WriteLine(data);
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                }
            }

        }




        //employee role

        public static void register_cust()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter city");
            string city = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Console.WriteLine("enter role");
            string role = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            string phone_no = Console.ReadLine();
            Console.WriteLine("enter password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter pan number");
            string pan = Console.ReadLine();

            string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection con = new SqlConnection(cs);
            string query = "INSERT INTO UserDetails (Name,Phone_no,City,Password,Email,Role) VALUES(@name, @phone_no, @city,@password,@email,@role)";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@phone_no", phone_no);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@role", role);

            cmd.ExecuteNonQuery();

            string query2 = " SELECT TOP 1 [user_ID] FROM UserDetails ORDER BY [user_ID] DESC";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            int userid = Convert.ToInt32(cmd2.ExecuteScalar());
            con.Close();

            DateTime createdOn = DateTime.Now;
            con.Open();
            string queryy = "Insert into Customer (Customer_ID,Created_by,Created_on,Pan_no) VALUES(@userid,@LoggedinUserID,@createdOn,@pan)";
            SqlCommand cmdd = new SqlCommand(queryy, con);
            cmdd.Parameters.AddWithValue("@userid", userid);
            cmdd.Parameters.AddWithValue("@pan", pan);
            cmdd.Parameters.AddWithValue("@createdOn", createdOn);
            cmdd.Parameters.AddWithValue("@LoggedinUserID", LoggedinUserDetails.LoggedinUserID);
            cmdd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("--------------------------------------------------");

        }
        public static void create_account()
        {
            Console.WriteLine("Enter the id you want to create account for");
            int idd = int.Parse(Console.ReadLine());
            string quer = "Select count(*) from UserDetails where user_ID=" + idd;
            string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand cmdd = new SqlCommand(quer, conn);
            cmdd.Parameters.AddWithValue("@idd", idd);
            int count = (int)cmdd.ExecuteScalar();
            conn.Close();
            if (count > 0)
            {
                Console.WriteLine("Enter account type");
                string type = Console.ReadLine();
                Console.WriteLine("Enter balance");
                double balance = Convert.ToDouble(Console.ReadLine());
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string brquery = "Select Branch_ID from Employee where Employee_ID=" + LoggedinUserDetails.LoggedinUserID;
                SqlCommand cmd2 = new SqlCommand(brquery, con);
                int branchid = Convert.ToInt32(cmd2.ExecuteScalar());
                DateTime createdOn = DateTime.Now;

                string query = "INSERT INTO Account (AccountType,Balance,Branch_ID,User_ID,Created_by,Created_on) VALUES(@type,@balance,@branchid,@idd,@LoggedinUserID,@createdOn)";
                SqlCommand cmd = new SqlCommand(query, con);

                //Pass values to Parameters
                cmd.Parameters.AddWithValue("@idd", idd);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@branchid", branchid);
                cmd.Parameters.AddWithValue("@balance", balance);
                cmd.Parameters.AddWithValue("@LoggedinUserID", LoggedinUserDetails.LoggedinUserID);
                cmd.Parameters.AddWithValue("@createdOn", createdOn);

                cmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("--------------------------------------------------");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No customer exists with this id, first create new customer");
                Console.ResetColor();
                Console.WriteLine("--------------------------------------------------");
            }
        }

        public static void view_customer()
        {

            DataSet ds = DbConnection.runUserQuery("SELECT Name,Phone_no,City,Password,Email,Role FROM UserDetails WHERE Role='Customer' ");
            Console.WriteLine("Customer Details are:-->");

            //foreach (DataTable table in ds.Tables)
            //{
            //    Console.WriteLine("Name\t"+ "Phone_no\t"+"City\t"+"Password\t"+"Email\t"+"Role");
            //    foreach (DataRow dr in table.Rows)
            //    {

            //        Console.WriteLine("{0} {1} {2} {3} {4} {5} ", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);

            //    }
            //}
            //Console.WriteLine("--------------------------------------------------");



            //    //display column header
            //    DataTable table = ds.Tables[0];

            //    foreach(DataColumn col in table.Columns)
            //    {
            //        Console.Write(col.ColumnName +"\t");               
            //    }
            //    Console.WriteLine();
            //    //display data
            //    foreach (DataRow row in table.Rows)
            //    {
            //        foreach(DataColumn column in table.Columns)
            //        {
            //            Console.Write(row[column] +"\t");
            //        }
            //        Console.WriteLine() ;
            //    }
            //}

            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            string data = String.Format("{0,-20} {1,-15} {2,-15} {3,-20} {4,-20} {5,-10} {6}", "|Name", "|Phone No", "|City", "|Password", "|Email", "|Role", "|");
            Console.WriteLine(data);
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow db in table.Rows)
                {
                    data = String.Format("{0,-20} {1,-10} {2,-10} {3,-20} {4,-20} {5,-10} {6}", "|" + db[0], "|" + db[1], "|" + db[2], "|" + db[3], "|" + db[4], "|" + db[5], "|");
                    Console.WriteLine(data);
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                }
            }
        }

        public static void update_customer()
        {
            Console.WriteLine("enter id you want to update data for");
            int idd = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new pan number");
            string pan = Console.ReadLine();

            DateTime updatedOn = DateTime.Now;
            string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection con = new SqlConnection(cs);
            //string query = "UPDATE UserDetails SET Name = @name,Phone_no=@phone_no,City = @city,Email =@email,Role=@role,Password-@password WHERE user_ID = " + idd;
            string query = "UPDATE Customer SET Pan_no=@pan,Updated_by=@LoggedinUserID,Updated_on=@updatedOn WHERE Customer_ID=" + idd;
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@idd", idd);
            cmd.Parameters.AddWithValue("@pan", pan);
            cmd.Parameters.AddWithValue("@LoggedinUserID", LoggedinUserDetails.LoggedinUserID);
            cmd.Parameters.AddWithValue("@updatedOn", updatedOn);

            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("--------------------------------------------------");
        }

        public static void view_trans_for_acc()
        {
            Console.WriteLine("enter account number you want to view transaction details for");
            int acc = Convert.ToInt32(Console.ReadLine());
            DataSet ds = DbConnection.runUserQuery("SELECT Transaction_ID,AccountNumber,Transaction_type,Transaction_amount,Created_by,Created_on From [Transaction] where AccountNumber= " + acc);


            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            string data = String.Format("{0,-20} {1,-15} {2,-20} {3,-20} {4,-20} {5,-15} {6}", "|Transaction_ID", "|AccountNumber", "|Transaction_type", "|Transaction_amount", "|Created_by", "|Created_on", "|");
            Console.WriteLine(data);
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow db in table.Rows)
                {
                    data = String.Format("{0,-20} {1,-15} {2,-20} {3,-20} {4,-20} {5,-15} {6}", "|" + db[0], "|" + db[1], "|" + db[2], "|" + db[3], "|" + db[4], "|" + db[5], "|");
                    Console.WriteLine(data);
                    Console.WriteLine("--------------------------------------------------------------------------------------------------");
                }
            }
        }

        public static void Report()
        {
            //currConsole.ReadLine();
            string currentdate = DateTime.Now.ToString("yyyy-MM-dd");
            //string q = "Select * from [Transaction] Where Created_on='" + currentdate+"'";
            string q= " Select t.Transaction_ID,t.AccountNumber,u.[Name],t.Transaction_type,t.Transaction_amount,t.Created_by,t.Created_on from[Transaction] t  inner join Account a on t.AccountNumber=a.AccountNumber  inner join UserDetails u on u.[user_ID]=a.[User_ID]  where t.Created_on='" + currentdate + "'";
            DataSet ds = DbConnection.runUserQuery(q);
           

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
            string data = String.Format("{0,-20} {1,-15} {2,-15} {3,-20} {4,-20} {5,-15} {6}", "|Transaction_ID", "|AccountNumber", "|Name", "|Transaction_type", "|Transaction_amount", "|Created_by", "|Created_on","|");
            Console.WriteLine(data);
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow db in table.Rows)
                {
                    data = String.Format("{0,-20} {1,-15} {2,-15} {3,-20} {4,-20} {5,-15} {6,-20} {7}", "|" + db[0], "|" + db[1], "|" + db[2], "|" + db[3], "|" + db[4], "|" + db[5], "|"+ db[6] ,"|");
                    Console.WriteLine(data);
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
                }
            }

        }


        //customer role

        public static int view_balance()
        {
            Console.WriteLine("Enter your Account number");
            int acc = int.Parse(Console.ReadLine());

            string statusReturned = "";
            string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "Select Balance from Account where AccountNumber=" + acc;
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@amt", acc);
            cmd.ExecuteNonQuery();
            var returnValue = cmd.ExecuteScalar();
            if (returnValue != null)
                statusReturned = returnValue.ToString();
            con.Close();
            //Console.WriteLine(int.Parse(statusReturned));

            return int.Parse(statusReturned);
            Console.WriteLine("--------------------------------------------------");

        }

        public static void deposit_money()
        {
            Console.WriteLine("Enter your account number");
            int acc = int.Parse(Console.ReadLine());
            LoggedinUserDetails.trans_account = acc;
            Console.WriteLine("enter the amount you want to deposit");
            int amt = Convert.ToInt32(Console.ReadLine());

            LoggedinUserDetails.trans_amount = amt;
            LoggedinUserDetails.trans_type = "deposit";

            string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            DateTime createdOn = DateTime.Now;
            //DateOnly createdOn=DateOnly.FromDateTime(DateTime.Now);

            string query = "INSERT INTO [Transaction] (AccountNumber,Transaction_type,Transaction_amount,Created_by,Created_on) VALUES(@trans_account,@trans_type,@trans_amount,@LoggedinUserID,@createdOn)";
            SqlCommand cmd = new SqlCommand(query, con);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@createdOn", createdOn);
            cmd.Parameters.AddWithValue("@LoggedinUserID", LoggedinUserDetails.LoggedinUserID);
            cmd.Parameters.AddWithValue("@trans_type", LoggedinUserDetails.trans_type);
            cmd.Parameters.AddWithValue("@trans_amount", LoggedinUserDetails.trans_amount);
            cmd.Parameters.AddWithValue("@trans_account", LoggedinUserDetails.trans_account);
            cmd.ExecuteNonQuery();

            string queryy = "Update Account set Balance=Balance+@amt where AccountNumber=" + acc;
            SqlCommand cmdd = new SqlCommand(queryy, con);
            //  cmd.CommandType = CommandType.StoredProcedure;
            cmdd.Parameters.AddWithValue("@amt", amt);
            cmdd.Parameters.AddWithValue("@acc", acc);
            cmdd.ExecuteNonQuery();

            con.Close();

        }

        public static void withdraw_money()
        {
            Console.WriteLine("Enter your account number");
            int acc = int.Parse(Console.ReadLine());
            LoggedinUserDetails.trans_account = acc;
            Console.WriteLine("enter the amount you want to withdraw");
            int amt = Convert.ToInt32(Console.ReadLine());
            LoggedinUserDetails.trans_amount = amt;
            string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            if (amt < view_balance())
            {
                LoggedinUserDetails.trans_type = "withdraw";
                string query = "Update Account set Balance=Balance-@amt where AccountNumber=" + acc;
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@amt", amt);
                cmd.Parameters.AddWithValue("@acc", acc);
                cmd.ExecuteNonQuery();
                con.Close();
                DateTime createdOn = DateTime.Now;
                //string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
                // SqlConnection con = new SqlConnection(cs);
                string queryy = "INSERT INTO [Transaction] (AccountNumber,Transaction_type,Transaction_amount,Created_by,Created_on) VALUES(@trans_account,@trans_type,@trans_amount,@LoggedinUserID,@createdOn)";

                con.Open();
                SqlCommand cmdd = new SqlCommand(queryy, con);

                //Pass values to Parameters
                cmdd.Parameters.AddWithValue("@createdOn", createdOn);
                cmdd.Parameters.AddWithValue("@trans_type", LoggedinUserDetails.trans_type);
                cmdd.Parameters.AddWithValue("@trans_amount", LoggedinUserDetails.trans_amount);
                cmdd.Parameters.AddWithValue("@trans_account", LoggedinUserDetails.trans_account);
                cmdd.Parameters.AddWithValue("@LoggedinUserID",LoggedinUserDetails.LoggedinUserID);
                cmdd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient Balance!! Cannot perform transaction ");
                Console.ResetColor();
            }
        }


        public static void view_transaction()
        {
            Console.WriteLine("Enter your account number");
            int acc = int.Parse(Console.ReadLine());

            string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string quer = "select AccountNumber from Account where User_ID=" + LoggedinUserDetails.LoggedinUserID;
            SqlCommand cmd2 = new SqlCommand(quer, con);

            int accNumber = Convert.ToInt32(cmd2.ExecuteScalar());
            con.Close();

            if (acc == accNumber)
            {
                DataSet ds = DbConnection.runUserQuery("SELECT Transaction_ID, AccountNumber,Transaction_type,Transaction_amount, Created_by,Created_on From [Transaction] where AccountNumber=" + acc);
                Console.WriteLine("Transaction Details are:-->");


                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
                string data = String.Format("{0,-15} {1,-15} {2,-20} {3,-20} {4,-20} {5,-10} {6}", "|Transaction_ID", "|AccountNumber", "|Transaction_type", "|Transaction_amount", "|Created_by", "|Created_on", "|");
                Console.WriteLine(data);
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow db in table.Rows)
                    {
                        data = String.Format("{0,-15} {1,-15} {2,-20} {3,-20} {4,-20} {5,-10} {6}", "|" + db[0], "|" + db[1], "|" + db[2], "|" + db[3], "|" + db[4], "|" + db[5], "|");
                        Console.WriteLine(data);
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter your own account number to view transaction details. you cannot view for others");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

