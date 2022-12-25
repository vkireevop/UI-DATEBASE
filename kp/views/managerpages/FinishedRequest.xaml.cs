using kp.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace kp.views.managerpages
{
    /// <summary>
    /// Логика взаимодействия для FinishedRequest.xaml
    /// </summary>
    public partial class FinishedRequest : Page
    {
        public FinishedRequest()
        {
            InitializeComponent();
            var cureentlist = AppData.db.Request.Where(p => p.finished == true && p.staff == Variables.idStuff).ToList();
            LVReqest.ItemsSource = cureentlist;
            Variables.Panel(login,type);
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}
