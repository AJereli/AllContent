using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;

namespace AllContent_Client
{
    class Favorit
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
    class Favorites
    {
        public event EventHandler FavoritesChange = delegate { };
        private object loadLock = new object();

        public List<Favorit> current_favorites { get; private set; }
        public Favorites()
        {
            current_favorites = new List<Favorit>();
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
                current_favorites.Add(favor);
            FavoritesChange(this, new EventFavoritesArgs(favor.Name, TypeOfFavoritesChange.Add));
        }

        public void Add(string name, string value)
        {
            Favorit favor = new Favorit(name, value);
            lock (loadLock)
                current_favorites.Add(favor);
            FavoritesChange(this, new EventFavoritesArgs(name, TypeOfFavoritesChange.Add));
        }

        public void Delete(Favorit favor)
        {
            lock (loadLock)
                current_favorites.Remove(favor);
            FavoritesChange(this, new EventFavoritesArgs(favor.Name, TypeOfFavoritesChange.Delete));
        }
        public void Delete(string name, string value)
        {
            Favorit favor = new Favorit(name, value);
            lock (loadLock)
                current_favorites.Remove(favor);
            FavoritesChange(this, new EventFavoritesArgs(name, TypeOfFavoritesChange.Delete));
        }
    }
}