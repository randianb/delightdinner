using DelightDinner.Application.Authentication.Commands.Register;
using DelightDinner.Application.Authentication.Common;
using DelightDinner.Application.Authentication.Queries.Login;
using DelightDinner.Contracts.Authentication;

using Mapster;

namespace DelightDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.UserId, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User);
    }
}