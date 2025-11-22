using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.Branch.AddBranches.Dtos;
using MediatR;
using HrManagementSystem.Features.Common.Department.AddDepartments.Dtos;
using System.Linq;
using Mapster;


namespace HrManagementSystem.Features.Common.Branch.AddBranches.Commands
{
    public record AddBranchesCommand(List<AddBranchesHierarchyRequestDto> branchesRequestDto, string currentUserId) : IRequest<RequestResult<List<BranchesResponseDto>>>;
    public class AddBranchesCommandHandler : RequestHandlerBase<AddBranchesCommand, RequestResult<List<BranchesResponseDto>>, HrManagementSystem.Common.Entities.Branch>
    {
        public AddBranchesCommandHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Branch> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<BranchesResponseDto>>> Handle(AddBranchesCommand request, CancellationToken cancellationToken)
        {
            var branchesResponses = new List<BranchesResponseDto>();

            var branchesDtos = request.branchesRequestDto
              .SelectMany(company =>
                company.Branches != null && company.Branches.Count != 0
                    ? company.Branches
                        .Select(b => b with { CompanyId = company.CompanyId })

                    : new[]
                    {
                        new BranchesDto(
                            $"{company.CompanyName} Branch",
                            null,
                            company.DefaultCityId,
                            company.CompanyId,
                            new List<DepartmentsDto>()
                        )
                    }).ToList();

            var branches = branchesDtos.Adapt<List<HrManagementSystem.Common.Entities.Branch>>();
            await _repository.AddRangeAsync(branches, request.currentUserId, cancellationToken);

            branchesResponses = branches.Select((branch, index) => new BranchesResponseDto
            {
                BranchId = branch.Id,
                BranchName = branch.Name,
                CompanyId = branch.CompanyId,
                Departments = branchesDtos[index].Departments

            }).ToList();


            return RequestResult<List<BranchesResponseDto>>.Success(branchesResponses, "Branches created successfully");
        }
    }
}
