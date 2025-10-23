using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.GetBranchById.Queries;
using HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.BranchManagement.GetBranchById
{
    public class GetBranchByIdEndPoint : BaseEndPoint<GetBranchByIdRequestViewModel, GetBranchByIdResponseViewModel>
    {
        public GetBranchByIdEndPoint(EndpointBaseParameters<GetBranchByIdRequestViewModel> parameters) : base(parameters)
        {
        }
        [HttpGet]
        public async Task<EndpointResponse<GetBranchByIdResponseViewModel>> GetBranchById([FromQuery] GetBranchByIdRequestViewModel request)
        {
            var validationResponse = ValidateRequest(request);
            if (!validationResponse.IsSuccess)
                return EndpointResponse<GetBranchByIdResponseViewModel>.Failure(validationResponse.Message);

            var BranchQueryResult = await  _mediator.Send(new GetBranchByIdQuery(request.BranchId));
            if (!BranchQueryResult.IsSuccess)
                return EndpointResponse<GetBranchByIdResponseViewModel>.Failure(BranchQueryResult.Message);

            var branchData = BranchQueryResult.Adapt<GetBranchByIdResponseViewModel>(); 
            return EndpointResponse<GetBranchByIdResponseViewModel>.Success(branchData);
        }
    }
}
