using Microsoft.EntityFrameworkCore;
using Persons.Test.PersonTest.Data;
using Persons.Test.PersonTest.Integration_Test.Fixture;

namespace Persons.Test.PersonTest.Integration_Test.DatabaseTest.PersonContact
{
    [Collection("Database collection")]
    public class AddContactDbTest : DatabaseFixture
    {
        [Fact]
        public async Task ShouldAddPersonContactToDatabase()
        {
            // Arrange
            var personContactCommand = PersonContactData.CreatePersonContactCommand;

            // Act
            await _mediator.Send(personContactCommand, CancellationToken.None);

            // Assert
            var savedPersonContact = await _context.Contacts.FindAsync(personContactCommand.Id);
            Assert.NotNull(savedPersonContact);
            Assert.Equal(personContactCommand.Id, savedPersonContact.Id);
            Assert.Equal(personContactCommand.PersonId, savedPersonContact.PersonId);
            Assert.Equal(personContactCommand.Email, savedPersonContact.Email);
            Assert.Equal(personContactCommand.Address, savedPersonContact.Address);
            Assert.Equal(personContactCommand.Phone, savedPersonContact.Phone);
            Assert.Equal(personContactCommand.Mobile, savedPersonContact.Mobile);
        }
    }
}