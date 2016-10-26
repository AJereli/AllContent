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
    public partial class MainView : Page
    {


        static public event EventHandler RefreshContent = delegate { };

        Model model;

        public MainView()
        {
            model = new Model();
            model.AuthorizationEvent += Model_AuthorizationEvent;
            Model.content_collect.CollectionChanged += Cont_collect_CollectionChanged;
            InitializeComponent();
            button_refresh_favor.Click += Button_refresh_favor_Click;
            WindowHeight = Height;
            WindowWidth = Width;
            InitAllSource();
        }


        private void InitAllSource()
        {
            int i = 0;
            foreach (var str in Model.user.favorites.all_favotits)
            {
                CheckBox source_box = new CheckBox();
                source_box.Content = str;
                source_box.Width = 150;
                source_box.Height = 20;
                source_box.Margin = new Thickness(0, 25*i, 0, 0);
                if (Model.user.favorites.CheckForSelected(str))
                    source_box.IsChecked = true;
                source_box.Checked += Source_box_Checked;
                source_box.Unchecked += Source_box_Unchecked;
               
                grid_favor_CB.Children.Add(source_box);
                i++;

            }

        }

        private void Source_box_Unchecked(object sender, RoutedEventArgs e)
        {
            string source = (string)((CheckBox)sender).Content;
            Model.user.favorites.Delete(source, source);
            model.RefreshAllContent();
        }

        private void Source_box_Checked(object sender, RoutedEventArgs e)
        {

            string source = (string)((CheckBox)sender).Content;
            Model.user.favorites.Add(source, source);
            model.RefreshAllContent();
        }

        private void Button_refresh_favor_Click(object sender, RoutedEventArgs e)
        {
            
        }




        private void Cont_collect_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ContentUnit item in e.NewItems)
                {

                    Dispatcher.Invoke(new Action(() => { tb.Text += item.header + "\n" + item.description + "\n\n"; }));
                }
            }else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (ContentUnit cu in e.NewItems)
                {
                    tb.Text = "";
                    Dispatcher.Invoke(new Action(() => { tb.Text += cu.header + "\n" + cu.description + "\n\n"; }));
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
