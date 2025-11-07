using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.OnBoardingManagement.Commands.Dtos.Department;
using MediatR;
using Mapster;

namespace HrManagementSystem.Features.OnBoardingManagement.Commands
{
    public record OnBoardingDepartmentsCommand(List<DepartmentsDto> Departments, string CurrentUserId) : IRequest<RequestResult<List<DepartmentsResponseDto>>>;
    public class OnBoardingDepartmentsCommandHandler : RequestHandlerBase<OnBoardingDepartmentsCommand, RequestResult<List<DepartmentsResponseDto>>, Department>
    {
        public OnBoardingDepartmentsCommandHandler(RequestHandlerBaseParameters<Department> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<DepartmentsResponseDto>>> Handle(OnBoardingDepartmentsCommand request, CancellationToken cancellationToken)
        {
            var departmentsResponses = new List<DepartmentsResponseDto>();

            foreach (var deptDto in request.Departments)
            {
                var department = deptDto.Adapt<Department>();
                await _repository.AddAsync(department, request.CurrentUserId, cancellationToken);

                departmentsResponses.Add(new DepartmentsResponseDto
                {
                    DepartmentId = department.Id,
                    Teams = deptDto.Teams 
                });
            }
            return RequestResult<List<DepartmentsResponseDto>>.Success(departmentsResponses,"Departments created successfully");
        }
    }
}
