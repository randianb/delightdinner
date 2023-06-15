using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.MenuAggregate;
using DelightDinner.Domain.MenuReviewAggregate.Events;
using DelightDinner.Domain.MenuReviewAggregate.ValueObjects;

using MediatR;

namespace DelightDinner.Application.Menus.Events;

public class MenuReviewCreatedEventHandler : INotificationHandler<MenuReviewCreated>
{
    private readonly IMenuRepository _menuRepository;

    public MenuReviewCreatedEventHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task Handle(
        MenuReviewCreated menuReviewCreatedEvent, 
        CancellationToken cancellationToken)
    {
        if (await _menuRepository.GetByIdAsync(menuReviewCreatedEvent.MenuReview.MenuId) is not Menu menu)
        {
            throw new InvalidOperationException($"MenuReview has invalid menu id (menuReview id: {menuReviewCreatedEvent.MenuReview.Id}, menu id: {menuReviewCreatedEvent.MenuReview.MenuId}).");
        }

        menu.AddMenuReviewId((MenuReviewId)menuReviewCreatedEvent.MenuReview.Id);

        await _menuRepository.UpdateAsync(menu);
    }
}