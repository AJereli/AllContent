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
    /// Логика взаимодействия для AuthorizWin.xaml
    /// </summary>
    public partial class AuthorizWin : Window
    {
        bool first_Login_Focus = true;
        NavigationWindow win;
        User user;
        Frame frame;
        public AuthorizWin()
        {
            InitializeComponent();
            Height = 550;
            Width = 300;
            button.Click += Button_Click;
            Loaded += AuthorizPage_Loaded;
        }

        private void AuthorizPage_Loaded(object sender, RoutedEventArgs e)
        {
            win = (NavigationWindow)Window.GetWindow(this);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text.Length <= 3 || passwordBox.Password.Length <= 3)
            {
                infoLable.Content = "Слишком короткий логин или пароль";
                return;
            }
            user = new User();
            try
            {
                if (user.Authorization(loginBox.Text, passwordBox.Password))
                {
                    Model.user = this.user;
                  
                    
                }
                else
                    infoLable.Content = "Неверный логин или пароль";

            }
            catch (MySql.Data.MySqlClient.MySqlException exp)
            {
                if (exp.Number == 1024)
                    infoLable.Content = "Проблемы с подключением";
            }
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (first_Login_Focus)
                loginBox.Text = "";
            first_Login_Focus = false;
        }
    }
}
