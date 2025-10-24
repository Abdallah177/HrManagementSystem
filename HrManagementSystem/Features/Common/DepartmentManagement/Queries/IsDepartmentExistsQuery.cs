using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.Common.DepartmentManagement.Queries;

public record IsDepartmentExistsQuery(string Id) : IRequest<EndpointResponse<bool>>;

public class IsDepartmentExistsQueryHandler(IGenericRepository<Department> genericRepository) : IRequestHandler<IsDepartmentExistsQuery, EndpointResponse<bool>>
{
    private readonly IGenericRepository<Department> _genericRepository = genericRepository;

    public async Task<EndpointResponse<bool>> Handle(IsDepartmentExistsQuery request, CancellationToken cancellationToken)
    {
        var isDepartmentExists = await _genericRepository.Get(x => x.Id == request.Id).AnyAsync(cancellationToken);

        return isDepartmentExists ? EndpointResponse<bool>.Success(default) : EndpointResponse<bool>.Failure("Department not found");
    }
}

