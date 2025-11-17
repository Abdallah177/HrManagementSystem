using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManagement.GetAllBreaks.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManagement.GetAllBreaks
{
    public class GetAllBreaksEndpoint : BaseEndPoint<object, List<GetAllBreaksResponseViewModel>>
    {
        public GetAllBreaksEndpoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<List<GetAllBreaksResponseViewModel>>> GetAllBreaks ()
        {
            var breaksDto =await  _mediator.Send(new GetAllBreaksQuery());

            if (!breaksDto.IsSuccess)
                return EndpointResponse<List<GetAllBreaksResponseViewModel>>.Failure(breaksDto.Message, breaksDto.ErrorCode);

            var getAllBreaksResponseViewModel = breaksDto.Data.Adapt<List<GetAllBreaksResponseViewModel>>();

            return EndpointResponse<List<GetAllBreaksResponseViewModel>>.Success(getAllBreaksResponseViewModel);    
        }
    }
}
