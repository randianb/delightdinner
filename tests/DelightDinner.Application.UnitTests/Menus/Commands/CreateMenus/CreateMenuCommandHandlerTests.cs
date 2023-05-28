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

    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateMenu(CreateMenuCommand createMenuCommand)
    {
        // Act
        var result = await _handler.Handle(createMenuCommand, default);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepository.Verify(m => m.AddAsync(result.Value), Times.Once);
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new object[] 
        { 
            CreateMenuCommandUtils.CreateCommand() 
        };

        yield return new object[] 
        { 
            CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionsCommand(3)) 
        };

        yield return new object[]
        {
            CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateSectionsCommand(
                sectionCount: 3,
                items: CreateMenuCommandUtils.CreateItemsCommand(itemCount: 3)))
        };
    }
}