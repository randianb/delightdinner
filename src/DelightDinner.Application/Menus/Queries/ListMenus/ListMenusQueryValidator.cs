using FluentValidation;

namespace DelightDinner.Application.Menus.Queries.ListMenus;

public class ListMenusQueryValidator : AbstractValidator<ListMenusQuery>
{
    public ListMenusQueryValidator()
    {
        RuleFor(x => x.HostId).NotEmpty();
    }
}