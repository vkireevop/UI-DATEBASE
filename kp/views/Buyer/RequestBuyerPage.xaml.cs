
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace kp.views.Buyer
{
    /// <summary>
    /// Логика взаимодействия для RequestBuyerPage.xaml
    /// </summary>
    public partial class RequestBuyerPage : Page
    {
        public RequestBuyerPage()
        {
            InitializeComponent();
            Variables.Panel(login, type);
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "select * from Staff";
            SqlDataAdapter DataAdapter = new SqlDataAdapter(command, connection);
            DataSet ds = new DataSet();
            DataAdapter.Fill(ds, "Staff");
            Staff.ItemsSource = ds.Tables[0].DefaultView;
            Staff.DisplayMemberPath = ds.Tables[0].Columns["surname"].ToString();
            Staff.SelectedValuePath = ds.Tables[0].Columns["id"].ToString();
            string command1 = "select * from Services";
            SqlDataAdapter DataAdapter1 = new SqlDataAdapter(command1, connection);
            DataSet ds1 = new DataSet();
            DataAdapter1.Fill(ds1, "Services");
            Service.ItemsSource = ds1.Tables[0].DefaultView;
            Service.DisplayMemberPath = ds1.Tables[0].Columns["name"].ToString();
            Service.SelectedValuePath = ds1.Tables[0].Columns["id"].ToString();

        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "insert into Request values (@client,@staff,@service,@cost,@sale,'False')";
            SqlCommand cmd = new SqlCommand(command, connection);
            float sale;
            if (Variables.Vip == true)
            {
                sale = 10;
            }
            else
            sale = 0;
            cmd.Parameters.Add("@client", SqlDbType.Int).Value = Variables.iduser;
            cmd.Parameters.Add("@staff", SqlDbType.Int).Value = Staff.SelectedValue;
            cmd.Parameters.Add("@service", SqlDbType.Int).Value = Service.SelectedValue;
            cmd.Parameters.Add("@cost", SqlDbType.Float).Value = CalculateCost2();
            cmd.Parameters.Add("@sale", SqlDbType.Float).Value = sale;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы оформилили заявку");
        }

        public void CalculateCost_Click(object sender, RoutedEventArgs e)
        {
            CalculateCost();
            
        }
        private float CalculateCost()
            {
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "Select cost from Services where id = @id";
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Service.SelectedValue;
            float cost = Convert.ToSingle(cmd.ExecuteScalar());
            Variables.Vip = true;
            if (Variables.Vip == true)
            {
                float Result = cost + cost * 0.1f;
                MessageBox.Show("Стоимость: " + Result + " Руб");
                return Result;
            }
            else
            {
                MessageBox.Show("Стоимость: " + cost + "Руб");
                return cost;
            }
        }
        private float CalculateCost2()
        {
            string connectionString = @"Data Source=VADIM;Initial Catalog=KP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command = "Select cost from Services where id = @id";
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Service.SelectedValue;
            float cost = Convert.ToSingle(cmd.ExecuteScalar());
            Variables.Vip = true;
            if (Variables.Vip == true)
            {
                float Result = cost + cost * 0.1f;
                
                return Result;
            }
            else
            {
                
                return cost;
            }

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }
    }
}
