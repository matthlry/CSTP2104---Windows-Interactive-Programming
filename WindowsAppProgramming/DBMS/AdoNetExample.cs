using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace WindowsAppLib.DBMS
{
    public class AdoNetExample
    {
        // Connection string for Microsoft SQL
        // string connString = "Server=myServer; Database=myDatabase; UserID=myUserID; Password=myPassword";
        // string connstring = "Server=myServer; Database=myDatabase; Trusted_Connection=True";
        // string connString = "DataSource=.\SQLEXPRESS; InitialCatalog=master; IntegratedSecurity=True"; dot(.) means local

        private SqliteConnection OpenConnection()
        {
            SqliteConnection connection = new SqliteConnection();            
            return connection;
        }
        public void CreateandAddRows()
        {
            var connection = this.OpenConnection();
            var command = connection.CreateCommand();
            command.CommandText = "CREATE TABLE students (name VARCHAR(50), email VARCHAR(50), address VARCHAR(100), id INTEGER)";
            connection.Open();
            command.ExecuteNonQuery();

            var insertComand = connection.CreateCommand();
            insertComand.CommandText = "INSERT INTO students (name, email, address, id) VALUES (@name, @email, @address, @id)";
            insertComand.Parameters.AddWithValue("@name", "Tom Brady");
            insertComand.Parameters.AddWithValue("@email", "tombrady@vcc.ca");
            insertComand.Parameters.AddWithValue("@address", "Broadway West Vancouver, BC");
            insertComand.Parameters.AddWithValue("@id", "1023");
            insertComand.ExecuteNonQuery();
            insertComand.Parameters.Clear();


            insertComand.Parameters.AddWithValue("@name", "Julio");
            insertComand.Parameters.AddWithValue("@email", "Julio@vcc.ca");
            insertComand.Parameters.AddWithValue("@address", "101 Broadway West Vancouver, BC");
            insertComand.Parameters.AddWithValue("@id", "1027");           
            insertComand.ExecuteNonQuery();
            insertComand.Parameters.Clear();

            var queryCommand = connection.CreateCommand();
            queryCommand.CommandText = "SELECT * FROM students";
            var reader = queryCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("=======================");
                Console.WriteLine(reader[0]);
                Console.WriteLine(reader[1]);
                Console.WriteLine(reader[2]);
                Console.WriteLine(reader[3]);
            }

            connection.Close();
        }
        public List<string> GetStudents()
        {
            var studentRecords = new List<string>();
            var stringBuilder = new StringBuilder();
            try
            {
                using var connection = this.OpenConnection();
                {
                    connection.Open();
                    var commandText = "SELECT * FROM students";
                    using var command = new SqliteCommand(commandText, connection);
                    {
                        command.CommandText = commandText;
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            stringBuilder.AppendLine("=======================");
                            stringBuilder.AppendLine(reader[0].ToString()); ;
                            stringBuilder.AppendLine(reader[1].ToString());
                            stringBuilder.AppendLine(reader[2].ToString());
                            stringBuilder.AppendLine(reader[3].ToString());
                            
                            studentRecords.Add(stringBuilder.ToString());
                            stringBuilder.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXception while reading student records: {ex.Message}");
                throw;
            }
            return studentRecords;
        }
    }
}
