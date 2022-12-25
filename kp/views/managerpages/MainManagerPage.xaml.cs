using kp.DataBase;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

using kp.views.managerpages;

namespace kp.views.managerpages
{
    /// <summary>
    /// Логика взаимодействия для MainManagerPage.xaml
    /// <
    public partial class MainManagerPage : Page
        {
    //    private BackgroundWorker backgroundWorker;
        public MainManagerPage()
        {
            
            InitializeComponent();
            Variables.Panel(login,type);
            //backgroundWorker = ((BackgroundWorker)this.FindResource("backgroundWorker"));
            //backgroundWorker.RunWorkerAsync();


        }

        //private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        //{

        //    Variables.GlobalCount = AppData.db.Request.Count();
        //    int count = Variables.GlobalCount;

        //    while (true)
        //    {
        //        Variables.GlobalCount = AppData.db.Request.Count();

        //        if (count < Variables.GlobalCount)
        //        {
        //            count += 1;
        //            MessageBox.Show("Скорее возьмите новую заявку");


        //        }
        //        else
        //        {

        //            continue;

        //        }
        //        AppData.db.Dispose();
        //        //Thread.Sleep();


        //    }

        //}
        private void Request_Click(object sender, RoutedEventArgs e)
        {
            //backgroundWorker.Dispose();
            RequestPage nav = new RequestPage();
            NavigationService.Navigate(nav);
            

        }

        private void FinishedRequest_Click(object sender, RoutedEventArgs e)
        {
            //backgroundWorker.Dispose();
            FinishedRequest nav = new FinishedRequest();
            NavigationService.Navigate(nav);
           
        }
    }
}
