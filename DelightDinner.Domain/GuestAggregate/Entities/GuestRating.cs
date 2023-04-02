using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Common.ValueObjects;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;
using ErrorOr;

namespace DelightDinner.Domain.Guest.Entities;

public class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private GuestRating(
        HostId hostId,
        DinnerId dinnerId,
        Rating rating)
        : base(GuestRatingId.CreateUnique())
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
    }

    public static ErrorOr<GuestRating> Create(
        HostId hostId,
        DinnerId dinnerId,
        int rating)
    {
        var ratingValueObject = Rating.Create(rating);

        return new GuestRating(
            hostId,
            dinnerId,
            ratingValueObject);
    }
}