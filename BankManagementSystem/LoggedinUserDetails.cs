using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    public static class LoggedinUserDetails
    {
        public static int LoggedinUserID { get; set; }
       public static string LoggedinUserType { get; set; }

        public static int trans_amount { get; set; }

        public static int trans_account { get; set; }

        public static string trans_type { get; set; }
    }
}
