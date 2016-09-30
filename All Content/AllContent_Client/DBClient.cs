﻿using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Windows;
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
            mysqlCSB.UserID = "user";
            mysqlCSB.Password = "TooEasyUserWork";
            mysqlConn.ConnectionString = mysqlCSB.ConnectionString;

        }
        public DBClient(MySqlConnectionStringBuilder _mysqlCSB)
        {
            mysqlConn = new MySqlConnection();
            mysqlCSB = _mysqlCSB;
            mysqlConn.ConnectionString = mysqlCSB.ConnectionString;

        }


        /// <summary>
        /// Implement INSERT, UPDATE or DELETE query
        /// </summary>
        /// <param name="query">Your SQL query</param>
        public void Query(string query, MySqlParameters parameters)
        {

            using (var mysqlConn = new MySqlConnection())
            {
                if (query.Contains("SELECT"))
                {
                    throw new Exception("WRONG TYPE OF SQL QUERY, NEED INSERT / UPDATE / DELETE");
                }
                lock (threadLock)
                {
                    mysqlConn.ConnectionString = mysqlCSB.ConnectionString;
                    mysqlConn.Open();
                    MySqlCommand com = new MySqlCommand(@query, mysqlConn);


                    foreach (var param in parameters)
                    {
                        MessageBox.Show("foreach para");
                        com.Parameters.Add(param);
                    }

                    MySqlDataReader dataReader = com.ExecuteReader();
                    dataReader.Read();
                    dataReader.Close();
                }
            }
        }

        /// <summary>
        /// Select information from DB
        /// </summary>
        /// <param name="query">Your SELECT query</param>
        /// <param name="parameters">All parameters</param>
        /// <returns>list of selected information</returns>

        public List<string> SelectQuery(string query, MySqlParameters parameters)
        {
            object lock_result = new object();
            using (var mysqlConn = new MySqlConnection())
            {
                mysqlConn.ConnectionString = mysqlCSB.ConnectionString;
                mysqlConn.OpenAsync();
                if (query.Contains("INSERT INTO"))
                {
                    throw new Exception("WRONG TYPE OF SQL QUERY, NEED SELECT");
                }
                List<string> result = new List<string>();


                MySqlCommand com = new MySqlCommand(@query, mysqlConn);

                foreach (var param in parameters)
                    com.Parameters.Add(param);


                var dataReader = com.ExecuteReaderAsync();


                while (dataReader.Result.Read())
                    lock (lock_result)
                        result.Add(dataReader.Result.GetString(0));


                dataReader.Result.Close();


                return result;
            }
        }
        /// <summary>
        /// Same, but only one parameter
        /// </summary>

        public List<string> SelectQuery(string query, MySqlParameter parameter)
        {
            MySqlParameters parameters = new MySqlParameters();
            parameters.AddParameter(parameter);
            return SelectQuery(query, parameters);
        }
    }
    class MySqlParameters : IEnumerable
    {
        private List<MySqlParameter> parameters { get; }
        public MySqlParameters()
        {
            parameters = new List<MySqlParameter>();
        }

        public void AddParameter(MySqlParameter param)
        {
            parameters.Add(param);
        }

        public void AddParameter(string param_name, object param_value)
        {
            parameters.Add(new MySqlParameter(param_name, param_value));
        }

        public IEnumerator GetEnumerator()
        {
            return parameters.GetEnumerator();
        }
    }
}