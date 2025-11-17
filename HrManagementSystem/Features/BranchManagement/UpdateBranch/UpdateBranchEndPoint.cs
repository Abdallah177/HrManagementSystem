using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.UpdateBranch.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HrManagementSystem.Features.BranchManagement.UpdateBranch
{
    public class UpdateBranchEndPoint : BaseEndPoint<UpdateBranchRequsetViewModel, UpdateBranchResponseViewModel>
    {
        public UpdateBranchEndPoint(EndpointBaseParameters<UpdateBranchRequsetViewModel> parameters)
            : base(parameters)
        {
        }

        [HttpPut]
        public async Task<EndpointResponse<UpdateBranchResponseViewModel>> UpdateBranch(
            UpdateBranchRequsetViewModel viewModel)
        {
           
            var result = await _mediator.Send(new UpdateBranchCommand(
                viewModel.Id, 
                viewModel.Name, 
                viewModel.Phone,
                viewModel.CompanyId, 
                viewModel.CityId));

            if (!result.IsSuccess)
                return EndpointResponse<UpdateBranchResponseViewModel>.Failure(result.Message, result.ErrorCode);
            
            var response = result.Data.Adapt<UpdateBranchResponseViewModel>();
            return EndpointResponse<UpdateBranchResponseViewModel>.Success(response);
        }
            
    }
}
