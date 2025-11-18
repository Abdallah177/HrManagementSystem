using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.DeleteProbation.Commands
{
    public record DeleteProbationCommand (string Id, string UserId) : IRequest<RequestResult<bool>>;
    
    public class DeleteProbationCommandHandler : RequestHandlerBase<DeleteProbationCommand, RequestResult<bool>, Probation>
    {
        public DeleteProbationCommandHandler(RequestHandlerBaseParameters<Probation> parameters) : base(parameters)
        {
        }
        public override async Task<RequestResult<bool>> Handle(DeleteProbationCommand request, CancellationToken cancellationToken)
        {
            // CheckProbationExists
            var IsProbationExists = await _repository.IsExistsAsync(p => p.Id == request.Id, cancellationToken);
            if (!IsProbationExists)
                return RequestResult<bool>.Failure("Probation Not Found", ErrorCode.ProbationNotExist);

            await _repository.DeleteAsync(request.Id, request.UserId, cancellationToken);
            return RequestResult<bool>.Success(true);
        }
    }
}
