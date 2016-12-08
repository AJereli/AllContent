using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.Windows.Data;
using MySql.Data.MySqlClient;

namespace AllContent_Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainView : Page
    {


        FavoritList favorites;
        List<ContentUnit> all_content = new List<ContentUnit>();
        List<string> all_source { get; set; }
        static public User user { get; set; }
        public MainView()
        {
            InitializeComponent();
            favorites = new FavoritList();
            favorites.AddEvent += Favorites_AddEvent;
            favorites.DeleteEvent += Favorites_DeleteEvent;
            all_source = new List<string>();
            InitAllSource();
            user.LoadFavoritSources();
            foreach (var str in user.favoritSources)
                favorites.Add(str);
            lb_content.ItemsSource = all_content;
            InitCheckBoxs();

        }

        private void Favorites_DeleteEvent()
        {
            all_content = new List<ContentUnit>();
            foreach (var fav in favorites)
                all_content.AddRange(fav.content);
            lb_content.ItemsSource = all_content;
        }

        private void Favorites_AddEvent()
        {
            all_content = new List<ContentUnit>();
            foreach (var fav in favorites)
                all_content.AddRange(fav.content);
            lb_content.ItemsSource = all_content;

        }

        private void InitAllSource()
        {
            using (DBClient client = new DBClient())
            {
                string sources = client.SelectQuery("SELECT favorites_source FROM users WHERE login = @login", new MySqlParameter("login", "$sources"))[0];
                foreach (var str in sources.Split(';'))
                    if (str != "")
                        all_source.Add(str);
            }

        }

        private void InitCheckBoxs()
        {
            foreach (var str in all_source)
            {
                CheckBox cb = new CheckBox() { Height = 20, Width = 240, Content = str };
                if (user.favoritSources.Contains(str))
                    cb.IsChecked = true;
                cb.Checked += Cb_Checked;
                cb.Unchecked += Cb_Unchecked;
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = cb;
                lb_allSource.Items.Add(lbi);
            }
        }

        
        private void Cb_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            user.favoritSources.Remove((string)cb.Content);
            favorites.Delete((string)cb.Content);
            user.UpdateFavor();
        }

        private void Cb_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            user.favoritSources.Add((string)cb.Content);
            favorites.Add((string)cb.Content);
            user.UpdateFavor();
        }

        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("lil");
        }
    }
}
