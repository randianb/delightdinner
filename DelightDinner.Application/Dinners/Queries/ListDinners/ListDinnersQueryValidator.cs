using FluentValidation;

namespace DelightDinner.Application.Dinners.Queries.ListDinners;

public class ListDinnersQueryValidator : AbstractValidator<ListDinnersQuery>
{
    public ListDinnersQueryValidator()
    {
        RuleFor(x => x.HostId).NotEmpty();
    }
}