using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.StateManagement.GetAllStates;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.GetAllCountry.Queries;

public record GetAllStatesQuery(CancellationToken CancellationToken) : IRequest<EndpointResponse<IEnumerable<GetAllStatesDto>>>;

public class GetAllStateHandler(IGenericRepository<State> GenericRepository) 
    : IRequestHandler<GetAllStatesQuery, EndpointResponse<IEnumerable<GetAllStatesDto>>>
{
    private readonly IGenericRepository<State> _genericRepository = GenericRepository;

    public async Task<EndpointResponse<IEnumerable<GetAllStatesDto>>> Handle(GetAllStatesQuery request, CancellationToken cancellationToken)
    {
        var states = await _genericRepository.GetAll().ToListAsync(cancellationToken);

        return EndpointResponse<IEnumerable<GetAllStatesDto>>.Success(states.Adapt<IEnumerable<GetAllStatesDto>>());
    }
}
