using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.DepartmentManagement.Queries;
using HrManagementSystem.Features.Common.TeamManagement.Queries;
using MediatR;

namespace HrManagementSystem.Features.TeamManagement.AddTeam.Commands;

public record AddTeamCommand(string Name,string DepartmentId) : IRequest<EndpointResponse<bool>>;

public class AddTeamCommandHandler(IGenericRepository<Team> genericRepository,IMediator mediator) : IRequestHandler<AddTeamCommand, EndpointResponse<bool>>
{
    private readonly IGenericRepository<Team> _genericRepository = genericRepository;
    private readonly IMediator _mediator = mediator;

    public async Task<EndpointResponse<bool>> Handle(AddTeamCommand request, CancellationToken cancellationToken)
    {
        var isTeamExistsResult = await _mediator.Send(new IsTeamExistsQuery(request.Name, request.DepartmentId));

        if (isTeamExistsResult.IsSuccess)
            return isTeamExistsResult;


        var isDepartmentExistsResult = await _mediator.Send(new IsDepartmentExistsQuery(request.DepartmentId));

        if (!isDepartmentExistsResult.IsSuccess)
            return EndpointResponse<bool>.Failure("Department not found");

        var team = new Team { Name = request.Name, DepartmentId = request.DepartmentId, CreatedByUser = "test" };

        await _genericRepository.AddAsync(team, cancellationToken);

        return EndpointResponse<bool>.Success(default);
    }
}


