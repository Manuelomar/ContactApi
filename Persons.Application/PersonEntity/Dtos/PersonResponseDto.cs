using Persons.Domain.Entities;

namespace Persons.Application.PersonEntity.Dtos
{
    public class PersonResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public List<PersonContact> Contacts { get; set; } = new List<PersonContact>();
    }
}
