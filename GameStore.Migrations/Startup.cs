using GameStore.Migrations.Context;
using GameStore.Migrations.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.Migrations
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString(MigrationConstants.DefaultConnection);

            services.AddDbContext<BaseContext>(options =>
                options.UseSqlServer(connectionString));
        }

        public void Configure()
        {
        }
    }
}
