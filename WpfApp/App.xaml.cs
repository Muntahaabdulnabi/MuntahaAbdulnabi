using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WebApi.Services;
using WpfApp.Contexts;
using WpfApp.Models.Entities;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? app { get; private set; }

        public App()
        {
            app = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddScoped<MainWindow>();
                services.AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\munta\\OneDrive\\Skrivbord\\cs\\InlämningsUppgift\\WpfApp\\Contexts\\wpf_local_sql_db.mdf;Integrated Security=True;Connect Timeout=30"));
                services.AddScoped<CustomerService>();            
            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await app!.StopAsync();
            var MainWindow = app.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
