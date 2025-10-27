﻿using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.DepartmentManagement.GetAllDepartment.Queries.Dtos;
using HrManagementSystem.Features.OrganizationManagement.GetAllOrganization.Queries.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.DepartmentManagement.GetAllDepartment.Queries
{
    public record GetAllDepartmentQuery(string? BranchId = null) : IRequest<RequestResult<List<GetAllDepartmentDto>>>;

    public class GetAllDepartmentQueryHandler : RequestHandlerBase<GetAllDepartmentQuery, RequestResult<List<GetAllDepartmentDto>>, Department>
    {
        public GetAllDepartmentQueryHandler(RequestHandlerBaseParameters<Department> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<List<GetAllDepartmentDto>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAll();

            if (!string.IsNullOrEmpty(request.BranchId))
                query = query.Where(d => d.BranchId == request.BranchId);
            
            var departments = await query
                .ProjectToType<GetAllDepartmentDto>()
                .ToListAsync(cancellationToken);

            if (departments == null)
                return RequestResult<List<GetAllDepartmentDto>>.Failure("No departments found", ErrorCode.NoDepartmentsFound);

            return RequestResult<List<GetAllDepartmentDto>>.Success(departments);
        }
    }
}
