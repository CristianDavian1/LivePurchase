using Business.Domain.UserDomain;
using DataAcces.Repositorie;
using DataAcces.ModelsDb;

namespace Ui.Controllers.Extensions
{
    public static class DomainExtension
    {
        public static void IncludeDomain(this WebApplicationBuilder services)
        {
            services.Services.AddScoped<IUserDomain, UserDomain>();
            services.Services.AddScoped<IUserRepository, UserRepository>();
            services.Services.AddScoped<LivePurchaseContext, LivePurchaseContext>();
        }
    }
}