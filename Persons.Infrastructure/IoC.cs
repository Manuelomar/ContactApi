using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persons.Infrastructure.Persistence.Context;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Infrastructure.Persistence.Repositories;
using Persons.Infrastructure.Persistence.UnitOfWorks;
using Persons.Application.Common.Interfaces.UnitOfWork;

namespace Persons.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPersonRepository, PersonRepository>(); 
            services.AddScoped<IPersonContactRepository, PersonContactRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
