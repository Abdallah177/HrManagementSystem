using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.TeamManagement.TeamUpdate.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.TeamManagement.TeamUpdate
{
    public class UpdateTeamEndPoint : BaseEndPoint<UpdateTeamRequsetViewModel, UpdateTeamResponseViewModel>
    {
        public UpdateTeamEndPoint(EndpointBaseParameters<UpdateTeamRequsetViewModel> parameters) : base(parameters)
        {
        }
        [HttpPut]

        public async Task<EndpointResponse<UpdateTeamResponseViewModel>> UpdateTeam(UpdateTeamRequsetViewModel viewModel)
        {
            var result = await _mediator.Send(new UpdateTeamCommand(viewModel.Id, viewModel.Name, viewModel.DepartmentId));
            if (!result.IsSuccess)
            {
                return EndpointResponse<UpdateTeamResponseViewModel>.Failure(result.Message, result.ErrorCode);
            }
            var updateTeamResponseViewModel = result.Data.Adapt<UpdateTeamResponseViewModel>();
            return EndpointResponse<UpdateTeamResponseViewModel>.Success(updateTeamResponseViewModel);
        }

    }
}
