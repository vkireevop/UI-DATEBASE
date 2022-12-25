
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
    /// Логика взаимодействия для RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        public RequestPage()
        {
            InitializeComponent();
            var cureentlist = AppData.db.Request.Where(p=>p.finished==false && p.staff== Variables.idStuff ).ToList();
            LVReqest.ItemsSource = cureentlist;
            Variables.Panel(login,type);
        }
        private void Completed_Click(object sender, RoutedEventArgs e)
        {
            
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "update Request set finished = 'true' where id = @id";
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value =Convert.ToInt32( index.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы приняли заявку");
            LVReqest.ItemsSource=null;
            LVReqest.ItemsSource = AppData.db.Request.Where(p => p.finished == false && p.staff == Variables.idStuff).ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
           

        }

    }
}
