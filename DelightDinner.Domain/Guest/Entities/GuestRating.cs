using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Guest.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;

namespace DelightDinner.Domain.Guest.Entities;

public class GuestRating : Entity<GuestRatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public float Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private GuestRating(
        GuestRatingId guesRatingtId,
        HostId hostId,
        DinnerId dinnerId,
        float rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guesRatingtId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }


    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        float rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            GuestRatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating,
            createdDateTime,
            updatedDateTime);
    }
}
