using HrManagementSystem.Common.Views;
using HrManagementSystem.Common;
using HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetAllShifts.Queries;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.GetAllShifts
{
    public class GetAllShiftsEndpoint : BaseEndPoint<object, List<GetAllShiftsResponseViewModel>>
    {
        public GetAllShiftsEndpoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<List<GetAllShiftsResponseViewModel>>> GetAllShifts()
        {
            var shiftsDto = await _mediator.Send(new GetAllShiftsQuery());

            if (!shiftsDto.IsSuccess)
                return EndpointResponse<List<GetAllShiftsResponseViewModel>>.Failure(shiftsDto.Message, shiftsDto.ErrorCode);

            var getAllShiftsResponseViewModel = shiftsDto.Data.Adapt<List<GetAllShiftsResponseViewModel>>();

            return EndpointResponse<List<GetAllShiftsResponseViewModel>>.Success(getAllShiftsResponseViewModel);
        }
    }

}
