using CursLib.Models;
using CursWPF.ViewModels;
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

namespace CursWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListTickets.xaml
    /// </summary>
    public partial class ListTickets : Page
    {
        public User User { get; set; }
        

        public ListTickets(User user)
        {
            User = user;
            InitializeComponent();
            DataContext = new ListTicketsVM(user);
        }

        private void TicketOrder(object sender, RoutedEventArgs e)
        {
            TicketsOrder f = new TicketsOrder(User);
            f.Show();
        }
    }
}
