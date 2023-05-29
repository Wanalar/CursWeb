using CursLib.Models;
using CursWPF.Tools;
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
using System.Windows.Shapes;

namespace CursWPF
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration 
    {
        public User User { get; set; }
        public Registration()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Back(object sender, MouseButtonEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private async void Register(object sender, RoutedEventArgs e)
        {
            var json = await HttpApi.Post("Users", "SaveUser", new User
            {
                FirstName = txt_Name.Text,
                SecondName = txt_LastName.Text,
                Patronymic = txt_PatronomycName.Text,
                PhonNumber = long.Parse(txt_Phone.Text),
                Email = txt_Email.Text,
                Login = txt_Login.Text,
                Password = txt_Password.Text,
                Role = 3

            });
            User result = HttpApi.Deserialize<User>(json);
            User= result;


            MainMenu m = new MainMenu(User);
            m.Show();
            this.Close();


            


        }
    }
}
