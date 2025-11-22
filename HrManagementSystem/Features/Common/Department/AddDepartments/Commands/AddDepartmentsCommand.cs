using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using MediatR;
using Mapster;
using HrManagementSystem.Features.Common.Department.AddDepartments.Dtos;
using HrManagementSystem.Features.Common.Team.AddTeams.Dtos;

namespace HrManagementSystem.Features.Common.Department.AddDepartments.Commands
{
    public record AddDepartmentsCommand(List<AddDepartmentsHierarchyRequestDto> departmentsRequestDto, string currentUserId) : IRequest<RequestResult<List<DepartmentsResponseDto>>>;
    public class AddDepartmentsCommandHandler : RequestHandlerBase<AddDepartmentsCommand, RequestResult<List<DepartmentsResponseDto>>, HrManagementSystem.Common.Entities.Department>
    {
        public AddDepartmentsCommandHandler(RequestHandlerBaseParameters<HrManagementSystem.Common.Entities.Department> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<DepartmentsResponseDto>>> Handle(AddDepartmentsCommand request, CancellationToken cancellationToken)
        {
            var departmentsResponses = new List<DepartmentsResponseDto>();

            var departmentsDtos = request.departmentsRequestDto
             .SelectMany(branch =>
               branch.Departments != null && branch.Departments.Count != 0
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

            var departments = departmentsDtos.Select(x => x.Department).Adapt<List<HrManagementSystem.Common.Entities.Department>>();

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
