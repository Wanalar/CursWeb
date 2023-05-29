using CursLib.Models;
using CursWPF.ViewModels;
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

namespace CursWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainMenuEmployee.xaml
    /// </summary>
    public partial class MainMenuEmployee : Window
    {
        public User User { get; set; }

        public MainMenuEmployee(CursLib.Models.User user)
        {
            User= user;
            InitializeComponent();
            DataContext = new MainMenuGuestVM(user);
        }

        private void AddTrip(object sender, RoutedEventArgs e)
        {
            TripsCreate f = new TripsCreate(User);
            f.Show();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Trip(object sender, RoutedEventArgs e)
        {
            MainMenuEmployee mainmenuemployee = new MainMenuEmployee(User);
            mainmenuemployee.Show();
            this.Close();
        }


    }
}
