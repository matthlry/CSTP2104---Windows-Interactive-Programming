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

            int result = insertComand.ExecuteNonQuery();

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
        public void Insert()
        {

        }
    }
}
