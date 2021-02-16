using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<GloboTicketDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GloblaticketManagementConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEventRepository, EventRepository>();
            return services;
        }
    }
}