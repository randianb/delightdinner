using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.DinnerAggregate.Events;
using DelightDinner.Domain.MenuAggregate;

using MediatR;

namespace DelightDinner.Application.Menus.Events;

public class DinnerCreatedEventHandler : INotificationHandler<DinnerCreated>
{
    private readonly IMenuRepository _menuRepository;

    public DinnerCreatedEventHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task Handle(DinnerCreated dinnerCreatedEvent, CancellationToken cancellationToken)
    {
        if (await _menuRepository.GetByIdAsync(dinnerCreatedEvent.Dinner.MenuId) is not Menu menu)
        {
            throw new InvalidOperationException($"Dinner has invalid menu id (dinner id: {dinnerCreatedEvent.Dinner.Id}, menu id: {dinnerCreatedEvent.Dinner.MenuId}).");
        }

        menu.AddDinnerId((DinnerId)dinnerCreatedEvent.Dinner.Id);

        await _menuRepository.UpdateAsync(menu);
    }
}