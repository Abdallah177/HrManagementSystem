using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetProbationById
{
    public class GetProbationByIdEndPoint : BaseEndPoint<GetProbationByIdRequesViewModel, GetProbationByIdResponseViewModel>
    {
        public GetProbationByIdEndPoint(EndpointBaseParameters<GetProbationByIdRequesViewModel> parameters) : base(parameters)
        {
        }
        [HttpGet("GetProbationById")]
        public async Task<EndpointResponse<GetProbationByIdResponseViewModel>> GetProbationById([FromQuery] GetProbationByIdRequesViewModel requestViewModel)
        {
            var validationResult = ValidateRequest(requestViewModel);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }
            var result = await _mediator.Send(new Queries.GetProbationByIdQuery(requestViewModel.Id));
            if (!result.IsSuccess)
            {
                return EndpointResponse<GetProbationByIdResponseViewModel>.Failure(result.Message, result.ErrorCode);
            }
            var responseViewModel = result.Data.Adapt<GetProbationByIdResponseViewModel>();
            return EndpointResponse<GetProbationByIdResponseViewModel>.Success(responseViewModel);
        }
    }
    
}
