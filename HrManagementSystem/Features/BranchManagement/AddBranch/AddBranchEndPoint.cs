using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.BranchManagement.AddBranch.Commands;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace HrManagementSystem.Features.BranchManagement.AddBranch
{
    public class AddBranchEndPoint : BaseEndPoint<AddBranchRquestViewModel, AddBranchResponseViewModel>
    {
        public AddBranchEndPoint(EndpointBaseParameters<AddBranchRquestViewModel> parameters) : base(parameters)
        {
        }
        [HttpPost]
        public async Task<EndpointResponse<AddBranchResponseViewModel>> AddBranch(AddBranchRquestViewModel viewModel, CancellationToken cancellationToken)
        {
            var validationResult = ValidateRequest(viewModel);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }
            var result = await _mediator.Send(new AddBranchCommand(viewModel.Name, viewModel.CityId, viewModel.Phone, viewModel.CompanyId, viewModel.UserId));
            if (!result.IsSuccess)
                return EndpointResponse<AddBranchResponseViewModel>.Failure(result.Message, result.ErrorCode);

            var addBranchResponseViewModel = result.Data.Adapt<AddBranchResponseViewModel>();

            return EndpointResponse<AddBranchResponseViewModel>.Success(addBranchResponseViewModel);
        }

    }

}
