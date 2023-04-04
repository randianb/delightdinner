using DelightDinner.Domain.Menu;

using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Menus.Commands.CreateMenu;
public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    public Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        // Create Menu
        // Persist Menu
        // Return Menu

        return default;
    }
}