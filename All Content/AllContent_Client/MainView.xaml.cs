using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Specialized;
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


        static public event EventHandler RefreshContent = delegate { };

        Model model;
        public View()
        {
            model = new Model();
            model.AuthorizationEvent += Model_AuthorizationEvent;
            Model.content_collect.CollectionChanged += Cont_collect_CollectionChanged;
            User user = new User();
            InitializeComponent();
            InitAllFavorites();
            button_refresh_favor.Click += Button_refresh_favor_Click;
            if (user.Authorization("MyLogin", "MyPassword"))
            {
                lable_name.Content = user.Name;
            }

        }

        private void Button_refresh_favor_Click(object sender, RoutedEventArgs e)
        {
            model.RefreshAllContent();
        }

        private void InitAllFavorites()
        {
            List<Tuple<string, string>> favorites = new List<Tuple<string, string>>();
            favorites.Add(new Tuple<string, string>("LentaRu", "https://lenta.ru"));
            favorites.Add(new Tuple<string, string>("TJ", "https://tjournal.ru"));
            favorites.Add(new Tuple<string, string>("Ria", "https://ria.ru/lenta"));

            for (int i = 0; i < favorites.Count; ++i)
            {
                CheckBox cb = new CheckBox()
                {
                    Name = favorites[i].Item1,
                    Content = favorites[i].Item2,
                    Height = 20,
                    VerticalAlignment = VerticalAlignment.Top
                };
                cb.Checked += (s, e) => model.favorites.Add(((CheckBox)s).Name, (string)((CheckBox)s).Content);
                cb.Unchecked += (s, e) => model.favorites.Delete(((CheckBox)s).Name, (string)((CheckBox)s).Content);
                cb.Margin = new Thickness(0, cb.Height * i, 0, 0);
                grid_favor_CB.Children.Add(cb);
            }

        }


        private void Cont_collect_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ContentUnit item in e.NewItems)
                {
              
                    Dispatcher.Invoke(new Action(() => { tb.Text += item.header + "\n" + item.description + "\n\n"; }));
                }
            }
        }



        private void Model_AuthorizationEvent(object sender, EventArgs e)
        {
            var args = (EventAuthorizationArgs)e;

            throw new NotImplementedException();
        }
    }
}
