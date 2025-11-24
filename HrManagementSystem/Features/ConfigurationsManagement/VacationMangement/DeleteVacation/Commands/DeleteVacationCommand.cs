using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.DeleteVacation.Commands
{
    public record DeleteVacationCommand(string Id, string UserId) : IRequest<RequestResult<bool>>;
    
    public class DeleteVacationCommandHandler : RequestHandlerBase<DeleteVacationCommand, RequestResult<bool>, Vacation>
    {
        public DeleteVacationCommandHandler(RequestHandlerBaseParameters<Vacation> parameters) : base(parameters)
        {
        }
        public override async Task<RequestResult<bool>> Handle(DeleteVacationCommand request, CancellationToken cancellationToken)
        {
            // CheckVacationExists
            var IsVacationExists = await _repository.IsExistsAsync(p => p.Id == request.Id, cancellationToken);
            if (!IsVacationExists)
                return RequestResult<bool>.Failure("Vacation Not Found", ErrorCode.VacationNotExist);

            await _repository.DeleteAsync(request.Id, request.UserId, cancellationToken);
            return RequestResult<bool>.Success(true);
        }
    }
}
