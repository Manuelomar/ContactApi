using Persons.Domain.Base;

namespace Persons.Domain.Entities
{
    public class PersonContact : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; } = null!; 
        public string Email { get; set; } = string.Empty; 
        public string Address { get; set; } = string.Empty; 
        public string Phone { get; set; } = string.Empty; 
        public string Mobile { get; set; } = string.Empty;

    }
}
