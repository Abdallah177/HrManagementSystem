using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;
using MediatR;
using Mapster;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingDepartmentsCommand(List<BranchesResponseDto> Branches, string currentUserId) : IRequest<RequestResult<List<DepartmentsResponseDto>>>;
    public class OnBoardingDepartmentsCommandHandler : RequestHandlerBase<OnBoardingDepartmentsCommand, RequestResult<List<DepartmentsResponseDto>>, Department>
    {
        public OnBoardingDepartmentsCommandHandler(RequestHandlerBaseParameters<Department> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<DepartmentsResponseDto>>> Handle(OnBoardingDepartmentsCommand request, CancellationToken cancellationToken)
        {
            var departmentsResponses = new List<DepartmentsResponseDto>();

            var departmentsDtos = request.Branches
             .SelectMany(branch =>
               (branch.Departments != null && branch.Departments.Count != 0)
                ? branch.Departments
                    .Select(d => new
                    {
                        Department = d with { BranchId = branch.BranchId },
                        branch.CompanyId
                    })

                : new[]
                {
                    new
                    {
                        Department = new DepartmentsDto(
                            $"{branch.BranchName} Department",
                            "Default department",
                            branch.BranchId,
                            new List<TeamsDto>()
                        ),
                        branch.CompanyId
                    }
                 }).ToList();

            //var departmentsDto = departmentsDtos.Select(x => x.Department).ToList();
            var departments = departmentsDtos.Select(x => x.Department).Adapt<List<Department>>();

            await _repository.AddRangeAsync(departments, request.currentUserId, cancellationToken);

             departmentsResponses = departments.Select((dept, index) => new DepartmentsResponseDto
            {
                DepartmentId = dept.Id,
                DepartmentName = dept.Name,
                BranchId = dept.BranchId,
                CompanyId = departmentsDtos[index].CompanyId,
                Teams = departmentsDtos[index].Department.Teams 

            }).ToList();

            return RequestResult<List<DepartmentsResponseDto>>.Success(departmentsResponses, "Departments created successfully");
        }
    }
}
