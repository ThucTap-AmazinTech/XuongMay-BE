using XuongMay_BE.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Services.Service;
using XuongMay_BE.Services;

namespace XuongMay_BE
{
    public static class DependencyInjection
    {
        public static void AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigRoute();
            services.AddDatabase(configuration);
            services.AddIdentity();
            services.AddInfrastructure(configuration);
            services.AddServices();
        }

        public static void ConfigRoute(this IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });
        }

        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("DbConnect"), b => b.MigrationsAssembly("XuongMay_BE"));
            });
        }
        
        public static void AddIdentity(this  IServiceCollection services)
        {
            ;
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
