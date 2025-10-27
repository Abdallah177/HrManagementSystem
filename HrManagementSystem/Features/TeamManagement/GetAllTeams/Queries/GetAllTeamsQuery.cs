using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.TeamManagement.GetAllTeams.DTOs;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.TeamManagement.GetAllTeams.Queries
{
    public record GetAllTeamsQuery : IRequest<RequestResult<List<GetAllTeamsDto>>>;
    
    public class GetAllTeamsQueryHandler : RequestHandlerBase<GetAllTeamsQuery, RequestResult<List<GetAllTeamsDto>>, Team>
    {
      public   GetAllTeamsQueryHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<List<GetAllTeamsDto>>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _repository.GetAll()
                .OrderBy(t => t.Name)
                .ProjectToType<GetAllTeamsDto>()
                .ToListAsync(cancellationToken);

            if (teams == null )
                return RequestResult<List<GetAllTeamsDto>>.Failure("No teams found.", ErrorCode.NoTeamsFound);

            return RequestResult<List<GetAllTeamsDto>>.Success(teams);

        }
    }
}
