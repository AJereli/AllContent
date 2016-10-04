using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Globalization;

namespace AllContent_Client
{
   

    class Model
    {
        public event EventHandler AuthorizationEvent = delegate { };

        User user;
        Favorites favorites;
        public ObservableCollection<ContentUnit> cont_collect { get; private set; }
        DBClient mysql_client;
        BackgroundWorker loadContent;
        public Model()
        {
            View.FavoritesChange += View_FavoritesChange;
            View.RefreshContent += View_RefreshContent;
            user = new User();
            mysql_client = new DBClient();
            favorites = new Favorites();
            loadContent = new BackgroundWorker();
            
            loadContent.DoWork += LoadContent_DoWork;
            cont_collect = new ObservableCollection<ContentUnit>();

            loadContent.RunWorkerAsync();
        }

        private void View_RefreshContent(object sender, EventArgs e)
        {
            if (!loadContent.IsBusy)
                loadContent.RunWorkerAsync();
        }

        private void View_FavoritesChange(object sender, EventArgs e)
        {
            favorites = ((EventFavoritesArgs)e).favor;
        }

        private void Authorization(string login, string passw)
        {
            bool result = user.Authorization(login, passw);

            AuthorizationEvent(this, new EventAuthorizationArgs(result, login));
            
        }

       

        private void LoadContent_DoWork(object sender, DoWorkEventArgs e)
        {
            MySqlParameters param = new MySqlParameters();
            param.AddParameter("lentaru", "https://lenta.ru");
           
            DateTime two_day_ago = DateTime.Now.AddDays(-2);
            string two_day_ago_str = two_day_ago.ToString("d", new CultureInfo(("en-US")));

            param.AddParameter("date", two_day_ago_str);
            MessageBox.Show(two_day_ago_str);
            List<string> contents = mysql_client.SelectQuery("SELECT header, description, imgUrl, url, date FROM content " +
                "WHERE source = @lentaru AND time_of_addition > @date" + 
                " ORDER BY id DESC", param);
            foreach (var c in contents)
            {
                
            }

        }
    }
}
