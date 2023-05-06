using DelightDinner.Application.Dinners.Commands.CreateDinner;
using DelightDinner.Application.Dinners.Queries.ListDinners;
using DelightDinner.Contracts.Dinner;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DelightDinner.Api.Controllers;

[Route("host/{hostId}/dinners")]
public class DinnersController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public DinnersController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDinner(
        CreateDinnerRequest request,
        string hostId)
    {
        var command = _mapper.Map<CreateDinnerCommand>((request, hostId));

        var createDinnerResult = await _mediator.Send(command);

        return createDinnerResult.Match(
            dinner => Ok(_mapper.Map<DinnerResponse>(dinner)),
            errors => Problem(errors));
    }

    [HttpGet]
    public async Task<IActionResult> ListDinners(string hostId)
    {
        var query = _mapper.Map<ListDinnersQuery>(hostId);

        var listDinnersResult = await _mediator.Send(query);

        return listDinnersResult.Match(
            dinners => Ok(dinners.Select(dinner => _mapper.Map<DinnerResponse>(dinner))),
            errors => Problem(errors));
    }
}