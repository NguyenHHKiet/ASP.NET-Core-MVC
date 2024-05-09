﻿using BasicCRUDWeb1.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace BasicCRUDWeb1.Models
{
    public class EmployeeDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> lstEmployee = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee Employee = new Employee();
                    Employee.UserID = rdr["UserID"].ToString();
                    Employee.UserName = rdr["UserName"].ToString();
                    Employee.Password = rdr["Password"].ToString();
                    Employee.Email = rdr["Email"].ToString();
                    Employee.Tel = rdr["Tel"].ToString();
                    Employee.Disable = (byte)Convert.ToInt32(rdr["Disable"]);

                    lstEmployee.Add(Employee);
                }
                con.Close();
            }
            return lstEmployee;
        }

        public void AddEmployee(Employee Employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", Employee.UserID.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@UserName", Employee.UserName);
                cmd.Parameters.AddWithValue("@Password", Employee.Password);
                cmd.Parameters.AddWithValue("@Email", Employee.Email);
                cmd.Parameters.AddWithValue("@Tel", Employee.Tel);
                cmd.Parameters.AddWithValue("@Disable", Employee.Disable);

                if (Employee.IsValidEmail(Employee.Email))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    Console.WriteLine("Địa chỉ email không hợp lệ.");
                }
            }
        }

        public void UpdateEmployee(Employee Employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", Employee.UserID);
                cmd.Parameters.AddWithValue("@UserName", Employee.UserName);
                cmd.Parameters.AddWithValue("@Password", Employee.Password);
                cmd.Parameters.AddWithValue("@Email", Employee.Email);
                cmd.Parameters.AddWithValue("@Tel", Employee.Tel);
                cmd.Parameters.AddWithValue("@Disable", Employee.Disable);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Employee GetEmployeeData(string id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Employee WHERE UserID=@UserID";
                using (SqlCommand command = new SqlCommand(sqlQuery, con))
                {
                    command.Parameters.AddWithValue("@UserID", id);
                    con.Open();
                    SqlDataReader rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        employee.UserID = rdr["UserID"].ToString();
                        employee.UserName = rdr["UserName"].ToString();
                        employee.Password = rdr["Password"].ToString();
                        employee.Email = rdr["Email"].ToString();
                        employee.Tel = rdr["Tel"].ToString();
                        employee.Disable = (byte)Convert.ToInt32(rdr["Disable"]);
                    }
                    con.Close();
                }
            }
            return employee;
        }

        public void DeleteEmployee(string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}