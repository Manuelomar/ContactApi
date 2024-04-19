using Persons.Application.Common.GenericHandler;
using Persons.Application.PersonEntity.Dtos;
using Persons.Domain.Enum;

namespace Persons.Application.PersonEntity.Commands
{
    public class DeletePersonCommand : BaseCommand<PersonResponseDto>
    {
        public new Guid Id { get; set; }
        public DeletePersonCommand(Guid id)
        {
            Id = id;
            ActionType = ActionsTypes.Delete;
        }
    }
}
