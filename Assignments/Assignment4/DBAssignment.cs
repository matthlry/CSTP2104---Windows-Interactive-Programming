using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Assignment.Assignment4
{
    public class DBAssignment
    {
        private SqliteConnection OpenConnection()
        {
            SqliteConnection connection = new SqliteConnection();
            return connection;
        }
        public void CreateInsertQuery()
        {
            var connection = this.OpenConnection();
            var createCommand = connection.CreateCommand();
            createCommand.CommandText = "CREATE TABLE Student (id INTEGER, name VARCHAR(50), streetaddress VARCHAR(100), city VARCHAR(30), province VARCHAR(30), country VARCHAR(30), postalcode VARCHAR(20), email VARCHAR(50), phonenumber INTEGER, programid INTEGER);" +
                                  "CREATE TABLE Program (id INTEGER, name VARCHAR(50), description VARCHAR(200));" +
                                  "CREATE TABLE Course (id INTEGER, name VARCHAR(50), description VARCHAR(200), credit INTEGER);" +
                                  "CREATE TABLE ProgramCourse (programid INTEGER, courseid INTEGER, required BOOLEAN);";
            connection.Open();
            createCommand.ExecuteNonQuery();

            var insertStudentCommand = connection.CreateCommand();
            insertStudentCommand.CommandText = "INSERT INTO Student (id, name, streetaddress, city, province, country, postalcode, email, phonenumber, programid) VALUES (@id, @name, @streetaddress, @city, @province, @country, @postalcode, @email, @phonenumber, @programid)";
            insertStudentCommand.Parameters.AddWithValue("@id", 012345);
            insertStudentCommand.Parameters.AddWithValue("@name", "Eric Reyes");
            insertStudentCommand.Parameters.AddWithValue("@streetaddress", "Guildford Street");
            insertStudentCommand.Parameters.AddWithValue("@city", "Surrey");
            insertStudentCommand.Parameters.AddWithValue("@province", "British Columbia");
            insertStudentCommand.Parameters.AddWithValue("@country", "Canada");
            insertStudentCommand.Parameters.AddWithValue("@postalcode", "V3T 5K2");
            insertStudentCommand.Parameters.AddWithValue("@email", "ereyes@sample.com");
            insertStudentCommand.Parameters.AddWithValue("@phonenumber", 7782140985);
            insertStudentCommand.Parameters.AddWithValue("@programid", 098765);
            insertStudentCommand.ExecuteNonQuery();
            insertStudentCommand.Parameters.Clear();

            insertStudentCommand.Parameters.AddWithValue("@id", 345678);
            insertStudentCommand.Parameters.AddWithValue("@name", "Justin Brant");
            insertStudentCommand.Parameters.AddWithValue("@streetaddress", "Fleetwood Street");
            insertStudentCommand.Parameters.AddWithValue("@city", "Surrey");
            insertStudentCommand.Parameters.AddWithValue("@province", "British Columbia");
            insertStudentCommand.Parameters.AddWithValue("@country", "Canada");
            insertStudentCommand.Parameters.AddWithValue("@postalcode", "V5H 7J0");
            insertStudentCommand.Parameters.AddWithValue("@email", "just_brant@sample.com");
            insertStudentCommand.Parameters.AddWithValue("@phonenumber", 7786240766);
            insertStudentCommand.Parameters.AddWithValue("@programid", 765432);
            insertStudentCommand.ExecuteNonQuery();
            insertStudentCommand.Parameters.Clear();

            var insertProgramCommand = connection.CreateCommand();
            insertProgramCommand.CommandText = " INSERT INTO Program (id, name, description) VALUES (@id, @name, @description)";
            insertProgramCommand.Parameters.AddWithValue("@id", 098765);
            insertProgramCommand.Parameters.AddWithValue("@name", "Civil Engineering");
            insertProgramCommand.Parameters.AddWithValue("@description", "Professional engineering discipline that deals with the design, construction, and maintenance of the physical and naturally built environment.");
            insertProgramCommand.ExecuteNonQuery();
            insertProgramCommand.Parameters.Clear();

            insertProgramCommand.Parameters.AddWithValue("@id", 765432);
            insertProgramCommand.Parameters.AddWithValue("@name", "Psychology");
            insertProgramCommand.Parameters.AddWithValue("@description", "An academic discipline of immense scope, crossing the boundaries between the natural and social sciences.");
            insertProgramCommand.ExecuteNonQuery();
            insertProgramCommand.Parameters.Clear();

            var insertCourseCommand = connection.CreateCommand();
            insertCourseCommand.CommandText = " INSERT INTO Course (id, name, description) VALUES (@id, @name, @description)";
            insertCourseCommand.Parameters.AddWithValue("@id", 101);
            insertCourseCommand.Parameters.AddWithValue("@name", "Engineering Foundation");
            insertCourseCommand.Parameters.AddWithValue("@description", "Basic foundation of different engineering classes");
            insertCourseCommand.ExecuteNonQuery();
            insertCourseCommand.Parameters.Clear();
            
            insertCourseCommand.Parameters.AddWithValue("@id", 104);
            insertCourseCommand.Parameters.AddWithValue("@name", "AutoCad");
            insertCourseCommand.Parameters.AddWithValue("@description", "Commercial computer-aided design and drafting.");
            insertCourseCommand.ExecuteNonQuery();
            insertCourseCommand.Parameters.Clear();

            insertCourseCommand.Parameters.AddWithValue("@id", 102);
            insertCourseCommand.Parameters.AddWithValue("@name", "Social Studies");
            insertCourseCommand.Parameters.AddWithValue("@description", "Integrated study of multiple fields of social science and the humanities, including history, geography, and political science");
            insertCourseCommand.ExecuteNonQuery();
            insertCourseCommand.Parameters.Clear();

            insertCourseCommand.Parameters.AddWithValue("@id", 108);
            insertCourseCommand.Parameters.AddWithValue("@name", "History of Philosophy");
            insertCourseCommand.Parameters.AddWithValue("@description", "Study of general and fundamental questions, such as those about existence, reason, knowledge, values, mind, and language");
            insertCourseCommand.ExecuteNonQuery();
            insertCourseCommand.Parameters.Clear();

            var insertProgCourseCommand = connection.CreateCommand();
            insertProgCourseCommand.CommandText = " INSERT INTO ProgramCourse (programid, courseid, required) VALUES (@programid, @courseid, @required)";
            insertProgCourseCommand.Parameters.AddWithValue("@programid", 098765);
            insertProgCourseCommand.Parameters.AddWithValue("@courseid", 101);
            insertProgCourseCommand.Parameters.AddWithValue("@required", "TRUE");
            insertProgCourseCommand.ExecuteNonQuery();
            insertProgCourseCommand.Parameters.Clear();

            insertProgCourseCommand.Parameters.AddWithValue("@programid", 098765);
            insertProgCourseCommand.Parameters.AddWithValue("@courseid", 104);
            insertProgCourseCommand.Parameters.AddWithValue("@required", "FALSE");
            insertProgCourseCommand.ExecuteNonQuery();
            insertProgCourseCommand.Parameters.Clear();

            insertProgCourseCommand.Parameters.AddWithValue("@programid", 765432);
            insertProgCourseCommand.Parameters.AddWithValue("@courseid", 102);
            insertProgCourseCommand.Parameters.AddWithValue("@required", "FALSE");
            insertProgCourseCommand.ExecuteNonQuery();
            insertProgCourseCommand.Parameters.Clear();

            insertProgCourseCommand.Parameters.AddWithValue("@programid", 765432);
            insertProgCourseCommand.Parameters.AddWithValue("@courseid", 108);
            insertProgCourseCommand.Parameters.AddWithValue("@required", "TRUE");
            insertProgCourseCommand.ExecuteNonQuery();
            insertProgCourseCommand.Parameters.Clear();

            var queryCommand = connection.CreateCommand();
            queryCommand.CommandText = "SELECT name, email, phonenumber FROM Student WHERE programid = 098765";
            var readCommand = queryCommand.ExecuteReader();
            while (readCommand.Read())
            {
                Console.WriteLine("=======================");
                Console.WriteLine(readCommand[0]);
                Console.WriteLine(readCommand[1]);
                Console.WriteLine(readCommand[2]);
            }
            readCommand.Close();

            queryCommand.CommandText = "SELECT * FROM ProgramCourse WHERE courseid = 102";
            var rCommand = queryCommand.ExecuteReader();
            while (rCommand.Read())
            {
                Console.WriteLine("=======================");
                Console.WriteLine(rCommand[0]);
                Console.WriteLine(rCommand[1]);
                Console.WriteLine(rCommand[2]);
            }
            rCommand.Close();

            connection.Close();
        }       
    }
}
