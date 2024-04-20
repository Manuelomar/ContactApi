using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persons.Application.Common.Extensions;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Application.Common.PaginationResponse;
using Persons.Application.PersonContactEntity.Dtos;
using Persons.Application.PersonContactEntity.Queries;
using Persons.Application.PersonEntity.Dtos;
using Persons.Application.PersonEntity.Queries;

namespace Persons.Application.PersonContactEntity.Handlers.Queries
{
    public class GetFilteredPersonContactQueryHandler : IRequestHandler<GetFilteredPersonContactQuery, Paged<GetPersonContactDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPersonContactRepository _contactRepository;

        public GetFilteredPersonContactQueryHandler( IMapper mapper, IPersonContactRepository personContactRepository)
        {
            _mapper = mapper;
            _contactRepository = personContactRepository;
        }

        public async Task<Paged<GetPersonContactDto>> Handle(GetFilteredPersonContactQuery request, CancellationToken cancellationToken)
        {
            var query = _contactRepository.Query();

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(p => p.Mobile == request.Search);
            }

            var queryMapped = query
               .ProjectTo<GetPersonContactDto>(_mapper.ConfigurationProvider);

            var paginatedResult = await queryMapped
               .Paginate(request.PageNumber, request.PageSize, cancellationToken);

            return paginatedResult;
        }
    }
}
