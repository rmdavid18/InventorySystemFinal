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
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : Window
    {
        private string sortBy = "lastname";
        private string sortOrder = "asc";
        private string keyword = "";
        private int pageSize = 5;
        private int pageIndex = 1;
        private long pageCount = 1;
        public List()
        {
            InitializeComponent();
            cboSortBy.ItemsSource = new List<string>() { "FirstName", "LastName" };
            cboSortOrder.ItemsSource = new List<string>() { "Ascending", "Descending" };
        }


            public void showData()
            {
                var Users = UserBLL.Search(pageIndex, pageSize, sortBy, sortOrder, keyword);

                dgUsers.ItemsSource = Users.Items;
                pageCount = Users.PageCount;
            }

            private void txtPageSize_TextChanged(object sender, TextChangedEventArgs e)
            {
                if (txtPageSize.Text.Length > 0)
                {
                    int.TryParse(txtPageSize.Text, out pageSize);
                    showData();
                }


            }

            private void btnLast_Click(object sender, RoutedEventArgs e)
            {
                pageIndex = (int)pageCount;
                showData();
            }

            private void txtSearch_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Return)
                {
                    keyword = txtSearch.Text;
                    showData();
                }
            }

            private void btnFirst_Click(object sender, RoutedEventArgs e)
            {
                pageIndex = 1;
                showData();
            }

            private void btnPrev_Click(object sender, RoutedEventArgs e)
            {
                pageIndex = pageIndex - 1;
                if (pageIndex < 1)
                {
                    pageIndex = 1;
                };
                showData();
            }

            private void btnNext_Click(object sender, RoutedEventArgs e)
            {
                pageIndex = pageIndex + 1;
                if (pageIndex > pageCount)
                {
                    pageIndex = (int)pageCount;
                };
                showData();
            }

            private void cboSortOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (cboSortOrder.SelectedValue.ToString().ToLower() == "ascending")
                {
                    sortOrder = "asc";
                }
                else
                {
                    sortOrder = "desc";
                }
                showData();
            }

        private void cboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            {
                sortBy = cboSortBy.SelectedValue.ToString();
                showData();
            }

        }

        private void cboSortOrder_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            {
                if (cboSortOrder.SelectedValue.ToString().ToLower() == "ascending")
                {
                    sortOrder = "asc";
                }
                else
                {
                    sortOrder = "desc";
                }
                showData();
            }


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            {
                Add addWindow = new Add(this);
                addWindow.Show();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            {
                Models.User Users = ((FrameworkElement)sender).DataContext as Models.User;
                Update updateForm = new Update(Users, this);
                updateForm.Show();
            }
        }
    }
}
