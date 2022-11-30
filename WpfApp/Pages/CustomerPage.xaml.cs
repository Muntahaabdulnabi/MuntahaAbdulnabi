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
using WpfApp.Services;

namespace WpfApp.Pages
{
    public partial class CustomerPage : Page
    {

        public CustomerPage()
        {
            InitializeComponent();
        }

        private async void btn_save_Click(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:7020/api/customers", new CustomerCreateModel
            {
                FirstName = tb_firstName.Text,
                LastName = tb_lastName.Text,
                Email = tb_email.Text,
                Phone = tb_phone.Text,
                Address = tb_address.Text,
            }); 

            tb_firstName.Text = String.Empty;
            tb_lastName.Text = String.Empty;
            tb_email.Text = String.Empty;
            tb_phone.Text = String.Empty;
            tb_address.Text = String.Empty;
        }
    }
}
