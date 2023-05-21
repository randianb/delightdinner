using FluentValidation;

namespace DelightDinner.Application.Dinners.Commands.CreateDinner;

public class CreateDinnerCommandValidation : AbstractValidator<CreateDinnerCommand>
{
    public CreateDinnerCommandValidation()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.IsPublic).NotEmpty();
        RuleFor(x => x.MaxGuests).NotEmpty();
        RuleFor(x => x.Price).NotNull();
        RuleFor(x => x.MenuId).NotEmpty();
        RuleFor(x => x.ImageUrl).NotEmpty();
        RuleFor(x => x.Location).NotNull();
    }
}