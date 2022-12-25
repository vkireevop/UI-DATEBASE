using kp.DataBase;
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
    /// Логика взаимодействия для StaffClientPage.xaml
    /// </summary>
    public partial class StaffClientPage : Page
    {
        public StaffClientPage()
        {
            InitializeComponent();
            var cureentlist = AppData.db.Staff.ToList();
            LVReqest.ItemsSource = cureentlist;
        }

        private void ToRequest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RequestBuyerPage());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
