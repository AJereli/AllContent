using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using MySql.Data.MySqlClient;
namespace AllContent_Client
{
    public class Favorit
    {
        private const uint cntOfColumns = 7;
        private uint CurrentNewsID = 0;

        private bool IsSource;
        public bool IsSelect { get; set; }
        public string Name { get; private set; }
        public string Value { get; private set; }
        public Favorit(string name, string value)
        {
            Name = name;
            Value = value;
            if (Name.Contains("http:") || Name.Contains("https:"))
            {
                Name = Name.Split(':')[1];
                Name = Name.Replace('/', '_');

            }
            if (Value.Contains("http:") || Value.Contains("https:"))
                IsSource = true;
            else IsSource = false;
        }

        private void LoadFromSource()
        {
            using (DBClient mysql_client = new DBClient())
            {
                MySqlParameters mysql_param = new MySqlParameters();
                mysql_param.AddParameter(Name, Value);

                DateTime day_ago = DateTime.Now.AddDays(-Model.max_age_news);
                string day_ago_str = day_ago.ToString("d", new CultureInfo(("en-US")));

                mysql_param.AddParameter("date", day_ago_str);
                List<string> contents = null;
                if (CurrentNewsID == 0)
                {
                    contents = mysql_client.SelectQuery("SELECT id, header, description, imgUrl, URL, tags, source, date FROM content " +
                            "WHERE source=@" + Name + " AND time_of_addition > @date LIMIT 20"
                            , mysql_param);
                }
                else {

                    List<string> chek_id = mysql_client.SelectQuery("SELECT MAX(id) FROM content " +
                           "WHERE source = @" + Name, mysql_param);


                    if (Convert.ToUInt32(chek_id[0]) > CurrentNewsID)
                    {
                        contents = mysql_client.SelectQuery("SELECT id, header, description, imgUrl, URL, tags, source, date FROM content " +
                                "WHERE source = @" + Name + " AND time_of_addition > @date AND id > " + CurrentNewsID.ToString() +
                                " ORDER BY id DESC LIMIT 20", mysql_param);

                    }

                }
                if (contents != null)
                {
                    CurrentNewsID = Convert.ToUInt32(contents[0]);

                    for (int i = 0; i < contents.Count; i += 8)
                    {
                        ContentUnit cu = new ContentUnit();

                        cu.ID = Convert.ToUInt32(contents[i]);
                        cu.header = contents[i + 1];
                        cu.description = contents[i + 2];
                        cu.imgUrl = contents[i + 3];
                        cu.URL = contents[i + 4];
                        cu.tags = contents[i + 5];
                        cu.source = contents[i + 6];
                        cu.date = contents[i + 7];
                        Model.content_collect.Add(cu);

                    }
                }



            }
        }

        public void LoadFavoritContent()
        {
            if (IsSource)
                LoadFromSource();


        }


    }
    public class Favorites
    {
        public event EventHandler FavoritesChange = delegate { };
        private object loadLock = new object();

        private List<Favorit> current_favorites { get; set; }
        public List<string> all_favotits;

        string UserName;

        public Favorites(string user_name)
        {
            UserName = user_name;
            current_favorites = new List<Favorit>();
            InitAllFavorit();
            InitFavorites();
        }

        public bool CheckForSelected(string name)
        {
            var favor = current_favorites.Find(m => m.Value == name);
            if (favor == null)
                return false;
            else return favor.IsSelect;
        }

        private void InitAllFavorit()
        {
            using (DBClient client = new DBClient())
            {
                all_favotits = new List<string>();
                List<string> tmp = client.SelectQuery("SELECT favorites_source FROM users WHERE login=@login", new MySqlParameter("login", "$sources"));
                foreach (var str in tmp[0].Split(';'))
                {
                    if (str != "")
                        all_favotits.Add(str);
                }
            }
        }

        private void InitFavorites()
        {
            using (DBClient client = new DBClient())
            {
                List<string> tmp = new List<string>();
                tmp = client.SelectQuery("SELECT favorites_source FROM users WHERE login=@login", new MySqlParameter("login", UserName));
                foreach (var str in tmp[0].Split(';'))
                {
                    if (str != "")
                    {
                        current_favorites.Add(new Favorit(str, str) { IsSelect = true });
                    }
                }
            }
        }

        public void LoadFavoritesContent()
        {
            lock (loadLock)
                foreach (var fav in current_favorites)
                    fav.LoadFavoritContent();
        }

        public void Add(Favorit favor)
        {
            lock (loadLock)
            {
                current_favorites.Add(favor);
                using (DBClient client = new DBClient())
                {
                    List<string> tmp = new List<string>();
                    tmp = client.SelectQuery("SELECT favorites_source FROM users WHERE login=@login ", new MySqlParameter("login", UserName));
                    tmp[0] += favor.Value + ";";
                    MySqlParameters sql_params = new MySqlParameters();
                    sql_params.AddParameter("favors", tmp[0]);
                    sql_params.AddParameter("name", User.Name);
                    client.Query("UPDATE users SET favorites_source=@favors WHERE login = @name", sql_params);
                }
            }
            FavoritesChange(this, new EventFavoritesArgs(favor.Name, TypeOfFavoritesChange.Add));
        }

        public void Add(string name, string value)
        {
            Favorit favor = new Favorit(name, value);
            Add(favor);
        }

        public void Delete(Favorit favor)
        {

            current_favorites.Remove(current_favorites.Find(fav => fav.Name == favor.Name));


            using (DBClient client = new DBClient())
            {
                List<string> tmp = new List<string>();
                tmp = client.SelectQuery("SELECT favorites_source FROM users WHERE login=@login", new MySqlParameter("login", UserName));
                tmp[0] = tmp[0].Replace(favor.Value + ";", "");
                MySqlParameters sql_params = new MySqlParameters();
                sql_params.AddParameter("favors", tmp[0]);
                sql_params.AddParameter("name", User.Name);
                client.Query("UPDATE users SET favorites_source=@favors WHERE login = @name", sql_params);
                FavoritesChange(this, new EventFavoritesArgs(favor.Value, TypeOfFavoritesChange.Delete));

            }

        }
        public void Delete(string name, string value)
        {
            Favorit favor = new Favorit(name, value);
            Delete(favor);
        }
    }
}