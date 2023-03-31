using DelightDinner.Domain.Bill.ValueObjects;
using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Guest.ValueObjects;
using DelightDinner.Domain.User.ValueObjects;

namespace DelightDinner.Domain.Guest;

public class Guest : AggregateRoot<GuestId>
{
    private readonly List<GuestRatingId> _guestRatingIds = new();
    private readonly List<BillId> _billIds = new();

    public int FirstName { get; }
    public int LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId { get; }

    public IReadOnlyList<GuestRatingId> GuestRatingIds => _guestRatingIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Guest(
        GuestId guestId,
        UserId userId,
        int firstName,
        int lastName,
        string profileImage,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestId)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(
        UserId userId,
        int firstName,
        int lastName,
        string profileImage,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            GuestId.CreateUnique(),
            userId,
            firstName,
            lastName,
            profileImage,
            createdDateTime,
            updatedDateTime);
    }
}
