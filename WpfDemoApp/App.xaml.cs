using System;
using System.IO;
using System.Windows;

using AutoMapper;

using GameStore.BLL.Classes;
using GameStore.BLL.Interfaces;
using GameStore.BLL.Mapping;
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

            var viewModel = serviceProvider.GetService<MainPageViewModel>();
            MainWindow mainWindow = new MainWindow(viewModel);
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            var options = new DbContextOptionsBuilder().UseSqlServer(
                Configuration.GetConnectionString(ConstantsHelper.DatabaseName));

            services.AddTransient(s => new GameStoreContext(options.Options));
            services.AddTransient<Repository<GameStoreContext, Game>>();           
            services.AddTransient<IGamesService, GamesService>();
            services.AddTransient<MainPageViewModel>();
        }
    }
}
