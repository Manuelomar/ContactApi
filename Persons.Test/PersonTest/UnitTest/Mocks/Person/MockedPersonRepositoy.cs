using MockQueryable.Moq;
using Moq;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Domain.Entities;
using Persons.Test.PersonTest.Data;

namespace Persons.Test.PersonTest.UnitTests.Mocks
{
    public class MockedPersonRepository
    {
        private static IQueryable<Person> queryablePersons = PersonData.ListPersons.AsQueryable();

        public static Mock<IPersonRepository> GetPersonRepositoryMock()
        {
            var mockRepository = new Mock<IPersonRepository>();

            // Setup for querying all persons
            mockRepository.Setup(repo => repo.Query())
                .Returns(queryablePersons.BuildMock());

            // Setup for retrieving a person by ID
            mockRepository.Setup(repo => repo.Get(It.IsAny<Guid>()))
                .Returns<Guid>((id) => Task.FromResult(queryablePersons.FirstOrDefault(p => p.Id == id)));

            // Setup for adding a person
            mockRepository.Setup(repo => repo.Add(It.IsAny<Person>()))
                .Callback((Person person) =>
                {
                    // Simulate adding by updating the ID to a new GUID if it's empty
                    if (person.Id == Guid.Empty) person.Id = Guid.NewGuid();
                    PersonData.ListPersons.Add(person);
                })
                .Returns<Person>((person) => Task.FromResult(person));

            // Setup for updating a person
            mockRepository.Setup(repo => repo.Update(It.IsAny<Person>()))
                .Callback((Person person) =>
                {
                    // Simulate updating by replacing the person with the same ID
                    var index = PersonData.ListPersons.FindIndex(p => p.Id == person.Id);
                    if (index != -1) PersonData.ListPersons[index] = person;
                })
                .Returns<Person>((person) => Task.FromResult(person));

            // Setup for deleting a person
            mockRepository.Setup(repo => repo.Delete(It.IsAny<Guid>()))
                .Callback<Guid>((id) =>
                {
                    // Simulate deletion
                    var personToRemove = PersonData.ListPersons.FirstOrDefault(p => p.Id == id);
                    if (personToRemove != null) PersonData.ListPersons.Remove(personToRemove);
                })
                .Returns<Guid>((id) => Task.FromResult(PersonData.ListPersons.FirstOrDefault(p => p.Id == id)));

            return mockRepository;
        }
    }
}
