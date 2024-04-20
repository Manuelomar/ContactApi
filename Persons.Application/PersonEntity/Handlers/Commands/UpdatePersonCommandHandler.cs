using AutoMapper;
using MediatR;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Application.PersonEntity.Commands;
using Persons.Application.PersonEntity.Dtos;
using Persons.Domain.Entities;
using Persons.Domain.Enum;

namespace Persons.Application.PersonEntity.Handlers.Commands
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, PersonResponseDto>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<PersonResponseDto> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            if (request.ActionType != ActionsTypes.Update)
                throw new ArgumentException($"Action Type '{request.ActionType}' is not supported, you can only Update");

            var user = _mapper.Map<Person>(request);
            _mapper.Map(request, user);
            var result = await _personRepository.Update(user);

            var dto = _mapper.Map<PersonResponseDto>(result);
            return dto;
        }
    }
}
