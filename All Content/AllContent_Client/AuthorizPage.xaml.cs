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
    /// Логика взаимодействия для AuthorizPage.xaml
    /// </summary>
    public partial class AuthorizPage : Page
    {
        public AuthorizPage()
        {
            InitializeComponent();
           // ShowsNavigationUI = true;
            WindowHeight = 550;
            WindowWidth = 300;
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
