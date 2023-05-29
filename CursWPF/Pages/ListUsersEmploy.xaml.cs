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
    /// Логика взаимодействия для ListUsersEmploy.xaml
    /// </summary>
    public partial class ListUsersEmploy : Page
    {
        public ListUsersEmploy()
        {
            InitializeComponent();
            DataContext = new ListUserVM();

            
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            AddUsers a = new AddUsers();
            a.Show();
        }
    }
}
