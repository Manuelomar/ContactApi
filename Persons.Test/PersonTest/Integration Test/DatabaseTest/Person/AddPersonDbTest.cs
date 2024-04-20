using Persons.Test.PersonTest.Data;
using Persons.Test.PersonTest.Integration_Test.Fixture;

namespace Persons.Test.PersonTest.Integration_Test.DatabaseTest.Person
{
    [Collection("Database collection")]
    public class AddPersonDbTest : DatabaseFixture
    {
        [Fact]
        public async Task ShouldAddPersonContactToDatabase()
        {
            // Arrange
            var personCommand = PersonData.CreatePersonCommand;

            // Act
            await _mediator.Send(personCommand, CancellationToken.None);

            // Assert
            var savedPerson = await _context.Persons.FindAsync(personCommand.Id);
            Assert.NotNull(savedPerson);
            Assert.Equal(personCommand.Id, savedPerson.Id);
            Assert.Equal(personCommand.LastName, savedPerson.LastName);
            Assert.Equal(personCommand.BirthDate, savedPerson.BirthDate);

        }
    }
}
