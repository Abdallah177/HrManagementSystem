using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.DepartmentManagement.GetDepartmentById.Query.DTOS;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.DepartmentManagement.GetDepartmentById.Query
{
    public record GetDepartmentByIdQuery(string DepartmentId) : IRequest<RequestResult<DepartmentDTO>>;

    public class GetDepartmentByIdQueryHandler : RequestHandlerBase<GetDepartmentByIdQuery, RequestResult<DepartmentDTO>, Department>
    {
        public GetDepartmentByIdQueryHandler(RequestHandlerBaseParameters<Department> parameters) : base(parameters)
        {
        }
        public async override Task<RequestResult<DepartmentDTO>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _repository.Get(d => d.Id == request.DepartmentId)
                .ProjectToType<DepartmentDTO>().FirstOrDefaultAsync(cancellationToken);
            if (department == null)
                return RequestResult<DepartmentDTO>.Failure("Department not found", ErrorCode.DepartmentNotExist);
            return RequestResult<DepartmentDTO>.Success(department);

        }
    }
}
