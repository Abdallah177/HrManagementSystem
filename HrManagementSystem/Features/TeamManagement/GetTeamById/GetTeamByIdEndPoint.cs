using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.TeamManagement.GetTeamById.Quesries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.TeamManagement.GetTeamById
{
    public class GetTeamByIdEndPoint : BaseEndPoint<GetTeamByIdRequestViewModel, GetTeamByIdResponseViewModel>
    {
        public GetTeamByIdEndPoint(EndpointBaseParameters<GetTeamByIdRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<GetTeamByIdResponseViewModel>> GetTeamById([FromQuery] GetTeamByIdRequestViewModel request, CancellationToken cancellationToken)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var result = await _mediator.Send(new GetTeamByIdQuery(request.Id));

            if (!result.IsSuccess)
                return EndpointResponse<GetTeamByIdResponseViewModel>.Failure(result.Message, result.ErrorCode);

            var getTeamByIdResponseViewModel = result.Data.Adapt<GetTeamByIdResponseViewModel>();

            return EndpointResponse<GetTeamByIdResponseViewModel>.Success(getTeamByIdResponseViewModel);
        }
    }
}
