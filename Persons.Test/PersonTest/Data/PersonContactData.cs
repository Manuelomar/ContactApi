using Bogus;
using Persons.Application.PersonContactEntity.Commands;
using Persons.Domain.Entities;

namespace Persons.Test.PersonTest.Data
{
    public static class PersonContactData
    {
        public static PersonContact SinglePersonContact { get; } = new Faker<PersonContact>()
            .RuleFor(pc => pc.Id, f => f.Random.Guid())
            .RuleFor(pc => pc.PersonId, f => f.Random.Guid())
            .RuleFor(pc => pc.Email, f => f.Internet.Email())
            .RuleFor(pc => pc.Address, f => f.Address.FullAddress())
            .RuleFor(pc => pc.Phone, f => f.Phone.PhoneNumber("###-###-####"))
            .RuleFor(pc => pc.Mobile, f => f.Phone.PhoneNumber("###-###-####"))
            .Generate();

        public static List<PersonContact> ListPersonContacts { get; } = new Faker<PersonContact>()
            .RuleFor(pc => pc.Id, f => f.Random.Guid())
            .RuleFor(pc => pc.PersonId, f => f.Random.Guid())
            .RuleFor(pc => pc.Email, f => f.Internet.Email())
            .RuleFor(pc => pc.Address, f => f.Address.FullAddress())
            .RuleFor(pc => pc.Phone, f => f.Phone.PhoneNumber("###-###-####"))
            .RuleFor(pc => pc.Mobile, f => f.Phone.PhoneNumber("###-###-####"))
            .Generate(10);

        #region Commands
        public static CreatePersonContactCommand CreatePersonContactCommand { get; } = new Faker<CreatePersonContactCommand>()
            .RuleFor(pc => pc.PersonId, f => f.Random.Guid())
            .RuleFor(pc => pc.Email, f => f.Internet.Email())
            .RuleFor(pc => pc.Address, f => f.Address.FullAddress())
            .RuleFor(pc => pc.Phone, f => f.Phone.PhoneNumber("###-###-####"))
            .RuleFor(pc => pc.Mobile, f => f.Phone.PhoneNumber("###-###-####"))
            .Generate();

        public static UpdatePersonContactCommand UpdatePersonContactCommand { get; } = new Faker<UpdatePersonContactCommand>()
            .RuleFor(pc => pc.Email, f => f.Internet.Email())
            .RuleFor(pc => pc.Address, f => f.Address.FullAddress())
            .RuleFor(pc => pc.Phone, f => f.Phone.PhoneNumber("###-###-####"))
            .RuleFor(pc => pc.Mobile, f => f.Phone.PhoneNumber("###-###-####"))
            .Generate();

        public static DeletePersonContactCommand DeletePersonContactCommand(Guid contactId)
        {
            return new DeletePersonContactCommand(contactId);
        }
        #endregion
    }
}
