using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.HostAggregate.Events;

public record HostCreated(Host Host) : IDomainEvent;