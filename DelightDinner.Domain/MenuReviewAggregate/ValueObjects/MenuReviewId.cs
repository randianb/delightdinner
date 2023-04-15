using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.MenuReview.ValueObjects;

public sealed class MenuReviewId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuReviewId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618
    private MenuReviewId()
    {
    }
#pragma warning restore CS8618
}