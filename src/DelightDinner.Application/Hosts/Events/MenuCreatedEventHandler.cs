using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.HostAggregate;
using DelightDinner.Domain.MenuAggregate.Events;
using DelightDinner.Domain.MenuAggregate.MenuObjects;

using MediatR;

namespace DelightDinner.Application.Hosts.Events;

public class MenuCreatedEventHandler : INotificationHandler<MenuCreated>
{
    private readonly IHostRepository _hostRepository;

    public MenuCreatedEventHandler(IHostRepository hostRepository)
    {
        _hostRepository = hostRepository;
    }

    public async Task Handle(
        MenuCreated menuCreatedEvent, 
        CancellationToken cancellationToken)
    {
        if (await _hostRepository.GetByIdAsync(menuCreatedEvent.Menu.HostId) is not Host host)
        {
            throw new InvalidOperationException($"Menu has invalid host id (menu id: {menuCreatedEvent.Menu.Id}, host id: {menuCreatedEvent.Menu.HostId}).");
        }

        host.AddMenuId((MenuId)menuCreatedEvent.Menu.Id);

        await _hostRepository.UpdateAsync(host);
    }
}