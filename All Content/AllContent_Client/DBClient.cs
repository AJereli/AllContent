using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace AllContent_Client
{


    class DBClient
    {


        MySqlConnectionStringBuilder mysqlCSB;
        MySqlConnection mysqlConn;
        private object threadLock = new object();
        public DBClient()
        {
            mysqlConn = new MySqlConnection();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "194.87.239.28";
            mysqlCSB.Port = 3306;
            mysqlCSB.Database = "content";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "TooEasyWork";
            mysqlConn.ConnectionString = mysqlCSB.ConnectionString;

        }
        public DBClient(MySqlConnectionStringBuilder _mysqlCSB)
        {
            mysqlConn = new MySqlConnection();
            mysqlCSB = _mysqlCSB;
            mysqlConn.ConnectionString = mysqlCSB.ConnectionString;

        }

        public void SetUserData(string login, string password)
        {
            mysqlCSB.UserID = login;
            mysqlCSB.Password = password;
            mysqlConn.ConnectionString = mysqlCSB.ConnectionString;
        }


        /// <summary>
        /// Implement INSERT, UPDATE or DELETE query
        /// </summary>
        /// <param name="query">Your SQL query</param>

        public void Query(string query)
        {
            using (var mysqlConn = new MySqlConnection())
            {
                mysqlConn.ConnectionString = mysqlCSB.ConnectionString;
                mysqlConn.Open();
                if (query.Contains("SELECT"))
                {
                    throw new Exception("WRONG TYPE OF SQL QUERY, NEED INSERT / UPDATE / DELETE");
                }

                MySqlCommand com = new MySqlCommand(@query, mysqlConn);

                MySqlDataReader dataReader = com.ExecuteReader();
                dataReader.Read();
                dataReader.Close();
            }
        }
      
        /// <summary>
        /// Select information from DB
        /// </summary>
        /// <param name="query">Your SELECT query</param>
        /// <returns>list of selected information</returns>
        public List<string> SelectQuery(string query)
        {
            using (var mysqlConn = new MySqlConnection())
            {
                mysqlConn.ConnectionString = mysqlCSB.ConnectionString;
                mysqlConn.Open();
                if (query.Contains("INSERT INTO"))
                {
                    throw new Exception("WRONG TYPE OF SQL QUERY, NEED SELECT");
                }
                List<string> result = new List<string>();

                MySqlCommand command = new MySqlCommand(@query, mysqlConn);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    result.Add(dataReader.GetString(0));

                dataReader.Close();


                return result;
            }

        }
    }
}
