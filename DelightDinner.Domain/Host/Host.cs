using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.ValueObjects;
using DelightDinner.Domain.Host.ValueObjects;
using DelightDinner.Domain.Menu.MenuObjects;
using DelightDinner.Domain.User.ValueObjects;

namespace DelightDinner.Domain.Host;

public class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuId = new();
    private readonly List<DinnerId> _dinnerId = new();

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerId.AsReadOnly();
    public IReadOnlyList<MenuId> MenuIds => _menuId.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Host(
        HostId hostId,
        UserId userId,
        string firstName,
        string lastName,
        string profileImage,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(hostId)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(
        UserId userId,
        string firstName,
        string lastName,
        string profileImage,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            HostId.CreateUnique(),
            userId,
            firstName,
            lastName,
            profileImage,
            createdDateTime,
            updatedDateTime);
    }
}