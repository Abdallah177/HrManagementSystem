using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;
using MediatR;
using Mapster;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Branch;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Team;
using System.Linq;

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

            var departmentsDto = request.Branches
              .SelectMany(branch =>
              {
                  var validDepartments = branch.Departments?.Where(d => d != null).ToList();

                  return (validDepartments?.Count ?? 0) > 0
                      ? validDepartments.Select(dept => new DepartmentsDto(
                          dept.Name,
                          dept.Description,
                          branch.BranchId,
                          dept.Teams?.Where(t => t != null).ToList() ?? new List<TeamsDto>()))

                      : new[]
                      {
                        new DepartmentsDto(
                            $"{branch.BranchName} Department",
                            "Default department",
                            branch.BranchId,
                            new List<TeamsDto>())
                      };
              }).ToList();

            foreach (var departmentDto in departmentsDto)
            {
                var department = departmentDto.Adapt<Department>();
                await _repository.AddAsync(department, request.currentUserId, cancellationToken);

                departmentsResponses.Add(new DepartmentsResponseDto
                {
                    DepartmentId = department.Id,
                    DepartmentName = department.Name,
                    BranchId = department.BranchId,
                    Teams = departmentDto.Teams
                });
            }

            return RequestResult<List<DepartmentsResponseDto>>.Success(departmentsResponses, "Departments created successfully");
        }
    }
}
