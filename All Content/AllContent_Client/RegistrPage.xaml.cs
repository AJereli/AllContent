using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrPage.xaml
    /// </summary>
    public partial class RegistrPage : Page
    {
        public RegistrPage()
        {
            InitializeComponent();
            tb_login.GotFocus += Tb_GotFocus;
            tb_email.GotFocus += Tb_GotFocus;
            tb_password.GotFocus += Tb_GotFocus;
            ok_button.Click += Ok_button_Click;
        }

        private void Ok_button_Click(object sender, RoutedEventArgs e)
        {
            Regex email_exp = new Regex("^([a-z0-9_-]+\\.)*[a-z0-9_-]+@[a-z0-9_-]+(\\.[a-z0-9_-]+)*\\.[a-z]{2,6}$");
            if (tb_login.Text.Length < 4)
                label_info.Content = "Не менее 4 символов в логине";
            else if (tb_password.Text == "Password")
                label_info.Content = "Слово Password - плохой пароль";
            else if (tb_password.Text.Length < 4)
                label_info.Content = "Не менее 4 символов в пароле";
            else if (!email_exp.IsMatch(tb_email.Text))
                label_info.Content = "Некорректный email";
            else
            {
                if (!User.Registration(tb_login.Text, tb_password.Text, tb_email.Text))
                    label_info.Content = "Данный логин уже занят";
                else
                    NavigationService.GoBack();
            }
                    
        }

        private void Tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Login" || tb.Text == "Password" || tb.Text == "Email")
                tb.Text = "";
        }
    }
}
