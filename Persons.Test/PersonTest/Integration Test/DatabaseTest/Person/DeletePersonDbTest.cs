using Persons.Application.PersonEntity.Commands;
using Persons.Test.PersonTest.Data;
using Persons.Test.PersonTest.Integration_Test.Fixture; 

namespace Persons.Test.PersonTest.Integration_Test.DatabaseTest.Person
{
    [Collection("Database collection")]
    public class DeletePersonDbTest : DatabaseFixture
    {
        [Fact]
        public async Task ShouldDeletePersonFromDatabase()
        {
            var person = PersonData.SinglePerson;
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            var deletePerson = new DeletePersonCommand(person.Id);
            await _mediator.Send(deletePerson, CancellationToken.None);

            var savedPerson = await _context.Persons.FindAsync(person.Id);
            Assert.Null(savedPerson); // Assuming that the person should be null after deletion
        }
    }
}
