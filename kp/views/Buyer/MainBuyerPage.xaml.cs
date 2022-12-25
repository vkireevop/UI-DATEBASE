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

namespace kp.views.Buyer
{
    /// <summary>
    /// Логика взаимодействия для MainBuyerPage.xaml
    /// </summary>
    public partial class MainBuyerPage : Page
    {
        public MainBuyerPage()
        {
            InitializeComponent();
        }

        private void Service_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServiceClientPage());
        }

        private void Staff_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffClientPage());
        }

        private void Request_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RequestBuyerPage());
        }
    }
}
