using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.TeamManagement.GetAllTeams.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HrManagementSystem.Features.TeamManagement.GetAllTeams
{
    public class GetAllTeamsEndPoint : BaseEndPoint<object, List<GetAllTeamsResposeViewModel>>
    {
        public GetAllTeamsEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<List<GetAllTeamsResposeViewModel>>> GetAllTeams()
        { 
           var result = await _mediator.Send(new GetAllTeamsQuery());
              if (!result.IsSuccess)
                return new EndpointResponse<List<GetAllTeamsResposeViewModel>>(default,false, result.Message,result.ErrorCode);

              var teamsDate = result.Data.Adapt<List<GetAllTeamsResposeViewModel>>();
                return EndpointResponse<List<GetAllTeamsResposeViewModel>>.Success(teamsDate);
        }

    }
}
