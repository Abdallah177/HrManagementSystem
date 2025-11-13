using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.DisabilityManagement.UpdateDisability.Commands;
using MediatR;
using HrManagementSystem.Features.DisabilityManagement.GetDisabilityById.Queries;

namespace HrManagementSystem.Features.DisabilityManagement.DeleteDisability.Commands
{
    public record DeleteDisabilityCommand(string Id) : IRequest<RequestResult<bool>>;
    public class DeleteDisabilityCommandHandler : RequestHandlerBase<DeleteDisabilityCommand, RequestResult<bool>, Disability>
    {
        public DeleteDisabilityCommandHandler(RequestHandlerBaseParameters<Disability> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(DeleteDisabilityCommand request, CancellationToken cancellationToken)
        {
            var disabilityDto = await _mediator.Send(new GetDisabilityByIdQuery(request.Id));
            if (disabilityDto == null)
                return RequestResult<bool>.Failure(disabilityDto.Message, disabilityDto.ErrorCode);

        }
    }
}
