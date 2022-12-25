
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
using System.Data.SqlClient;
using System.Data;
using kp.DataBase;
using kp.views.managerpages;
using kp.views.Buyer;

namespace kp.views
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
            
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = AppData.db.Users.FirstOrDefault(u => u.login == login.Text && u.pass == password.Text);

            if (CurrentUser == null)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            else
            {
                Variables.TypeUser = CheckTypeUser(login.Text);
                MessageBox.Show("Вы авторизовались как: " + Variables.TypeUser);
                Variables.GlobalLogin = login.Text;
                if (Variables.TypeUser == "Администратор")
                {
                    NavigationService nav;
                    nav = NavigationService.GetNavigationService(this);
                    MainPage nextPage = new MainPage();
                    nav.Navigate(nextPage);
                }
                else if (Variables.TypeUser == "Покупатель")
                {
                    Variables.Vip = CheckVipUser(login.Text);
                    string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    string command = "select id from Clients where login = @login";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.Parameters.Add("@login", SqlDbType.VarChar, 50).Value = login.Text;
                    Variables.iduser = Convert.ToInt32(cmd.ExecuteScalar());
                    NavigationService nav;
                    nav = NavigationService.GetNavigationService(this);
                    MainBuyerPage nextPage = new MainBuyerPage();
                    nav.Navigate(nextPage);

                }
                else if (Variables.TypeUser == "Менеджер")
                {
                    string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    string command = "select id from Staff where login = @login";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.Parameters.Add("@login", SqlDbType.VarChar, 50).Value = login.Text;
                    Variables.idStuff = Convert.ToInt32(cmd.ExecuteScalar());
                    NavigationService nav;
                    nav = NavigationService.GetNavigationService(this);
                    MainManagerPage nextPage = new MainManagerPage();
                    nav.Navigate(nextPage);
                }
            }
      
        }
       public string CheckTypeUser(string login)
        {
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "select name_role from Roles left join Users on role_id = id_role where login = @login";
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.Parameters.Add("@login", SqlDbType.VarChar, 50).Value = login;
            string result = Convert.ToString(cmd.ExecuteScalar());     
            return result;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            nav = NavigationService.GetNavigationService(this);
            RegisterPage nextPage = new RegisterPage();
            nav.Navigate(nextPage);
        }
        static bool CheckVipUser(string login)
        {
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "select condition from Clients where login = @login";
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.Parameters.Add("@login", SqlDbType.NVarChar,50).Value = login;
            int a = Convert.ToInt32(cmd.ExecuteScalar()) ;
            if (a == 1)
            {
                return true;
            }
            else
            return false;
        }
    }
}
