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

namespace Renieldavid.inventoryManagementsystem.windows.User
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>

        public partial class Update : Window
        {
            List myParentWindow = new List();
            private Models.User thisUser;
            public Update(Models.User customer, List parentWindow)
            {
                InitializeComponent();
                myParentWindow = parentWindow;
                thisUser = customer;

                txtFirstName.Text = thisUser.Firstname;
                txtLastName.Text = thisUser.Lastname;
                txtEmailAddress.Text = thisUser.EmailAddress;
            }

            private void btnCancel_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }

            private void btnAdd_Click(object sender, RoutedEventArgs e)
            {
                var op = UserBLL.Update(new Models.User()
                {

                    Id = thisUser.Id,
                    EmailAddress = txtEmailAddress.Text,
                    Firstname = txtFirstName.Text,
                    Lastname = txtLastName.Text,

                });

                if (op.Code != "200")
                {
                    MessageBox.Show("Error : " + op.Message);
                }
                else
                {
                    MessageBox.Show("Employee is successfully updated");
                }

                myParentWindow.showData();
                this.Close();
            }

        }
    }

