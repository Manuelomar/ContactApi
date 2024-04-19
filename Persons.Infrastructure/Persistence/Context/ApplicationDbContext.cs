using Microsoft.EntityFrameworkCore;
using Persons.Domain.Entities;

namespace Persons.Infrastructure.Persistence.Context
{
    public interface IApplicationDbContext : IDbContext { }

    public class ApplicationDbContext : BaseDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options
            ) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonContact> Contacts { get; set; }


    }


}
