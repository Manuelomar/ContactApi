using Persons.Domain.Base;

namespace Persons.Domain.Entities
{
    public class PersonContact : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; } 
        public string ContactType { get; set; } = string.Empty; 
        public string ContactValue { get; set; } = string.Empty; 
    }
}
