using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Common.ValueObjects;
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
    public Uri ProfileImage { get; }
    public AverageRating AverageRating { get; }
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
        Uri profileImage,
        AverageRating averageRating)
        : base(hostId ?? HostId.Create(userId))
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        AverageRating = averageRating;
    }

    public static Host Create(
        UserId userId,
        string firstName,
        string lastName,
        Uri profileImage)
    {
        return new(
            HostId.Create(userId),
            userId,
            firstName,
            lastName,
            profileImage,
            AverageRating.CreateNew());
    }
}