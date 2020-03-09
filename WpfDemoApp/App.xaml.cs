using System;
using System.IO;
using System.Windows;

using GameStore.DAL;
using GameStore.DAL.Models;
using GameStore.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WpfDemoApp.Constants;
using WpfDemoApp.ViewModels;

namespace WpfDemoApp
{
    public partial class App : Application
    {
        public IConfiguration Configuration { get; private set; }

        public App()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()    
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile(
                                            ConstantsHelper.AppSettings, 
                                            optional: false, 
                                            reloadOnChange: true);

            Configuration = builder.Build();

            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var viewModel = new MainPageViewModel(
                serviceProvider.GetRequiredService<Repository<GameStoreContext, Game>>());
            MainWindow mainWindow = new MainWindow(viewModel);
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            var options = new DbContextOptionsBuilder().UseSqlServer(
                Configuration.GetConnectionString(ConstantsHelper.DatabaseName));

            services.AddTransient(s => new GameStoreContext(options.Options));
            services.AddTransient<Repository<GameStoreContext, Game>>();
        }
    }
}
