using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persons.Application.Common.Extensions;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Application.Common.PaginationResponse;
using Persons.Application.PersonEntity.Dtos;
using Persons.Application.PersonEntity.Queries;

namespace Persons.Application.PersonEntity.Handlers.Queries
{
    public class GetFilteredPersonQueryHandler : IRequestHandler<GetFilteredPersonQuery, Paged<GetPersonDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public GetFilteredPersonQueryHandler(IMapper mapper, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<Paged<GetPersonDto>> Handle(GetFilteredPersonQuery request, CancellationToken cancellationToken)
        {
            var query = _personRepository.Query();

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(p => p.Cedula == request.Search);
            }

            var queryMapped = query
               .ProjectTo<GetPersonDto>(_mapper.ConfigurationProvider);

            var paginatedResult = await queryMapped
               .Paginate(request.PageNumber, request.PageSize, cancellationToken);

            return paginatedResult;
        }
    }
}