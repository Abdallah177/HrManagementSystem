using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetAllRequests.Query;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetAllRequests
{
    public class GetAllRequestsEndPoint : BaseEndPoint<object, GetAllRequestResponseViewModel>
    {
        public GetAllRequestsEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }
        [HttpGet]
        public async Task<EndpointResponse<List<GetAllRequestResponseViewModel>>> GetAllRequests()
        {
            
            var result = await _mediator.Send(new GetAllRequestQuery());

            if (!result.IsSuccess)
                return EndpointResponse<List<GetAllRequestResponseViewModel>>.Failure(result.Message);
           
           return EndpointResponse<List<GetAllRequestResponseViewModel>>.Success(result.Data);

        }
    
    }
}
