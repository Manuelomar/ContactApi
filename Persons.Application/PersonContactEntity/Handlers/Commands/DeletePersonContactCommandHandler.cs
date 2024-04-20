using AutoMapper;
using MediatR;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Application.PersonContactEntity.Commands;
using Persons.Application.PersonContactEntity.Dtos;

namespace Persons.Application.PersonContactEntity.Handlers.Commands
{
    public class DeletePersonContactCommandHandler : IRequestHandler<DeletePersonContactCommand, PersonContactResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IPersonContactRepository _personRepository;
        public DeletePersonContactCommandHandler(IPersonContactRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _personRepository = repository;
        }

        public async Task<PersonContactResponseDto> Handle(DeletePersonContactCommand request, CancellationToken cancellationToken)
        {
            var result = await _personRepository.Delete(request.Id);

            var dto = _mapper.Map<PersonContactResponseDto>(result);

            return dto;
        }
            
    }
}
