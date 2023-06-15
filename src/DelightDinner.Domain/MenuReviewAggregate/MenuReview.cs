using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Common.ValueObjects;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.GuestAggregate.ValueObjects;
using DelightDinner.Domain.HostAggregate.ValueObjects;
using DelightDinner.Domain.MenuAggregate.MenuObjects;
using DelightDinner.Domain.MenuReviewAggregate.Events;
using DelightDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace DelightDinner.Domain.MenuReviewAggregate;

public sealed class MenuReview : AggregateRoot<MenuReviewId, Guid>
{
    public Rating Rating { get; private set; }
    public string Comment { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public GuestId GuestId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private MenuReview(
        MenuReviewId menuReviewId,
        Rating rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static MenuReview Create(
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updateDateTime,
        MenuReviewId? menuReviewId = null)
    {
        // TODO: enforce invariants
        var ratingValueObject = Rating.Create(rating);

        var menuReview = new MenuReview(
            menuReviewId ?? MenuReviewId.CreateUnique(),
            ratingValueObject,
            comment,
            hostId,
            menuId,            
            guestId,
            dinnerId,
            createdDateTime,
            updateDateTime);

        menuReview.AddDomainEvent(new MenuReviewCreated(menuReview));

        return menuReview;
    }
#pragma warning disable CS8618
    private MenuReview()
    {
    }
#pragma warning restore CS8618
}