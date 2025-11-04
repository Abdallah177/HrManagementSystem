using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.LocationManagement.StateManagement.Common.Commands;
using HrManagementSystem.Features.LocationManagement.StateMangement.GetStateById;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.GetStateById
{
    public class GetStateByIdEndPoint:BaseEndPoint<GetByIdRequestViewModle,GetStateByIdResponseViewModle>
    {
        public GetStateByIdEndPoint(EndpointBaseParameters<GetByIdRequestViewModle> endpoints) : base(endpoints) { }

        [HttpGet]
        public async Task<EndpointResponse<GetStateByIdResponseViewModle>> GetStatEById([FromQuery] GetByIdRequestViewModle request, CancellationToken cancellationToken)
        {

            // validate request
            var validation = ValidateRequest(request);
            if (!validation.IsSuccess)
                return validation;


            var result = await _mediator.Send(new GetStateByIdQuery(request.Id));

            if (!result.IsSuccess)
                return EndpointResponse<GetStateByIdResponseViewModle>.Failure(result.Message, result.ErrorCode);

            var resultVieModle = result.Data.Adapt<GetStateByIdResponseViewModle>();

            return EndpointResponse<GetStateByIdResponseViewModle>.Success(resultVieModle, result.Message);

        }

    }
}
