﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace Content_Agregator
{


    class DBClient
    {
        MySqlConnectionStringBuilder mysqlCSB;
        MySqlConnection mysqlConn;

        public DBClient()
        {
            mysqlConn = new MySqlConnection();
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "localhost";
            mysqlCSB.Database = "my_db";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "Gonnadown";
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
        /// Open a connection with DB
        /// </summary>
        public void OpenConnection()
        {
            mysqlConn.Open();
        }
        /// <summary>
        /// Close a connection whith DB
        /// </summary>
        public void CloseConnection()
        {
            mysqlConn.Close();
        }

        /// <summary>
        /// Implement INSERT, UPDATE or DELETE query
        /// </summary>
        /// <param name="query">Your query</param>

        public void Query(string query)
        {
            if (query.Contains("SELECT"))
            {
                throw new Exception("WRONG TYPE OF SQL QUERY, NEED INSERT / UPDATE / DELETE");
            }

            MySqlCommand com = new MySqlCommand(query, mysqlConn);
            MySqlDataReader dataReader = com.ExecuteReader();
            dataReader.Read();
            dataReader.Close();
        }

        public List<string> SelectQuery(string query)
        {
            if (query.Contains("INSERT"))
            {
                throw new Exception("WRONG TYPE OF SQL QUERY, NEED SELECT");
            }
            List<string> result = new List<string>();
            MySqlCommand command = new MySqlCommand(query, mysqlConn);
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
                result.Add(dataReader.GetString(0));
           
            dataReader.Close();
            return result;
        }

    }
}
