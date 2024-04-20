using Bogus;
using Persons.Application.PersonEntity.Commands;
using Persons.Domain.Entities;
using Person = Persons.Domain.Entities.Person;


namespace Persons.Test.PersonTest.Data
{
    public static class PersonData
    {
        public static Person SinglePerson { get; } = new Faker<Person>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.BirthDate, f => f.Date.Past(30))
            .RuleFor(p => p.Cedula, f => f.Random.Replace("###-#######-#"))
            .RuleFor(p => p.Contacts, new List<PersonContact>()) // Assuming PersonContact can be an empty list or you can create some fake contacts here.
            .Generate();

        public static List<Person> ListPersons { get; } = new Faker<Person>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.BirthDate, f => f.Date.Past(30))
            .RuleFor(p => p.Cedula, f => f.Random.Replace("###-#######-#"))
            .RuleFor(p => p.Contacts, new List<PersonContact>()) // Same here for contacts.
            .Generate(10);

        #region Commands
        public static CreatePersonCommand CreatePersonCommand { get; } = new Faker<CreatePersonCommand>()
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.BirthDate, f => f.Date.Past(30))
            .RuleFor(p => p.Cedula, f => f.Random.Replace("###-#######-#"))
            .Generate();

        public static UpdatePersonCommand UpdatePersonCommand { get; } = new Faker<UpdatePersonCommand>()
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.BirthDate, f => f.Date.Past(30))
            .RuleFor(p => p.Cedula, f => f.Random.Replace("###-#######-#"))
            .Generate();

        public static UpdatePersonCommand GetUpdatePersonCommand(Guid personId)
        {
            return new Faker<UpdatePersonCommand>()
                .RuleFor(p => p.Id, f => personId)
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.BirthDate, f => f.Date.Past(30))
                .RuleFor(p => p.Cedula, f => f.Random.Replace("###-#######-#"))
                .Generate();
        }

        public static DeletePersonCommand DeletePersonCommand(Guid personId)
        {
            return new DeletePersonCommand(personId);
        }
        #endregion
    }
}
