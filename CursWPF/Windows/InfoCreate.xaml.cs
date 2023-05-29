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
    /// Логика взаимодействия для InfoCreate.xaml
    /// </summary>
    public partial class InfoCreate : Window
    {
        public InfoCreate()
        {
            InitializeComponent();
            DataContext = new MainMenuInfoVM();
            
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
