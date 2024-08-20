using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XuongMay_BE.Contract.Repositories.IUnitOfWork;
using XuongMay_BE.Repositories.UnitOfWork;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Services.Service;

namespace XuongMay_BE.Services
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();
            services.AddServices(); // Đăng ký các service tại đây
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            // Đăng ký thêm các service khác nếu có
        }
    }
}
