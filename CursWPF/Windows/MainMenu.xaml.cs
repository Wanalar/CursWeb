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

namespace CursWPF
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public User User { get; set; }

        public MainMenu(User User)
        {
            InitializeComponent();
            DataContext = new MainMenuGuestVM(User);
        }

        

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Trip(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(User);
            mainMenu.Show();
            this.Close();
        }


    }
}
