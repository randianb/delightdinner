using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.MenuAggregate.Events;

public record MenuCreated(Menu.Menu Menu) : IDomainEvent;