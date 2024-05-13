using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WinFormsContacts
{
    internal class DataAccessLayer
    {
        private static readonly string cName = "Data Source=.; Initial Catalog=basicTest;User ID=sa;Password=12345";
        private readonly SqlConnection conn = new SqlConnection(cName);

        public void InsertContact(Contacts contacts)
        {
            try
            {
                conn.Open();
                string query = @"
                  INSERT INTO Contacts (FirstName, LastName, Phone, Address)
                  VALUES (@FirstName, @LastName, @Phone, @Address)
                ";

                SqlParameter firstName = new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = contacts.FirstName,
                    DbType = System.Data.DbType.String
                };

                SqlParameter lastName = new SqlParameter("@LastName", contacts.LastName);
                SqlParameter phone = new SqlParameter("@Phone", contacts.Phone);
                SqlParameter address = new SqlParameter("@Address", contacts.Address);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);
                command.Parameters.Add(phone);
                command.Parameters.Add(address);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Contacts> GetContacts(string searchText = null)
        {
            List<Contacts> contacts = new List<Contacts>();
            try
            {
                conn.Open();
                string query = @"SELECT * FROM Contacts";

                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(searchText))
                {
                    query += @"WHERE FirstName LIKE @Search OR LastName LIKE @Search OR Phone LIKE @Search OR
                                Address LIKE @Search";

                    command.Parameters.Add(new SqlParameter("@Search", $"%{searchText}"));
                }
                command.CommandText = query;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    contacts.Add(new Contacts
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }

            return contacts;
        }

        internal void UpdateContact(Contacts contacts)
        {
            try
            {
                conn.Open();
                string query = @"
                    UPDATE Contacts
                    SET FirstName = @FirstName,
                        LastName = @LastName,
                        Phone = @Phone,
                        Address = @Address
                    WHERE Id = @Id
                ";

                SqlParameter id = new SqlParameter("@Id", contacts.Id);
                SqlParameter firstName = new SqlParameter("@FirstName", contacts.FirstName);
                SqlParameter lastName = new SqlParameter("@LastName", contacts.LastName);
                SqlParameter phone = new SqlParameter("@Phone", contacts.Phone);
                SqlParameter address = new SqlParameter("@Address", contacts.Address);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(id);
                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);
                command.Parameters.Add(phone);
                command.Parameters.Add(address);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
        }

        internal void DeleteContacts(int id)
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM Contacts WHERE id = @Id";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@Id", id));

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
        }
    }
}
