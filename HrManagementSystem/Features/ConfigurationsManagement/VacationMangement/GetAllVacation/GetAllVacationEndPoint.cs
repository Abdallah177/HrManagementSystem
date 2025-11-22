using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.GetAllVacation.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.GetAllVacation
{
    public class GetAllVacationEndPoint : BaseEndPoint<object, GetAllVacationResponseViewModel>
    {
        public GetAllVacationEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }
        [HttpGet]
        public async Task<EndpointResponse<List<GetAllVacationResponseViewModel>>> GetAllVacations()
        {
            
            var result = await _mediator.Send(new GetAllVacationQuery());
            if (!result.IsSuccess)
                return EndpointResponse<List<GetAllVacationResponseViewModel>>.Failure(result.Message);
           
           return EndpointResponse<List<GetAllVacationResponseViewModel>>.Success(result.Data);
            
        }
    }
    
}
