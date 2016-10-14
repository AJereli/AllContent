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
        public string Name { get; private set; }
        public string Value { get; private set; }
        public Favorit(string name, string value)
        {
            Name = name;
            Value = value;
            if (Value.Contains("http:") || Value.Contains("https:"))
                IsSource = true;
            else IsSource = false;
        }

        private void LoadFromSource()
        {
            using (DBClient mysql_client = new DBClient())
            {
                MySqlParameters param = new MySqlParameters();
                param.AddParameter(Name, Value);

                DateTime day_ago = DateTime.Now.AddDays(-Model.max_age_news);
                string day_ago_str = day_ago.ToString("d", new CultureInfo(("en-US")));

                param.AddParameter("date", day_ago_str);
                List<string> contents = null;
                if (CurrentNewsID == 0)
                {
                    contents = mysql_client.SelectQuery("SELECT id, header, description, imgUrl, URL, tags, date FROM content " +
                            "WHERE source = @" + Name + " AND time_of_addition > @date" +
                            " ORDER BY id DESC", param);
                }
                else {

                    List<string> chek_id = mysql_client.SelectQuery("SELECT MAX(id) FROM content " +
                           "WHERE source = @" + Name, param);


                    if (Convert.ToUInt32(chek_id[0]) > CurrentNewsID)
                    {
                        contents = mysql_client.SelectQuery("SELECT id, header, description, imgUrl, URL, tags, date FROM content " +
                                "WHERE source = @" + Name + " AND time_of_addition > @date AND id > " + CurrentNewsID.ToString() +
                                " ORDER BY id DESC", param);

                    }

                }
                if (contents != null)
                {
                    CurrentNewsID = Convert.ToUInt32(contents[0]);

                    for (int i = 0; i < contents.Count; i += 7)
                        using (ContentUnit cu = new ContentUnit())
                        {
                            cu.ID = Convert.ToUInt32(contents[i]);
                            cu.header = contents[i + 1];
                            cu.description = contents[i + 2];
                            cu.imgUrl = contents[i + 3];
                            cu.URL = contents[i + 4];
                            cu.tags = contents[i + 5];
                            cu.date = contents[i + 6];
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

        public List<Favorit> current_favorites { get; private set; }

        string UserName;

        public Favorites(string user_name)
        {
            UserName = user_name;
            current_favorites = new List<Favorit>();
            InitFavorites();
        }
        private void InitFavorites()
        {
            using (DBClient client = new DBClient())
            {
                List<string> tmp = new List<string>();
                tmp = client.SelectQuery("SELECT favorites_source FROM users WHERE login=@login", new MySqlParameter("login", UserName));
                foreach (var str in tmp[0].Split(';'))
                {
                    if (str == "")
                        continue;
                    current_favorites.Add(new Favorit(str, str));
                }
            }
        }

        public void LoadFavoritesContent()
        {
            foreach (var fav in current_favorites)
                lock (loadLock)
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
                    tmp = client.SelectQuery("SELECT favorites_source FROM users WHERE login=@login", new MySqlParameter("login", UserName));
                    tmp[0] += favor.Value + ";";
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
            lock (loadLock)
            {
                current_favorites.Remove(favor);
                using (DBClient client = new DBClient())
                {
                    List<string> tmp = new List<string>();
                    tmp = client.SelectQuery("SELECT favorites_source FROM users WHERE login=@login", new MySqlParameter("login", UserName));
                    MessageBox.Show("Old tmp\n" + tmp[0]);
                    tmp[0] = tmp[0].Replace(favor.Value + ";", "");
                    MessageBox.Show("new tmp\n" + tmp[0]);
                }
            }
            FavoritesChange(this, new EventFavoritesArgs(favor.Name, TypeOfFavoritesChange.Delete));
        }
        public void Delete(string name, string value)
        {
            Favorit favor = new Favorit(name, value);
            Delete(favor);
        }
    }
}