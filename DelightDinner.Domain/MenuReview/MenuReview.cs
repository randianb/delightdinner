using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Common.ValueObjects;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu.MenuObjects;
using DelightDinner.Domain.MenuReview.ValueObjects;

namespace DelightDinner.Domain.MenuReview;

public class MenuReview : AggregateRoot<MenuReviewId>
{
    public Rating Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }    
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private MenuReview(
        MenuReviewId menuReviewId,
        Rating rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime)
        : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
    }

    public static MenuReview Create(
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        MenuReviewId? menuReviewId = null)
    {
        // TODO: enforce invariants
        var ratingValueObject = Rating.Create(rating);

        return new(
            menuReviewId ?? MenuReviewId.Create(menuId, dinnerId, guestId),
            ratingValueObject,
            comment,
            hostId,
            menuId,            
            guestId,
            dinnerId,
            createdDateTime);
    }
}