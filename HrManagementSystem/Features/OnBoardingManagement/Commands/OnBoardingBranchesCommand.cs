using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;
using MediatR;
using Mapster;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Company;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingBranchesCommand(List<CompaniesResponseDto> Companies, string currentUserId) : IRequest<RequestResult<List<BranchesResponseDto>>>;
    public class OnBoardingBranchesCommandHandler : RequestHandlerBase<OnBoardingBranchesCommand, RequestResult<List<BranchesResponseDto>>, Branch>
    {
        public OnBoardingBranchesCommandHandler(RequestHandlerBaseParameters<Branch> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<BranchesResponseDto>>> Handle(OnBoardingBranchesCommand request, CancellationToken cancellationToken)
        {
            var branchesResponses = new List<BranchesResponseDto>();

            var branchesDto = request.Companies
               .SelectMany(company =>
                  company.Branches?.Where(b => b != null).Select(b => b with { CompanyId = company.CompanyId })

             ?? new List<BranchesDto>

             {
                new BranchesDto(
                    $"{company.CompanyName} Branch",
                    null,
                    company.DefaultCityId,
                    company.CompanyId,
                    new List<DepartmentsDto>()
                )
             }
             
         ).ToList(); 

            var branches = branchesDto.Adapt<List<Branch>>();
            await _repository.AddRangeAsync(branches, request.currentUserId, cancellationToken);

             branchesResponses = branches.Select((branch, index) => new BranchesResponseDto
            {
                BranchId = branch.Id,
                BranchName = branch.Name,
                CompanyId = branch.CompanyId,
                Departments = branchesDto[index].Departments

            }).ToList();


            return RequestResult<List<BranchesResponseDto>>.Success(branchesResponses,"Branches created successfully");
        }
    }
}
