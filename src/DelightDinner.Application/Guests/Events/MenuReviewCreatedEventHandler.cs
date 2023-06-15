using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.MenuReviewAggregate.Events;
using DelightDinner.Domain.GuestAggregate;

using MediatR;
using DelightDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace DelightDinner.Application.Guests.Events;

public class MenuReviewCreatedEventHandler : INotificationHandler<MenuReviewCreated>
{
    private readonly IGuestRepository _guestRepository;

    public MenuReviewCreatedEventHandler(IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }

    public async Task Handle(
        MenuReviewCreated menuReviewCreatedEvent, 
        CancellationToken cancellationToken)
    {
        if (await _guestRepository.GetByIdAsync(menuReviewCreatedEvent.MenuReview.GuestId) is not Guest guest)
        {
            throw new InvalidOperationException($"MenuReview has invalid guest id (menuReview id: {menuReviewCreatedEvent.MenuReview.Id}, guest id: {menuReviewCreatedEvent.MenuReview.GuestId}).");
        }

        guest.AddMenuReviewId((MenuReviewId)menuReviewCreatedEvent.MenuReview.Id);

        await _guestRepository.UpdateAsync(guest);
    }
}