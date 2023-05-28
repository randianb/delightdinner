using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Application.Menus.Commands.CreateMenu;
using DelightDinner.Application.UnitTests.Menus.Commands.TestUtils;
using DelightDinner.Application.UnitTests.TestUtils.Menus.Extensions;

using FluentAssertions;
using Moq;

namespace DelightDinner.Application.UnitTests.Menus.Commands.CreateMenus;

public class CreateMenuCommandHandlerTests
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepository;

    public CreateMenuCommandHandlerTests()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
    }

    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateMenu()
    {
        // Arrange
        // Create the command
        var createMenuCommand = CreateMenuCommandUtils.CreateCommand();

        // Act
        // Invoke the handler
        var result = await _handler.Handle(createMenuCommand, default);

        // Assert
        result.IsError.Should().BeFalse();

        result.Value.ValidateCreatedFrom(createMenuCommand);
    }
}