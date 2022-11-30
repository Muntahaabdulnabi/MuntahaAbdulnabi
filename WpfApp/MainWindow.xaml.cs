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
using WebApi.Models;
using WebApi.Services;
using WpfApp.Pages;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btn_productPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ProductPage();
        }

        private void btn_customerPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CustomerPage();
        }

        private void btn_orderPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new OrderPage();
        }
    }
}
