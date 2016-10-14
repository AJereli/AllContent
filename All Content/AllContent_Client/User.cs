using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
namespace AllContent_Client
{
   public class User
    {
        DBClient mysql_client;

        static public string Name { get; private set; }
        public Favorites favorites { get; private set; }
        public User()
        {
            mysql_client = new DBClient();
        }

         

        public void AddFavoritRubric(string rubric)
        {
            throw new Exception("Функция не реализованна");
        }
       
        public bool Authorization(string login, string password)
        {
            string query = @"SELECT password FROM users WHERE login = @login;";
            List<string> hashed_pass = mysql_client.SelectQuery(query, new MySqlParameter("login", login));
            if (hashed_pass.Count == 0)
                return false;

            if (MD5Hashing.CompareHashes(password, hashed_pass[0]))
            {
                Name = login;
                favorites = new Favorites(Name);
                return true;
            }
            else return false;

        }

        public bool Registration(string login, string password)
        {
            string query = @"SELECT password FROM users WHERE login = @login;";

            if (mysql_client.SelectQuery(query, new MySqlParameter("login", login)).Count > 0)
                return false;
            else
            {
                MySqlParameters mysql_params = new MySqlParameters();
                MySqlParameter param_login = new MySqlParameter("@login", login);
                MySqlParameter param_pass = new MySqlParameter("@password", MD5Hashing.GetMd5Hash(password));

                mysql_params.AddParameter(param_login);
                mysql_params.AddParameter(param_pass);
                mysql_client.Query("INSERT INTO users (login, password) VALUES (@login, @password)", mysql_params);
                return true;
            }
        }


    }
}
