using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRecordManagementSystem.Utility
{
    public class ConnectionString
    {
        private const string V = "User Id=sa;Password=12345";
        private static string cName = "Data Source=.;Initial Catalog=StudentManagement;" + V;
        public static string CName
        {
            get => cName;
        }
    }
}