using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; set; }   
        public IConfiguration Configuration { get; set; }
        private ServiceProvider provider;
        public App()
        {
            var service = new ServiceCollection();
            service.AddSingleton<MainWindow>();
            service.AddSingleton<PRN221_Spr22Context>();
            provider = service.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = provider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
