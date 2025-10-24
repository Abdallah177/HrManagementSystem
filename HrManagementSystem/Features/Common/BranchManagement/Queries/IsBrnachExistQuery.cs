using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.Common.BranchManagement.Queries;

public record IsBrnachExistQuery(string Id) : IRequest<EndpointResponse<bool>>;

public class IsBrnachExistQueryHandler(IGenericRepository<Branch> genericRepository) : IRequestHandler<IsBrnachExistQuery, EndpointResponse<bool>>
{
    private readonly IGenericRepository<Branch> _genericRepository = genericRepository;

    public async Task<EndpointResponse<bool>> Handle(IsBrnachExistQuery request, CancellationToken cancellationToken)
    {
        var isBranchExist = await _genericRepository.Get(x => x.Id == request.Id).AnyAsync(cancellationToken);

        if (!isBranchExist)
            return EndpointResponse<bool>.Failure("Branch Not found");

        return EndpointResponse<bool>.Success(default,"Branch Found");

    }
}
