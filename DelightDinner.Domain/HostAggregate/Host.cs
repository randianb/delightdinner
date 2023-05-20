using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Common.ValueObjects;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.HostAggregate.ValueObjects;
using DelightDinner.Domain.MenuAggregate.MenuObjects;
using DelightDinner.Domain.User.ValueObjects;

namespace DelightDinner.Domain.HostAggregate;

public sealed class Host : AggregateRoot<HostId, string>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Uri ProfileImage { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public UserId UserId { get; private set; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

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

#pragma warning disable CS8618
    private Host()
    {
    }
#pragma warning restore CS8618
}