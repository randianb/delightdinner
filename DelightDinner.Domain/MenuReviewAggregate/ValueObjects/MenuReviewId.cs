using DelightDinner.Domain.Common.Models.Identities;

namespace DelightDinner.Domain.MenuReview.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<Guid>
{
    private MenuReviewId(Guid value) : base(value)
    {
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuReviewId Create(Guid value)
    {
        return new(value);
    }
}