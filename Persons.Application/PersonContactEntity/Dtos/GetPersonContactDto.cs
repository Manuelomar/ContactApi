namespace Persons.Application.PersonContactEntity.Dtos
{
    public class GetPersonContactDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;

    }
}
