using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordManagementSystem.Utility
{
    public static class ConnectionString
    {

        private static string cName = "Data Source=.;  Initial Catalog=StudentManagement;User ID=sa;Password=123";

        public static string CName { get => cName; }
    }
}
