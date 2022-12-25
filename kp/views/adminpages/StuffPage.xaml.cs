using kp.DataBase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace kp.views.adminpages
{
    /// <summary>
    /// Логика взаимодействия для StuffPage.xaml
    /// </summary>
    public partial class StuffPage : Page
    {
        public StuffPage()
        {
            InitializeComponent();
            dialog.Visibility = Visibility.Hidden;
            AddDialog.Visibility = Visibility.Hidden;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StaffGrid.ItemsSource = AppData.db.Staff.ToList();

        }

        private void Buttonback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Buttondelete_Click(object sender, RoutedEventArgs e)
        {
            dialog.Visibility = Visibility.Visible;
        }
        private void Buttonadd_Click(object sender, RoutedEventArgs e)
        {
            AddDialog.Visibility = Visibility.Visible;
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "select * from Group_Staff";
            SqlDataAdapter DataAdapter = new SqlDataAdapter(command, connection);
            DataSet ds = new DataSet();
            DataAdapter.Fill(ds, "Group_Staff");
            comboBox1.ItemsSource = ds.Tables[0].DefaultView;
            comboBox1.DisplayMemberPath = ds.Tables[0].Columns["name"].ToString();
            comboBox1.SelectedValuePath = ds.Tables[0].Columns["id"].ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dialog.Visibility=Visibility.Visible;
            int Id = Convert.ToInt32(IdToDelete.Text);
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "delete from Staff where id = @id";
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы удалили запись");
            dialog.Visibility = Visibility.Hidden;
            StaffGrid.ItemsSource = null;
            StaffGrid.ItemsSource = AppData.db.Staff.ToList();
        }

        private void AcceptAdd_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command2 = "insert into Staff values (@login,@name,@surname,@phone,@condition)";
            SqlCommand cmd = new SqlCommand(command2, connection);
            cmd.Parameters.Add("@login", SqlDbType.VarChar, 50).Value = AddLogin.Text;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 40).Value = AddName.Text;
            cmd.Parameters.Add("@surname", SqlDbType.VarChar, 40).Value = AddSurname.Text;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar, 40).Value = AddPhone.Text;
            cmd.Parameters.Add("@condition", SqlDbType.Int).Value = comboBox1.SelectedValue;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы успешно добавили запись");
            AddDialog.Visibility = Visibility.Hidden;
            StaffGrid.ItemsSource = null;
            StaffGrid.ItemsSource = AppData.db.Staff.ToList();
        }

        private void cancelDelete_Click(object sender, RoutedEventArgs e)
        {
            dialog.Visibility=Visibility.Hidden;

        }

        private void cancelAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDialog.Visibility=Visibility.Hidden;
        }
    }
}
