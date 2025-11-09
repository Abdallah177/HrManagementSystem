using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team;
using MediatR;
using Mapster;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingTeamsCommand(List<DepartmentsResponseDto> Departments, string currentUserId) : IRequest<RequestResult<List<TeamsResponseDto>>>;

    public class OnBoardingTeamsCommandHandler : RequestHandlerBase<OnBoardingTeamsCommand, RequestResult<List<TeamsResponseDto>>, Team>
    {
        public OnBoardingTeamsCommandHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<List<TeamsResponseDto>>> Handle(OnBoardingTeamsCommand request, CancellationToken cancellationToken)
        {
            var teamsResponses = new List<TeamsResponseDto>();

            var teamsDto = request.Departments
                .SelectMany(dept => dept.Teams.Any() ? dept.Teams.Select(team => new
                {
                    TeamDto = new TeamsDto(team.Name, dept.DepartmentId)
                })
                : new[]
                {
                  new
                 {
                     TeamDto = new TeamsDto($"{dept.DepartmentName} Team", dept.DepartmentId)

                  }}).ToList();

            foreach (var item in teamsDto)
            {
                var team = item.TeamDto.Adapt<Team>();
                await _repository.AddAsync(team, request.currentUserId, cancellationToken);

                teamsResponses.Add(new TeamsResponseDto
                {
                    TeamId = team.Id,
                    DepartmentId = team.DepartmentId,    
                    BranchId = team.Department.BranchId,                
                    CompanyId = team.Department.Branch.CompanyId,  
                    OrganizationId = team.Department.Branch.Company.OrganizationId,
                });
            }

            return RequestResult<List<TeamsResponseDto>>.Success(teamsResponses, "Teams created successfully");
        }
    }
}

