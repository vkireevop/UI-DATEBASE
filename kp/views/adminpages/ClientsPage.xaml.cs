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

namespace kp.views.adminpages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dialog.Visibility = Visibility.Hidden;
            AddDialog.Visibility = Visibility.Hidden;
            StaffGrid.ItemsSource = AppData.db.Clients.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            dialog.Visibility = Visibility.Visible;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddDialog.Visibility = Visibility.Visible;
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "select * from Group_Clients";
            SqlDataAdapter DataAdapter = new SqlDataAdapter(command, connection);
            DataSet ds = new DataSet();
            DataAdapter.Fill(ds, "Group_Services");
            comboBox1.ItemsSource = ds.Tables[0].DefaultView;
            comboBox1.DisplayMemberPath = ds.Tables[0].Columns["name"].ToString();
            comboBox1.SelectedValuePath = ds.Tables[0].Columns["id"].ToString();
        }

        private void deletestroke_Click(object sender, RoutedEventArgs e)
        {
            dialog.Visibility = Visibility.Visible;
            int Id = Convert.ToInt32(IdToDelete.Text);
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "delete from Clients where id = @id";
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы удалили запись");
            dialog.Visibility = Visibility.Hidden;
            StaffGrid.ItemsSource = null;
            StaffGrid.ItemsSource = AppData.db.Clients.ToList();
        }

        private void cancelDelete_Click(object sender, RoutedEventArgs e)
        {
            dialog.Visibility = Visibility.Hidden;
        }

        private void AcceptAdd_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command2 = "insert into Clients values (@login,@name,@surname,@phone,@condition)";
            SqlCommand cmd = new SqlCommand(command2, connection);
            cmd.Parameters.Add("@login", SqlDbType.VarChar, 40).Value = AddLogin.Text;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 40).Value = AddName.Text;
            cmd.Parameters.Add("@surname", SqlDbType.VarChar, 40).Value = AddSurname.Text;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar, 50).Value = AddPhone.Text;
            cmd.Parameters.Add("@condition", SqlDbType.VarChar, 50).Value = comboBox1.SelectedValue;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы успешно добавили запись");
            AddDialog.Visibility = Visibility.Hidden;
            StaffGrid.ItemsSource = null;
            StaffGrid.ItemsSource = AppData.db.Clients.ToList();
        }

        private void CancelAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDialog.Visibility = Visibility.Hidden;
        }
    }
}
