using AutoMapper;
using Moq;
using Persons.Application.Common.Interfaces.Repositories;
using Persons.Application.Common.Interfaces.UnitOfWork;
using Persons.Application.PersonEntity.Commands;
using Persons.Application.PersonEntity.Dtos;
using Persons.Application.PersonEntity.Handlers.Commands;


namespace Person.Tests.Handlers.Commands
{
    public class CreatePersonCommandHandlerTests
    {
        private readonly Mock<IPersonRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly CreatePersonCommandHandler _handler;

        public CreatePersonCommandHandlerTests()
        {
            _repositoryMock = new Mock<IPersonRepository>();
            _mapperMock = new Mock<IMapper>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new CreatePersonCommandHandler(_repositoryMock.Object, _mapperMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ReturnsPersonResponseDto_WhenCommandIsValid()
        {
            // Arrange
            var command = new CreatePersonCommand { FirstName = "John", LastName = "Doe" };
            var person = new Person();
            var dto = new PersonResponseDto();
            _repositoryMock.Setup(x => x.AddAsync(It.IsAny<Person>())).ReturnsAsync(person);
            _mapperMock.Setup(x => x.Map<PersonResponseDto>(It.IsAny<Person>())).Returns(dto);

            // Act
            var result = await _handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dto, result);
        }

        // Similar tests for UpdatePersonCommandHandler and DeletePersonCommandHandler
    }
}
