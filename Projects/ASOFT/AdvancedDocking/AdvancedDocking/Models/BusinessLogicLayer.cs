using AdvancedDocking.Utility;

using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;


namespace AdvancedDocking.Models
{
    internal class BusinessLogicLayer
    {
        private basicTestEntities _dataAccessLayer = null;
        string connectionString = ConnectionString.CName;

        public BusinessLogicLayer()
        {
            _dataAccessLayer = new basicTestEntities();
        }

        internal ObjectResult<spGetAllEmployee_Result> GetEmployees()
        {
            return _dataAccessLayer.spGetAllEmployee();
        }

        internal int SaveEmployee(Employee employee)
        {
            var spResult = GetEmployee(employee.UserID);
            Employee emp = new Employee
            {
                UserID = spResult.UserID,
                UserName = spResult.UserName,
                Password = spResult.Password,
                Email = spResult.Email,
                Tel = spResult.Tel,
                Disable = spResult.Disable
            };

            if (emp.UserID == null)
            {
                return _dataAccessLayer.spAddEmployee(userID: employee.UserID, userName: employee.UserName,
                    password: employee.Password, email: employee.Email, tel: employee.Tel, disable: employee.Disable);
            }
            else
            {
                return _dataAccessLayer.spUpdateEmployee(userID: employee.UserID, userName: employee.UserName,
                    password: employee.Password, email: employee.Email, tel: employee.Tel, disable: employee.Disable);
            }
        }

        internal Employee GetEmployee(string id)
        {
            Employee emp = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Employee WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@UserID", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    emp.UserID = rdr["UserID"].ToString();
                    emp.UserName = rdr["UserName"].ToString();
                    emp.Password = rdr["Password"].ToString();
                    emp.Email = rdr["Email"].ToString();
                    emp.Tel = rdr["Tel"].ToString();
                    emp.Disable = (byte)rdr["Disable"];
                }
            }
            return emp;
        }

        internal int DeleteEmployee(string id)
        {
            return _dataAccessLayer.spDeleteEmployee(id);
        }
    }
}
