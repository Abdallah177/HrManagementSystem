using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.TeamManagement.AddTeam.Command;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.TeamManagement.AddTeam
{
    public class AddTeamEndpoint : BaseEndPoint<AddTeamRequestViewModel, AddTeamResponseViewModel>
    {
        public AddTeamEndpoint(EndpointBaseParameters<AddTeamRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<AddTeamResponseViewModel>> AddTeam(AddTeamRequestViewModel viewModel)
        {
            var response = await _mediator.Send(new AddTeamCommand(viewModel.Name, viewModel.DepartmentId , viewModel.UserId));

            if (!response.IsSuccess)
                return EndpointResponse<AddTeamResponseViewModel>.Failure(response.Message, response.ErrorCode);

            var addTeamRequestViewModel = response.Data.Adapt<AddTeamResponseViewModel>();

            return EndpointResponse<AddTeamResponseViewModel>.Success(addTeamRequestViewModel);
        }

    }
}
