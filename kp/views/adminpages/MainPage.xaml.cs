using kp.views.adminpages;
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

namespace kp.views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
           
        }
        private void Staff_Click(object sender, RoutedEventArgs e)
        {
         
            StuffPage nav = new StuffPage();
            NavigationService.Navigate(nav);
        }
        private void service_Click(object sender, RoutedEventArgs e)
        {
            ServicePage nav = new ServicePage();
            NavigationService.Navigate(nav);
        }
        private void client_Click(object sender, RoutedEventArgs e)
        {
            ClientsPage nav = new ClientsPage();
            NavigationService.Navigate(nav);
        }
        private void User_Click(object sender, RoutedEventArgs e)
        {
            UsersPage nav = new UsersPage();
            NavigationService.Navigate(nav);
        }
    }
}
