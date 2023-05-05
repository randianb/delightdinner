using DelightDinner.Application.Common.Interfaces.Persistence;
using DelightDinner.Domain.Dinner;
using DelightDinner.Domain.Host.ValueObjects;

using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Dinners.Queries.ListDinners;

public class ListDinnerQueryHandler 
    : IRequestHandler<ListDinnersQuery, ErrorOr<List<Dinner>>>
{
    private readonly IDinnerRepository _dinnerRepository;

    public ListDinnerQueryHandler(IDinnerRepository dinnerRepository)
    {
        _dinnerRepository = dinnerRepository;
    }

    public async Task<ErrorOr<List<Dinner>>> Handle(
        ListDinnersQuery query, 
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var hostId = HostId.Create(query.HostId);
        return _dinnerRepository.List(hostId);
    }
}