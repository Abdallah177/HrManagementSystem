using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.Common.TeamManagement.Queries;

public record IsTeamExistsQuery(string Name,string DepartmentId) : IRequest<EndpointResponse<bool>>;

public class IsTeamExistsQueryHandler(IGenericRepository<Team> genericRepository) : IRequestHandler<IsTeamExistsQuery, EndpointResponse<bool>>
{
    private readonly IGenericRepository<Team> _genericRepository = genericRepository;

    public async Task<EndpointResponse<bool>> Handle(IsTeamExistsQuery request, CancellationToken cancellationToken)
    {
        var isTeamExists = await _genericRepository.Get(x => x.Name == request.Name && x.DepartmentId == request.DepartmentId).AnyAsync();

        return isTeamExists ? EndpointResponse<bool>.Success(default): EndpointResponse<bool>.Failure("Team not found");
    }
}
