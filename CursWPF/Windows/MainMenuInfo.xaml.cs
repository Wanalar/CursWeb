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
    /// Логика взаимодействия для MainMenuInfo.xaml
    /// </summary>
    public partial class MainMenuInfo : Window
    {
        public MainMenuInfo()
        {
            InitializeComponent();
            DataContext = new MainMenuInfoVM();
        }

        private void AddInfo(object sender, RoutedEventArgs e)
        {
            InfoCreate f = new InfoCreate();
            f.Show();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            MainMenuInfo mainmenuinfo = new MainMenuInfo();
            mainmenuinfo.Show();
            this.Close();
        }
    }

}
