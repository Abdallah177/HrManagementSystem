using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Repositories;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.BranchManagement.Queries;
using MediatR;

namespace HrManagementSystem.Features.BranchManagement.DeleteBranch.Commands;

public record DeleteBrnachByIdCommand(string Id) : IRequest<EndpointResponse<bool>>;

public class DeleteBrnachByIdCommandHandler(IGenericRepository<Branch> genericRepository,
    IMediator mediator) : IRequestHandler<DeleteBrnachByIdCommand, EndpointResponse<bool>>
{
    private readonly IGenericRepository<Branch> _genericRepository = genericRepository;
    private readonly IMediator _mediator = mediator;

    public async Task<EndpointResponse<bool>> Handle(DeleteBrnachByIdCommand request, CancellationToken cancellationToken)
    {
        var isBranchExist = await _mediator.Send(new IsBrnachExistQuery(request.Id));

        if (!isBranchExist.IsSuccess)
            return EndpointResponse<bool>.Failure("Branch Not found");

        await _genericRepository.DeleteAsync(request.Id, "test", cancellationToken);

        return EndpointResponse<bool>.Success(default);
    }
}
