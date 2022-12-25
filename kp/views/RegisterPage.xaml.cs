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

namespace kp.views
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "insert into Users values (@login, @pass,2)";
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.Parameters.Add("@login", SqlDbType.VarChar, 50).Value = newlogin.Text;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = newpass.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы успешно зарегистрировались");
            NavigationService nav;
            nav = NavigationService.GetNavigationService(this);
            SignInPage nextPage = new SignInPage();
            nav.Navigate(nextPage);
        }
    }
}
