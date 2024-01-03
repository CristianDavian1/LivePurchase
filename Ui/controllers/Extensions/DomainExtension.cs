using Business.Domain.UserDomain;
using DataAcces.Repositorie;

namespace Ui.Controllers.Extensions
{
    public static class DomainExtension
    {
        public static void IncludeDomain(this WebApplicationBuilder services)
        {
            services.Services.AddScoped<IUserDomain, UserDomain>();
            services.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}