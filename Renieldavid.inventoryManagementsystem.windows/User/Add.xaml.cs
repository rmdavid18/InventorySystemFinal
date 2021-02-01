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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window 
 {

            List myParentWindow = new List();
            public Add(List parentWindow)
            {
                InitializeComponent();
                myParentWindow = parentWindow;
            }

      

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var op = UserBLL.Add(new Models.User()
            {
                Id = Guid.NewGuid(),
                Firstname = txtFirstName.Text,
                Lastname = txtLastName.Text,
                EmailAddress = txtEmailAddress.Text,
               

            });

            if (op.Code != "200")
            {
                MessageBox.Show("Error : " + op.Message);
            }
            else
            {
                MessageBox.Show("Customer is successfully added to table");
            }

            myParentWindow.showData();
            this.Close();
        }
    }
    }





