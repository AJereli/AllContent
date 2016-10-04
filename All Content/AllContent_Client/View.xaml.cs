using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AllContent_Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class View : Window
    {

        static public event EventHandler FavoritesChange = delegate { };
        static public event EventHandler RefreshContent = delegate { };

        Model model;
        Favorites favorites;
        public View()
        {
            InitializeComponent();
            model = new Model();
            model.AuthorizationEvent += Model_AuthorizationEvent;
            model.cont_collect.CollectionChanged += Cont_collect_CollectionChanged;
            favorites = new Favorites();
            User user = new User();
            if (user.Authorization("MyLogin", "MyPassword"))
            {
                user.AddFavoritSource("a");
                user.AddFavoritSource("http://www.w3schools.com/sql/sql_update.asp");



            }
        }

        private void Cont_collect_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UserChangeFavorites()
        {
            FavoritesChange(this, new EventFavoritesArgs(favorites));
        }

        private void Model_AuthorizationEvent(object sender, EventArgs e)
        {
            var args = (EventAuthorizationArgs)e;
            
            throw new NotImplementedException();
        }
    }
}
