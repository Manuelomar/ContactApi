using AutoMapper;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Application.Common.Interfaces.UnitOfWork;
using Persons.Application.GenericHandler;
using Persons.Application.PersonContactEntity.Commands;
using Persons.Application.PersonContactEntity.Dtos;
using Persons.Domain.Entities;

namespace Persons.Application.PersonContactEntity.Handlers.Commands
{
    public class CreatePersonContactCommandHandler : BaseCommandHandler<CreatePersonContactCommand, PersonContact, PersonContactResponseDto>
    {
        public CreatePersonContactCommandHandler(IPersonContactRepository personContactService, IMapper mapper, IUnitOfWork unitOfWork) : base(personContactService, mapper, unitOfWork)
        {
        }
    }
}
