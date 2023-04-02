using DelightDinner.Domain.Common.Models;
using DelightDinner.Domain.Dinner.Enums;

namespace DelightDinner.Domain.Dinner.ValueObjects;

public class Price : ValueObject
{
    public decimal Amount { get; }
    public Currency Currency { get; }

    private Price(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price Create(decimal amount, Currency currency)
    {
        return new Price(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}