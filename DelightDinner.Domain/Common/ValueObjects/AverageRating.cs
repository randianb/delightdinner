using DelightDinner.Domain.Common.Models;

namespace DelightDinner.Domain.Common.ValueObjects;

public class AverageRating : ValueObject
{
    public double Value { get; private set; }
    public int NumRating { get; private set; }

    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRating = numRatings;
    }

    public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
    {
        return new AverageRating(rating, numRatings);
    }

    public void AddNewRating(Rating rating)
    {
        Value = (Value * NumRating + rating.Value) / ++NumRating;
    }

    public void RemoveRating(Rating rating)
    {
        Value = (Value * NumRating - rating.Value) / --NumRating;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}