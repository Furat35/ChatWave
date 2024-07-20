using ChatWave.Application.Persistence;
using ChatWave.Application.Persistence.Repository;
using ChatWave.Application.UnitOfWorks;
using ChatWave.Infrastructure.Persistence;
using ChatWave.Infrastructure.Persistence.Repository;
using ChatWave.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatWave.Infrastructure.Extensions
{
    public static class RegisterInfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddDbContext<ChatWaveDbContext>(_ => _.UseSqlServer(configuration.GetConnectionString("EfChatWaveConnectionString")));

            // Business Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
