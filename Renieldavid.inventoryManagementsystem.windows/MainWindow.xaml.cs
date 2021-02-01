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
using Renieldavid.inventoryManagementsystem.windows.DAL;
using Renieldavid.inventoryManagementsystem.windows.Models;

namespace Renieldavid.inventoryManagementsystem.windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
       {
           InitializeComponent();
            /* DBContext context = new DBContext();

           var User = context.Users.FirstOrDefault();
            if (User != null) 
            {
                MessageBox.Show(User.EmailAddress);
            }*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User.List listWindow = new User.List();
            listWindow.Show();
        }
    }
}
