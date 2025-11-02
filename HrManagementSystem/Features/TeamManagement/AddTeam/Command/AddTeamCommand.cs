using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using HrManagementSystem.Features.TeamManagement.AddTeam.Dtos;
using HrManagementSystem.Features.TeamManagement.AddTeam.Queries;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.TeamManagement.AddTeam.Command
{
    public record AddTeamCommand (string Name , string DepartmentId , string UserId) : IRequest<RequestResult<AddTeamDto>>;

    public class AddTeamCommandHandler : RequestHandlerBase<AddTeamCommand, RequestResult<AddTeamDto>, Team>
    {
        public AddTeamCommandHandler(RequestHandlerBaseParameters<Team> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<AddTeamDto>> Handle(AddTeamCommand request, CancellationToken cancellationToken)
        {
            var IsDeoartmentExist = await _mediator.Send(new CheckExistsQuery<Department>(request.DepartmentId));

            if (!IsDeoartmentExist)
                return RequestResult<AddTeamDto>.Failure("Department Not Found.", ErrorCode.DepartmentNotExist);

            var result =await _mediator.Send(new CheckDublicateTeamNameInSameDepartment(request.Name, request.DepartmentId));

            if (result)
                return RequestResult<AddTeamDto>.Failure("There is already a Team with this Name.", ErrorCode.DuplicateRecord);

            var Team = new Team { Name = request.Name,DepartmentId = request.DepartmentId };

            await _repository.AddAsync(Team, request.UserId, cancellationToken);

            var addTeamDto = Team.Adapt<AddTeamDto>();

            return RequestResult<AddTeamDto>.Success(addTeamDto);
        }
    }


}
