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

        static public ObservableCollection<ContentUnit> content_collect { get; private set; }
        static public uint max_age_news = 1;
        public uint RefreshTime { get; set; }


        static public User user { get; set; }
        BackgroundWorker loadAllContent;
        public Model()
        {

            MainView.RefreshContent += View_RefreshContent;
            loadAllContent = new BackgroundWorker();
            loadAllContent.DoWork += LoadAllContent_DoWork;


            content_collect = new ObservableCollection<ContentUnit>();
            user.favorites.FavoritesChange += Favorites_FavoritesChange;


            loadAllContent.RunWorkerAsync();
        }

        public void RefreshAllContent()
        {
            if (!loadAllContent.IsBusy)
                loadAllContent.RunWorkerAsync();
        }

        private void Favorites_FavoritesChange(object sender, EventArgs e)
        {
            EventFavoritesArgs args = ((EventFavoritesArgs)e);
            var md = content_collect.Where(unit => unit.source == args.Name);
            if (args.Type == TypeOfFavoritesChange.Delete)
                foreach (ContentUnit cu in md)
                    content_collect.Remove(cu);
            
            else if (args.Type == TypeOfFavoritesChange.Add)
            {

            }


        }




        private void View_RefreshContent(object sender, EventArgs e)
        {
            if (!loadAllContent.IsBusy)
                loadAllContent.RunWorkerAsync();
        }



        private void Authorization(string login, string passw)
        {
            bool result = user.Authorization(login, passw);

            AuthorizationEvent(this, new EventAuthorizationArgs(result, login));

        }


        private void LoadAllContent_DoWork(object sender, DoWorkEventArgs e)
        {
            user.favorites.LoadFavoritesContent();
        }

    }
}
