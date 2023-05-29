using CursLib.Models;
using CursWPF.Tools;
using CursWPF.Windows;
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

namespace CursWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Registration_Button(object sender, MouseButtonEventArgs e)
        {
            Registration r = new Registration();
            r.Show();
            this.Close();
        }

        
        public User User { get; set; }
        private async void btn_sign(object sender, RoutedEventArgs e)
        {

            var json = await HttpApi.Post("Users", "Auth", new Auth { Login = textBox_login.Text, Password = passBox_password.Password });
            User result = HttpApi.Deserialize<User>(json);
            User = result; 

            {

                if (result.Role == 1)
                {
                    MainMenuEmployee m = new MainMenuEmployee(User);
                    m.Show();
                    this.Close();
                }

                else if (result.Role == 3)
                {
                    MainMenu m = new MainMenu(User);
                    m.Show();
                    this.Close();
                }

                else if (result.Role == 2)
                {
                    MainMenuInfo m = new MainMenuInfo();
                    m.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Неверно!", "Аккаунта не существет!!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
