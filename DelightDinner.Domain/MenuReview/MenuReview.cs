using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.MenuReview.ValueObjects;

namespace DelightDinner.Domain.MenuReview;

public class MenuReview : AggregateRoot<MenuReviewId>
{
    public float Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private MenuReview(
        MenuReviewId menuReviewId,
        HostId hostId,
        DinnerId dinnerId,
        GuestId guestId,
        float rating,
        string comment,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuReviewId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        GuestId = guestId;
        Rating = rating;
        Comment = comment;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static MenuReview Create(
        HostId hostId,
        DinnerId dinnerId,
        GuestId guestId,
        float rating,
        string comment,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            MenuReviewId.CreateUnique(),
            hostId,
            dinnerId,
            guestId,
            rating,
            comment,
            createdDateTime,
            updatedDateTime);
    }
}