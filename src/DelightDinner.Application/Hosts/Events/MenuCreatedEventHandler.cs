using DelightDinner.Domain.MenuAggregate.Events;

using MediatR;

namespace DelightDinner.Application.Hosts.Events;

public class MenuCreatedEventHandler : INotificationHandler<MenuCreated>
{
    private readonly IHostRepository _hostRepository;

    public MenuCreatedEventHandler(IHostRepository hostRepository)
    {
        _hostRepository = hostRepository;
    }

    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
