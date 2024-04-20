using Persons.Application.Common.GenericHandler;
using Persons.Application.PersonContactEntity.Dtos;

namespace Persons.Application.PersonContactEntity.Commands
{
    public class UpdatePersonContactCommand : BaseCommand<PersonContactResponseDto>
    {
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
    }
}
