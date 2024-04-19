using Persons.Application.Common.Interfaces.Repositories;
using Persons.Domain.Entities;
using Persons.Infrastructure.Persistence.Context;

namespace Persons.Infrastructure.Persistence.Repositories
{
    public class PersonContactRepository : BaseRepository<PersonContact>, IPersonContactRepository
    {
        public PersonContactRepository(IApplicationDbContext context) : base(context)
        {
        }
    }
}
