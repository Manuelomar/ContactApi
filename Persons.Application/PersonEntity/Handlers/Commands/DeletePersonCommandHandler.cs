using AutoMapper;
using MediatR;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Application.PersonEntity.Commands;
using Persons.Application.PersonEntity.Dtos;

namespace Persons.Application.PersonEntity.Handlers.Commands
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, PersonResponseDto>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public DeletePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<PersonResponseDto> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var result = await _personRepository.Delete(request.Id);

            var dto = _mapper.Map<PersonResponseDto>(result);

            return dto;
        }
    }
}
