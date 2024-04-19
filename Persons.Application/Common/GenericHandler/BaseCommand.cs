using MediatR;
using Persons.Domain.Enum;
using System.Text.Json.Serialization;

namespace Persons.Application.Common.GenericHandler
{
    public class BaseCommand<TResponse> : IRequest<TResponse> where TResponse : class
    {
        [JsonIgnore]

        public virtual ActionsTypes ActionType { get; set; }
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
