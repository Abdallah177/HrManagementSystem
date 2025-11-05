using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.UpdateProbation.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.UpdateProbation
{
    public class UpdateProbationEndPoint : BaseEndPoint<UpdateProbationRequestViewModel, UpdateProbationResponseViewModel>
    {
        public UpdateProbationEndPoint(EndpointBaseParameters<UpdateProbationRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPut]
        public async Task<EndpointResponse<UpdateProbationResponseViewModel>> UpdateProbation(UpdateProbationRequestViewModel viewModel)
        {
            var command = new UpdateProbationCommand(
                viewModel.Id,
                viewModel.DurationInDays,
                viewModel.EvaluationCriteria
            );
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return EndpointResponse<UpdateProbationResponseViewModel>
                    .Failure(result.Message, result.ErrorCode);
            }
            var response = result.Data.Adapt<UpdateProbationResponseViewModel>();
            return EndpointResponse<UpdateProbationResponseViewModel>.Success(response);
        }
    }
   
}
