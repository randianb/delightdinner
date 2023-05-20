using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.DinnerAggregate;
using DelightDinner.Domain.Host.ValueObjects;

using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Dinners.Queries.ListDinners;

public class ListDinnersQueryHandler 
    : IRequestHandler<ListDinnersQuery, ErrorOr<List<Dinner>>>
{
    private readonly IDinnerRepository _dinnerRepository;

    public ListDinnersQueryHandler(IDinnerRepository dinnerRepository)
    {
        _dinnerRepository = dinnerRepository;
    }

    public async Task<ErrorOr<List<Dinner>>> Handle(
        ListDinnersQuery query, 
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var hostId = HostId.Create(query.HostId);
        return await _dinnerRepository.ListAsync(hostId);
    }
}