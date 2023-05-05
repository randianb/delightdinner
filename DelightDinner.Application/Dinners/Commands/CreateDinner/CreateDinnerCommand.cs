using DelightDinner.Domain.Dinner;

using ErrorOr;
using MediatR;

namespace DelightDinner.Application.Dinners.Commands.CreateDinner;

public record CreateDinnerCommand(
    string HostId,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    bool IsPublic,
    int MaxGuests,
    DinnerPriceCommand Price,
    string MenuId,
    Uri ImageUrl,
    DinnerLocationCommand Location) : IRequest<ErrorOr<Dinner>>;

public record DinnerPriceCommand(
    decimal Amount,
    string Currency);

public record DinnerLocationCommand(
    string Name,
    string Address,
    float Latitude,
    float Longtitude);