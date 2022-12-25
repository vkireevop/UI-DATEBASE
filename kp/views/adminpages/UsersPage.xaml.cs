﻿using kp.DataBase;
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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dialog.Visibility = Visibility.Hidden;
            AddDialog.Visibility = Visibility.Hidden;
            StaffGrid.ItemsSource = AppData.db.Users.ToList();
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
            string command = "select * from Roles";
            SqlDataAdapter DataAdapter = new SqlDataAdapter(command, connection);
            DataSet ds = new DataSet();
            DataAdapter.Fill(ds, "Group_Services");
            comboBox1.ItemsSource = ds.Tables[0].DefaultView;
            comboBox1.DisplayMemberPath = ds.Tables[0].Columns["name_role"].ToString();
            comboBox1.SelectedValuePath = ds.Tables[0].Columns["id_role"].ToString();
        }

        private void deletestroke_Click(object sender, RoutedEventArgs e)
        {
            dialog.Visibility = Visibility.Visible;
            int Id = Convert.ToInt32(IdToDelete.Text);
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "delete from Users  where id_user = @id";
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы удалили запись");
            dialog.Visibility = Visibility.Hidden;
            StaffGrid.ItemsSource = null;
            StaffGrid.ItemsSource = AppData.db.Users.ToList();
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
            string command2 = "insert into Users values (@login,@pass,@role)";
            SqlCommand cmd = new SqlCommand(command2, connection);
            cmd.Parameters.Add("@login", SqlDbType.VarChar, 50).Value = AddLogin.Text;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = AddPass.Text;
            cmd.Parameters.Add("@role", SqlDbType.Int).Value = Convert.ToInt32(comboBox1.SelectedValue);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы успешно добавили запись");
            AddDialog.Visibility = Visibility.Hidden;
            StaffGrid.ItemsSource = null;
            StaffGrid.ItemsSource = AppData.db.Users.ToList();
        }

        private void CancelAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDialog.Visibility = Visibility.Hidden;
        }
    }
}
