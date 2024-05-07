using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicCRUDWeb1.Utility
{
    public class ConnectionString
    {
        private static string cName = "Data Source=.; Initial Catalog=basicTest;User ID=sa;Password=12345";
        public static string CName
        {
            get => cName;
        }
    }
}