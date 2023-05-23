using DelightDinner.Application.Menus.Queries.ListMenus;
using DelightDinner.Application.Menus.Commands.CreateMenu;
using DelightDinner.Contracts.Menu;
using DelightDinner.Domain.MenuAggregate;

using Mapster;

using MenuSection = DelightDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = DelightDinner.Domain.MenuAggregate.Entities.MenuItem;

namespace DelightDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<string, ListMenusQuery>()
            .MapWith(src => new ListMenusQuery(src));

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}