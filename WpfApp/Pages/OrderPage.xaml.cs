using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

namespace WpfApp.Pages
{
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        
        

        private async void btn_order_save_Click_1(object sender, RoutedEventArgs e)
        {

            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:7020/api/orders", new OrderCreateModel
            {
                CustomerName = tb_customerName.Text,
                CreatedDate = DateTime.Parse(tb_createdDate.Text),
                DueDate = DateTime.Parse(tb_dueDate.Text),
                StreetName = tb_streetName.Text,
                StreetNumber = tb_streetNumber.Text
            });

            tb_customerName.Text = String.Empty;
            tb_createdDate.Text = String.Empty;
            tb_dueDate.Text = String.Empty;
            tb_streetName.Text = String.Empty;
            tb_streetNumber.Text = String.Empty;
            tb_postalCode.Text = String.Empty;
            tb_city.Text = String.Empty;
            tb_totalprice.Text = String.Empty;
        }
    }
}
