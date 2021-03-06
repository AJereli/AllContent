﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace AllContent_Client
{
    public class User
    {
        static public string Name { get; private set; }
        public List<string> favoritSources { get; set; }
        public User()
        {
            favoritSources = new List<string>();
        }

        public void UpdateFavor()
        {
            using (DBClient client = new DBClient())
            {
                string myStringIsBigIsVeryVeryBig = "";
                for (int i = 0; i < favoritSources.Count; ++i)
                    myStringIsBigIsVeryVeryBig += favoritSources[i] + ";";
                MySqlParameters mysql_params = new MySqlParameters();
                mysql_params.AddParameter("favor", myStringIsBigIsVeryVeryBig);
                mysql_params.AddParameter("login", User.Name);
                
                client.Query("UPDATE users SET favorites_source = @favor WHERE login=@login", mysql_params);
            }
        }


        public void LoadFavoritSources()
        {
            using (DBClient client = new DBClient())
            {

                List<string> sources = client.SelectQuery("SELECT favorites_source FROM users WHERE login = @login", new MySqlParameter("login", Name));
                if (sources != null && sources.Count != 0)
                    foreach (var str in sources[0].Split(';'))
                    {
                        if (str != "")
                            favoritSources.Add(str);
                    }
            }
        }

        public bool Authorization(string login, string password)
        {
            using (DBClient mysql_client = new DBClient())
            {
                string query = "SELECT password FROM users WHERE login = @login;";
                List<string> hashed_pass = mysql_client.SelectQuery(query, new MySqlParameter("login", login.ToLower()));
                if (hashed_pass.Count == 0)
                    return false;

                if (MD5Hashing.CompareHashes(password, hashed_pass[0]))
                {
                    Name = login.ToLower();
                    return true;
                }
                else return false;
            }
        }

        public static bool Registration(string login, string password, string email)
        {
            using (DBClient mysql_client = new DBClient())
            {
                string query = @"SELECT login FROM users WHERE login = @login;";

                if (mysql_client.SelectQuery(query, new MySqlParameter("login", login.ToLower())).Count > 0)
                    return false;
                else
                {

                    MySqlParameters mysql_params = new MySqlParameters();

                    mysql_params.AddParameter(new MySqlParameter("login", login.ToLower()));
                    mysql_params.AddParameter(new MySqlParameter("password", MD5Hashing.GetMd5Hash(password)));
                    mysql_params.AddParameter(new MySqlParameter("email", email));
                    mysql_client.Query("INSERT INTO users (login, password, email) VALUES (@login, @password, @email)", mysql_params);
                    return true;
                }
            }
        }


    }
}
