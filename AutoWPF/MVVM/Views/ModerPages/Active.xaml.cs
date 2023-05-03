using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using AutoWPF.DataBase;

namespace AutoWPF.MVVM.Views.ModerPages
{
    /// <summary>
    /// Логика взаимодействия для Active.xaml
    /// </summary>
    public partial class Active : Page
    {
        public Active()
        {
            InitializeComponent();
            //Variables.Panel(Почта, post);
            SqlConnection connection = new SqlConnection(@"Data Source=AMG03; Initial Catalog=Geology2; Integrated Security=True");

            connection.Open();
            string cmd = "SELECT * FROM Активности";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Активности");
            dataAdp.Fill(dt);
            ActiveGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=AMG03;Initial Catalog=Active;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string command2 = "insert into Активности values (@ID, @Наименование_Активности, @Дата_начала, @Дни, @Активность, @День, @Время_начала, @Модератор, @Id_Жюри1, @IdЖюри2, @IdЖюри3, @IdЖюри4, @IdЖюри5)";
            SqlCommand cmd = new SqlCommand(command2, connection);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 40).Value = AddID.Text;
            cmd.Parameters.Add("@Наименование_Активности", SqlDbType.Float).Value = AddActName.Text;
            cmd.Parameters.Add("@Дата_начала", SqlDbType.Float).Value = AddDate.Text;
            cmd.Parameters.Add("@Дни", SqlDbType.Float).Value = AddDays.Text;
            cmd.Parameters.Add("@Активность", SqlDbType.VarChar, 50).Value = AddAct.Text;
            cmd.Parameters.Add("@День", SqlDbType.VarChar, 40).Value = AddDay.Text;
            cmd.Parameters.Add("@Время_начала", SqlDbType.VarChar, 40).Value = Addtime.Text;
            cmd.Parameters.Add("@IdЖюри1", SqlDbType.VarChar, 40).Value = Addid1.Text;
            cmd.Parameters.Add("@IdЖюри2", SqlDbType.VarChar, 40).Value = Addid2.Text;
            cmd.Parameters.Add("@IdЖюри3", SqlDbType.VarChar, 40).Value = Addid3.Text;
            cmd.Parameters.Add("@IdЖюри4", SqlDbType.VarChar, 40).Value = Addid4.Text;
            cmd.Parameters.Add("@IdЖюри45", SqlDbType.VarChar, 40).Value = Addid5.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Вы успешно добавили запись");
            Wind.Visibility = Visibility.Hidden;
            ActiveGrid.ItemsSource = null;
            ActiveGrid.ItemsSource = AppData.db.Активность.ToList();
        }
        private void EvButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EventPage());
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PartiPage());
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Wind.Visibility = Visibility.Visible;
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Auto nav = new Auto();
            NavigationService.Navigate(nav);
        }
    }
}
