using DelightDinner.Domain.DinnerAggregate;

using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Dinners.Queries.ListDinners;

public record ListDinnersQuery(string HostId) : IRequest<ErrorOr<List<Dinner>>>;