using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.DinnerAggregate;
using DelightDinner.Domain.Menu.MenuObjects;
using DelightDinner.Domain.Common.Errors;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;

using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Dinners.Commands.CreateDinner;

public class CreateDinnerCommandHandler 
    : IRequestHandler<CreateDinnerCommand, ErrorOr<Dinner>>
{
    private readonly IDinnerRepository _dinnerRepository;
    private readonly IMenuRepository _menuRepository;

    public CreateDinnerCommandHandler(
        IMenuRepository menuRepository, 
        IDinnerRepository dinnerRepository)
    {
        _menuRepository = menuRepository;
        _dinnerRepository = dinnerRepository;
    }

    public async Task<ErrorOr<Dinner>> Handle(
        CreateDinnerCommand command, 
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var createMenuIdResult = MenuId.Create(command.MenuId);

        if (createMenuIdResult.IsError)
        {
            return createMenuIdResult.Errors;
        }

        if (!await _menuRepository.ExistsAsync(createMenuIdResult.Value))
        {
            return Errors.Menu.NotFound;
        }

        var dinner = Dinner.Create(
            command.Name,
            command.Description,
            command.StartDateTime,
            command.EndDateTime,
            command.IsPublic,
            command.MaxGuests,
            Price.Create(
                command.Price.Amount,
                command.Price.Currency),            
            HostId.Create(command.HostId),
            createMenuIdResult.Value,
            command.ImageUrl,
            Location.Create(
                command.Location.Name,
                command.Location.Address,
                command.Location.Latitude,
                command.Location.Longtitude));

        await _dinnerRepository.AddAsync(dinner);

        return dinner;
    }
}