using Persons.Application.Common.Interfaces.Repositories;
using Persons.Domain.Entities;
using Persons.Infrastructure.Persistence.Context;

namespace Persons.Infrastructure.Persistence.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IApplicationDbContext context) : base(context)
        {
        }
    }
}
