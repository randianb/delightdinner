using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.GuestAggregate.Events;

public record GuestCreated(Guest Guest) : IDomainEvent;