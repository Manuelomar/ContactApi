using AutoMapper;
using Persons.Application.PersonEntity.Commands;
using Persons.Application.PersonEntity.Dtos;
using Persons.Domain.Entities;

namespace Persons.Application.PersonEntity.Mappings
{
    public class PersonMappingProfile : Profile
    {
        public  PersonMappingProfile()
        {
            CreateMap<GetPersonByIdDto, Person>().ReverseMap();
            CreateMap<PersonResponseDto, Person>().ReverseMap();
            CreateMap<GetPersonDto, Person>().ReverseMap();
            CreateMap<DeletePersonCommand, Person>().ReverseMap();
            CreateMap<CreatePersonCommand, Person>().ReverseMap();
        }
    }
}
