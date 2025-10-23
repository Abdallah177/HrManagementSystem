using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;

using HrManagementSystem.Features.LocationManagement.CountryManagement.UpdateCountry;
using HrManagementSystem.Features.LocationManagement.StateMangement.GetStateById.Queries;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.StateMangement.GetStateById
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetStateByIdController : BaseEndPoint<GetByIdRequestViewModle, GetStateByIdResponseViewModle>
    {
        public GetStateByIdController(EndpointBaseParameters<GetByIdRequestViewModle> endpoints) : base(endpoints) { }

        [HttpGet("")]
        public async Task<EndpointResponse<GetStateByIdResponseViewModle>> GetStatEById([FromQuery]GetByIdRequestViewModle request, CancellationToken cancellationToken)
        {

            // validate request
            var validation = ValidateRequest(request);
            if (!validation.IsSuccess)
                return validation;


            var result = await _mediator.Send(new GetStateByIdQuery(request.Id));

            if (!result.IsSuccess)
              return EndpointResponse<GetStateByIdResponseViewModle>.Failure(result.Message, result.ErrorCode);
        
            var resultVieModle=result.Adapt<GetStateByIdResponseViewModle>();

            return EndpointResponse<GetStateByIdResponseViewModle>.Success(resultVieModle,result.Message);

        }

    }
}
