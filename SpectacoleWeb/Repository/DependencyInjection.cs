using Microsoft.EntityFrameworkCore;
using SpectacoleWeb.Areas.Identity.Data;
using SpectacoleWeb.Business_Logic;
using SpectacoleWeb.Controllers;
using SpectacoleWeb.Data;
using SpectacoleWeb.Models;

namespace SpectacoleWeb.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string connection, string identityConnection)
        {
            services.AddTransient<IShowRepository, ShowRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IIdentityUserRepository, IdentityUserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ShowService>();
            services.AddTransient<TicketService>();
            services.AddTransient<UserService>();
            services.AddTransient<IdentityUserService>();
            services.AddTransient<UsersController>();
            services.AddTransient<TicketsController>();
            services.AddTransient<TicketsAPIController>();
            services.AddTransient<IdentityUserController>();
            services.AddDbContext<SpectacoleWebIdentityDbContext>(options => options.UseSqlServer(identityConnection));
            services.AddDbContext<SpectacoleWebContext>(options => options.UseSqlServer(connection));
            return services;
        }
    }
}
