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
    /// Логика взаимодействия для TicketsOrder.xaml
    /// </summary>
    public partial class TicketsOrder : Window
    {
        public User User { get; set; }

        public TicketsOrder(User user)
        {
            
            InitializeComponent();
            DataContext = new TicketsOrderVM(user);
        }
        


    }
}
