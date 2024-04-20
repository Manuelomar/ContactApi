using MediatR;
using Persons.Application.Common.PaginationQuery;
using Persons.Application.Common.PaginationResponse;
using Persons.Application.PersonContactEntity.Dtos;

namespace Persons.Application.PersonContactEntity.Queries
{
    public class GetFilteredPersonContactQuery : IRequest<Paged<GetPersonContactDto>>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetFilteredPersonContactQuery(PaginationQuery query)
        {
            Search = query.Search;
            PageSize = query.PageSize;
            PageNumber = query.PageNumber;
        }
    }
}
