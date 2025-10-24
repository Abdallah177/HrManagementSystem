using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization
{
    public class GetOrganizationByIDEndPoint : BaseEndPoint<GetOranizationByIdRequsetViewModel , GetOrganizationByIDResponseViewModel>
    {
        public GetOrganizationByIDEndPoint(EndpointBaseParameters<GetOranizationByIdRequsetViewModel> parameters) : base(parameters)
        {
        }
        [HttpGet("")]
        public async Task<EndpointResponse<GetOrganizationByIDResponseViewModel>> GetOrganizationByID([FromQuery] GetOranizationByIdRequsetViewModel requestViewModel)
        {
            var validationResult = ValidateRequest(requestViewModel);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }
            var result = await _mediator.Send(new Queries.GetOrganizationByIDQuery(requestViewModel.OrganizationId));
            if (!result.IsSuccess)
            {
                return EndpointResponse<GetOrganizationByIDResponseViewModel>.Failure(result.Message, result.ErrorCode);
            }
            var responseViewModel = result.Data.Adapt<GetOrganizationByIDResponseViewModel>();
            return EndpointResponse<GetOrganizationByIDResponseViewModel>.Success(responseViewModel);
        }


    }
    
}
