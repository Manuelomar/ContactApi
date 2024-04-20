using Persons.Application.Common.GenericHandler;
using Persons.Application.PersonContactEntity.Dtos;
using Persons.Domain.Enum;

namespace Persons.Application.PersonContactEntity.Commands
{
    public class DeletePersonContactCommand : BaseCommand<PersonContactResponseDto>
    {
        public new Guid Id { get; set; }
        public DeletePersonContactCommand(Guid id)
        {
            Id = id;
            ActionType = ActionsTypes.Delete;
        }
    }
}
