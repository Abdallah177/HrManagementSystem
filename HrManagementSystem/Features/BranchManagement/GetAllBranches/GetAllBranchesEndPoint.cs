using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.BranchManagement.GetAllBranches
{
    public class GetAllBranchesEndPoint : BaseEndPoint<object, GetAllBranchesResponseViewModel>  
    {
        public GetAllBranchesEndPoint(EndpointBaseParameters<object> parameters) : base(parameters)
        {
        }
        [HttpGet]
        public async Task<EndpointResponse<List<GetAllBranchesResponseViewModel>>> GetAllBranches()
        {
            var branchesQueryResult = await _mediator.Send(new GetAllBranches.Queries.GetAllBranchesQuery());
            if (!branchesQueryResult.IsSuccess)
                return EndpointResponse<List<GetAllBranchesResponseViewModel>>.Failure(branchesQueryResult.Message);

            return EndpointResponse<List<GetAllBranchesResponseViewModel>>.Success(branchesQueryResult.Data);
        }
    }
}
