using Persons.Domain.BaseResponses;

namespace Persons.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public BaseResponse Response { get; }

        public NotFoundException(string entityName, Guid id)
          : base($"{entityName} with id {id} not found")
        {
            Response = BaseResponse.NotFound(Message);
        }
    }
}
