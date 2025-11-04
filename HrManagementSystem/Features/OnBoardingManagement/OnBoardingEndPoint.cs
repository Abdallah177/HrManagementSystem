using Azure;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.CompanyManagement.AddCompany;
using HrManagementSystem.Features.OnBoardingManagement.Commands;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.OnBoardingManagement
{
    public class OnBoardingEndPoint : BaseEndPoint<OnBoardingRequestViewModel, bool>
    {
        public OnBoardingEndPoint(EndpointBaseParameters<OnBoardingRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<bool>> OnBoarding([FromBody]OnBoardingRequestViewModel RequestViewModel , CancellationToken cancellationToken)
        {
            var validationResult = ValidateRequest(RequestViewModel);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var onBoardingRequest = RequestViewModel.Adapt<OnBoardingDto>();
            var organizationResult = await _mediator.Send(new OnBoardingOrchestrator(onBoardingRequest, GetCurrentUserId().ToString()),cancellationToken);
            

            return EndpointResponse<bool>.Success(true);

        }
    }
}
