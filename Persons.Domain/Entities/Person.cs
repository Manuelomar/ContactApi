using Persons.Domain.Base;

namespace Persons.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public List<PersonContact> Contacts { get; set; } = new List<PersonContact>();
    }
}
