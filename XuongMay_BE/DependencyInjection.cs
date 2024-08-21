using XuongMay_BE.Repositories.DataContext;
using Microsoft.EntityFrameworkCore;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Services.Service;
using XuongMay_BE.Services;
using Microsoft.AspNetCore.Identity;
using XuongMay_BE.Contract.Repositories.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace XuongMay_BE
{
    public static class DependencyInjection
    {
        public static void AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigRoute();
            services.AddDatabase(configuration);
            services.AddIdentity();
            services.AddModifiedAuthentication(configuration);
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
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
        }

        public static void AddModifiedAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IAccountService, AccountService>();
        }
    }
}
