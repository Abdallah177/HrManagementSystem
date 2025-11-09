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

        public async  override Task<RequestResult<List<BranchesResponseDto>>> Handle(OnBoardingBranchesCommand request, CancellationToken cancellationToken)
        {
            var branchesResponses = new List<BranchesResponseDto>();

            var branchesDto = request.Companies.SelectMany(company =>
          company.Branches.Any() ? company.Branches.Select(branch => new
          {
              BranchDto = new BranchesDto(
                  branch.Name,
                  branch.Phone,
                  branch.CityId,
                  company.CompanyId,
                  branch.Departments
              )
          })
          : new[]
          {
                new
                {
                    BranchDto = new BranchesDto(
                        $"{company.CompanyName} Branch",
                        null,
                        company.DefaultCityId,
                        company.CompanyId,
                        new List<DepartmentsDto>()
                    )
                }
          }).ToList();

            foreach (var item in branchesDto)
            {
                var branch = item.BranchDto.Adapt<Branch>();
                await _repository.AddAsync(branch, request.currentUserId, cancellationToken);

                branchesResponses.Add(new BranchesResponseDto
                {
                    BranchId = branch.Id,
                    BranchName = branch.Name,
                    CompanyId = branch.CompanyId,
                    Departments = item.BranchDto.Departments
                });
            }

            return RequestResult<List<BranchesResponseDto>>.Success(branchesResponses,"Branches created successfully");
        }
    }
}
