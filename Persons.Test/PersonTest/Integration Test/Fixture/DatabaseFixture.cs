using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Persons.Application;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Infrastructure.Persistence.Context;
using Persons.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persons.Test.PersonTest.Integration_Test.Fixture
{
    public class DatabaseFixture : IDisposable
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMediator _mediator;

        public DatabaseFixture()
        {
            var services = new ServiceCollection()
                .AddApplication()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("TestDb"))
                .AddTransient<IApplicationDbContext, ApplicationDbContext>()
                .AddTransient<IPersonRepository, PersonRepository>()
                 .AddHttpContextAccessor();

            var serviceProvider = services.BuildServiceProvider();

            _context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
