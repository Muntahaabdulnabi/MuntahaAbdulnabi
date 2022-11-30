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
using WpfApp.Contexts;
using WpfApp.Services;

namespace WpfApp.Pages
{
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        private async void btn_product_save_Click(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:7020/api/products", new ProductCreateModel
            {
                Name = tb_name.Text,
                Description = tb_description.Text,
                Price = decimal.Parse(tb_price.Text)

            });
            tb_name.Text = String.Empty;
            tb_description.Text = String.Empty;
            tb_price.Text = String.Empty;
        }
    }
}
