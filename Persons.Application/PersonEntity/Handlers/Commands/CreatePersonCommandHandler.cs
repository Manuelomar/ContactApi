using AutoMapper;
using Persons.Application.Common.Exceptions;
using Persons.Application.Common.GenericHandler;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Application.Common.Interfaces.UnitOfWork;
using Persons.Application.GenericHandler;
using Persons.Application.PersonEntity.Commands;
using Persons.Application.PersonEntity.Dtos;
using Persons.Domain.Entities;
namespace Persons.Application.PersonEntity.Handlers.Commands
{
    public class CreatePersonCommandHandler : BaseCommandHandler<CreatePersonCommand, Person, PersonResponseDto>
    {

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper, IUnitOfWork unitOfWork):base(personRepository, mapper, unitOfWork)
        {

        }


    }

}
