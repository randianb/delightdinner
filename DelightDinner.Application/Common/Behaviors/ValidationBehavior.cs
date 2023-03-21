using DelightDinner.Application.Authentication.Commands.Register;
using DelightDinner.Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace DelightDinner.Application.Common.Behaviors;

public class ValidationRegisterCommandBehavior
    : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IValidator<RegisterCommand> _validator;

    public ValidationRegisterCommandBehavior(IValidator<RegisterCommand> validator)
    {
        _validator = validator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand request,
        RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
        CancellationToken cancellationToken)
    {
        var validatioResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validatioResult.IsValid)
        {
            return await next();
        }

        var errors = validatioResult.Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage));
        
        return errors;
    }
}
