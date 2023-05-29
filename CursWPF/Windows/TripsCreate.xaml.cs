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
    /// Логика взаимодействия для TripsCreate.xaml
    /// </summary>
    public partial class TripsCreate : Window
    {
        public TripsCreate(User user)
        {
            InitializeComponent();
            DataContext = new MainMenuGuestVM(user);
        }
    }
}
