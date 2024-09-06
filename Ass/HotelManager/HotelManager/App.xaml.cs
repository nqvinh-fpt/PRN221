using HotelManager.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace HotelManager
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
            service.AddSingleton<HotelManagerContext>();
            provider = service.BuildServiceProvider();
        }

        
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = provider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }

}
