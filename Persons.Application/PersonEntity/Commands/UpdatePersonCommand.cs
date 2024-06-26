﻿using Persons.Application.Common.GenericHandler;
using Persons.Application.PersonEntity.Dtos;
using Persons.Domain.Enum;

namespace Persons.Application.PersonEntity.Commands
{
    public class UpdatePersonCommand : BaseCommand<PersonResponseDto>
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string? Cedula { get; set; } = string.Empty;
        public UpdatePersonCommand()
        {
            ActionType = ActionsTypes.Update;
        }

    }
}
