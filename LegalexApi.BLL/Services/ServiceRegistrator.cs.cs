using LegalexApi.BLL.Services.TelegramService;
using LegalexApi.DAL;
using LegalexApi.DAL.Models;
using LegalexApi.DAL.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace LegalexApi.BLL.Services
{
    public static class ServiceRegistrator
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Transient);
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddTelegramService(this IServiceCollection services, string chatId, string ApiToken)
        {
            services.AddTransient<ITelegramSender>(provider => new TelegramSender(chatId, ApiToken));
        }
    }
}
