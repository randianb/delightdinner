using DelightDinner.Application.Menus.Commands.CreateMenu;
using DelightDinner.Contracts.Menu;

using Mapster;

namespace DelightDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);
    }
}
