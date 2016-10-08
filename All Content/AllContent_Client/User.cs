using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
namespace AllContent_Client
{
    class User
    {
        DBClient mysql_client;

        static public string Name { get; private set; }
        static public List<string> Favorites { get; private set; }
        public User()
        {
            mysql_client = new DBClient();
            Favorites = new List<string>();
        }

        private void DownloadFavoritesSources()
        {
            string query = @"SELECT favorites_source FROM users WHERE login = @login;";
            List<string> favor_sources = mysql_client.SelectQuery(query, new MySqlParameter("login", Name));
            if (favor_sources.Count == 0)
                return;
            var tmp_favor = favor_sources[0].Split(';');
            for (int i = 0; i < tmp_favor.Length; ++i)
                if (tmp_favor[i] != "")
                    Favorites.Add(tmp_favor[i] + ";");
        }

        private string ListToString()
        {
            string ans = "";
            foreach (var str in Favorites)
                ans += str;
            return ans;
        }

        public void AddFavoritRubric(string rubric)
        {
            throw new Exception("Функция не реализованна");
        }
        public void AddFavoritSource(string source)
        {
            Favorites.Add(source + ";");

            string query = @"UPDATE users SET favorites_source=@favorite_source WHERE login=@login";
            MySqlParameters msp = new MySqlParameters();
            msp.AddParameter(new MySqlParameter("favorite_source", ListToString()));
            msp.AddParameter(new MySqlParameter("login", @Name));
            mysql_client.Query(query, msp);
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
                DownloadFavoritesSources();
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
