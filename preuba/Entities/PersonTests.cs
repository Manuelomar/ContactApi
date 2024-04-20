using Persons.Application.PersonEntity.Dtos;


namespace Person.Tests.Entities
{
    public class PersonTests
    {
        [Fact]
        public void Constructor_InitializesContacts()
        {
            var person = new Person();
            Assert.NotNull(person.Contacts);
            Assert.Empty(person.Contacts);
        }
    }

    public class PersonDtoTests
    {
        [Fact]
        public void Constructor_InitializesFields()
        {
            var dto = new GetPersonDto();
            Assert.Equal(string.Empty, dto.FirstName);
            Assert.Empty(dto.Contacts);
        }
    }
}
