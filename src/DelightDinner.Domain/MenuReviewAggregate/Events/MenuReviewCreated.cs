using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.MenuReviewAggregate.Events;

public record MenuReviewCreated(MenuReview MenuReview) : IDomainEvent;