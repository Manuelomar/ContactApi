using Persons.Application.Common.GenericHandler;
using Persons.Application.PersonEntity.Dtos;
using Persons.Domain.Entities;

namespace Persons.Application.PersonEntity.Commands
{
    public class CreatePersonCommand : BaseCommand<PersonResponseDto>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
