using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    internal class DbConnection
    {
        public static DataSet runUserQuery(string Query)
        {
           string cs = @"server=(localdb)\MSSqlLocalDb;database=BankingDB;";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(Query, conn);
            adapter.Fill(ds);
            conn.Close();
            return ds;
            
        }
    }
}
