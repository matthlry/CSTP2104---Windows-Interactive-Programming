using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCommon.Interfaces;

namespace DataAccessLayer
{
    public class DBConfig : IDBConfig
    {
        private const string connectionString = "Server=localhost;Database=Project;Trusted_Connection=True;";
        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
