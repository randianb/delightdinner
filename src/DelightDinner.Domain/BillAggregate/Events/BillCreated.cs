using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.BillAggregate.Events;

public record BillCreated(Bill Bill) : IDomainEvent;