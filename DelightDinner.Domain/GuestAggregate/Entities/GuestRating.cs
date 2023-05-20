using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Common.ValueObjects;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;

using ErrorOr;

namespace DelightDinner.Domain.Guest.Entities;

public class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public Rating Rating { get; private set; }

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

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

#pragma warning disable CS8618
    private GuestRating()
    {
    }
#pragma warning restore CS8618
}