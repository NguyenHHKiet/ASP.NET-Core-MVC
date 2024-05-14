namespace BasicWindowsFormsApp.Utility
{
    internal class ConnectionString
    {
        private const string V = "User Id=sa;Password=12345";
        private static string cName = "Data Source=.;Initial Catalog=basicTest;" + V;
        public static string CName
        {
            get => cName;
        }
    }
}
