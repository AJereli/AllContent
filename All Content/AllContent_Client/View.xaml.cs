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
    public partial class MainWindow : Window
    {
        Model model;
        public MainWindow()
        {
            InitializeComponent();

            User user = new User();
            if (user.Authorization("MyLogin", "MyPassword"))
            {
                user.AddFavoritSource("a");
                user.AddFavoritSource("http://www.w3schools.com/sql/sql_update.asp");



            }
        }
    }
}
