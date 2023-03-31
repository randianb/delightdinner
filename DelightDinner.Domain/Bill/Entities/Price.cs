namespace DelightDinner.Domain.Bill.Entities;

public class Price
{
    public float Amount { get; }
    public Currency Currency { get; }
}

public enum Currency
{
    EUR,
    USD
}