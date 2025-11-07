using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;
using MediatR;
using Mapster;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingBranchesCommand(List<BranchesDto> Branches,string CurrentUserId) : IRequest<RequestResult<List<BranchesResponseDto>>>;
    public class OnBoardingBranchesCommandHandler : RequestHandlerBase<OnBoardingBranchesCommand, RequestResult<List<BranchesResponseDto>>, Branch>
    {
        public OnBoardingBranchesCommandHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }

        public async  override Task<RequestResult<List<BranchesResponseDto>>> Handle(OnBoardingBranchesCommand request, CancellationToken cancellationToken)
        {
            var branchesResponses = new List<BranchesResponseDto>();

            // ✅ Bulk add - CompanyId already assigned in each branch
            foreach (var branchDto in request.Branches)
            {
                var branch = branchDto.Adapt<Branch>();
                await _repository.AddAsync(branch, request.CurrentUserId, cancellationToken);

                branchesResponses.Add(new BranchesResponseDto
                {
                    BranchId = branch.Id,
                    Departments = branchDto.Departments
                });
            }

            return RequestResult<List<BranchesResponseDto>>.Success(branchesResponses,"Branches created successfully");
        }
    }
}
