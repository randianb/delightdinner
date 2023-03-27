using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.MenuReview.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    public MenuReviewId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
