using AutoMapper;
using Persons.Application.PersonContactEntity.Commands;
using Persons.Application.PersonContactEntity.Dtos;
using Persons.Domain.Entities;

namespace Persons.Application.PersonContactEntity.Mappings
{
    public class PersonContactMappingProfile : Profile
    {
        public PersonContactMappingProfile()
        {
            CreateMap<GetPersonContactByIdDto, PersonContact>().ReverseMap();
            CreateMap<PersonContactResponseDto, PersonContact>().ReverseMap();
            CreateMap<GetPersonContactDto, PersonContact>().ReverseMap();
            CreateMap<DeletePersonContactCommand, PersonContact>().ReverseMap();
            CreateMap<CreatePersonContactCommand, PersonContact>().ReverseMap();
        }
    }
}
