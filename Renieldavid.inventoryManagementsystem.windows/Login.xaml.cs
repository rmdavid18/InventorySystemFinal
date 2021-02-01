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
using Renieldavid.inventoryManagementsystem.windows.BLL;
using Renieldavid.inventoryManagementsystem.windows.Helpers;

namespace Renieldavid.inventoryManagementsystem.windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrEmpty(txtEmailAddress.Text))
                {
                    MessageBox.Show("Invalid Login");
                };

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Invalid Login");
                };

                var op = UserBLL.Login(txtEmailAddress.Text, txtPassword.Text);

                if (op.Code == "200")
                {
                    var user = UserBLL.GetbyId(op.ReferenceId);

                    ProgramUser.Id = user.Id;

                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Login");
                }

            }


        }
    }
}