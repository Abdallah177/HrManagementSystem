using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetAllProbation.Queris;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetAllProbation
{
    public class GetAllProbationEndPoint : BaseEndPoint<object, GetAllProbtionResponseViewModel>
    {
        public GetAllProbationEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }
        [HttpGet]
        public async Task<EndpointResponse<List<GetAllProbtionResponseViewModel>>> GetAllProbations()
        {
            
            var result = await _mediator.Send(new GetAllProbationQuery());
            if (!result.IsSuccess)
                return EndpointResponse<List<GetAllProbtionResponseViewModel>>.Failure(result.Message);
           
           return EndpointResponse<List<GetAllProbtionResponseViewModel>>.Success(result.Data);
            
        }
    }
}
