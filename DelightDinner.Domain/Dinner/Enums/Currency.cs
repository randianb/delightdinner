using Ardalis.SmartEnum;

namespace DelightDinner.Domain.Dinner.Enums;

public class Currency : SmartEnum<Currency>
{
    public Currency(string name, int value) 
        : base(name, value) { }

    public static readonly Currency USD = new Currency(nameof(USD), 1);
    public static readonly Currency EUR = new Currency(nameof(EUR), 2);
}