using MediatR;
using Persons.Application.Common.PaginationQuery;
using Persons.Application.Common.PaginationResponse;
using Persons.Application.PersonEntity.Dtos;

namespace Persons.Application.PersonEntity.Queries
{
    public class GetFilteredPersonQuery : IRequest<Paged<GetPersonDto>>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetFilteredPersonQuery(PaginationQuery query)
        {
            Search = query.Search;
            PageSize = query.PageSize;
            PageNumber = query.PageNumber;
        }
    }
}
