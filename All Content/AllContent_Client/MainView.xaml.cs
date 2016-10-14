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
    public partial class MainView : Window
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
            

        }

        private void Button_refresh_favor_Click(object sender, RoutedEventArgs e)
        {
            model.RefreshAllContent();
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
