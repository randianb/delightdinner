using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.DinnerAggregate.Events;

public record DinnerCreated(Dinner.Dinner Dinner) : IDomainEvent;