using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.DinnerAggregate.Events;
using DelightDinner.Domain.DinnerAggregate.ValueObjects;
using DelightDinner.Domain.HostAggregate;

using MediatR;

namespace DelightDinner.Application.Hosts.Events;

public class DinnerCreatedEventHandler : INotificationHandler<DinnerCreated>
{
    private readonly IHostRepository _hostRepository;

    public DinnerCreatedEventHandler(IHostRepository hostRepository)
    {
        _hostRepository = hostRepository;
    }

    public async Task Handle(
        DinnerCreated dinnerCreatedEvent, 
        CancellationToken cancellationToken)
    {
        if (await _hostRepository.GetByIdAsync(dinnerCreatedEvent.Dinner.HostId) is not Host host)
        {
            throw new InvalidOperationException($"Dinner has invalid host id (dinner id: {dinnerCreatedEvent.Dinner.Id}, host id: {dinnerCreatedEvent.Dinner.HostId}).");
        }

        host.AddDinnerId((DinnerId)dinnerCreatedEvent.Dinner.Id);

        await _hostRepository.UpdateAsync(host);
    }
}