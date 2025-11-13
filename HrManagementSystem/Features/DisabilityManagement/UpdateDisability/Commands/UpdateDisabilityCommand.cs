using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Entities.Location;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.DisabilityManagement.GetDisabilityById.Queries;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.DisabilityManagement.UpdateDisability.Commands
{
    public record UpdateDisabilityCommand(string Id, DisabilityType Type, string? Description, bool RequiresSpecialSupport, string CurrentUserId) : IRequest<RequestResult<bool>>;

    public class UpdateDisabilityCommandHandler : RequestHandlerBase<UpdateDisabilityCommand, RequestResult<bool>, Disability>
    {
        public UpdateDisabilityCommandHandler(RequestHandlerBaseParameters<Disability> parameters) : base(parameters)
        {
        }

        public async override Task<RequestResult<bool>> Handle(UpdateDisabilityCommand request, CancellationToken cancellationToken)
        {
            var disabilityDto = await _mediator.Send(new GetDisabilityByIdQuery(request.Id));
            if (disabilityDto == null)
                return RequestResult<bool>.Failure(disabilityDto.Message , disabilityDto.ErrorCode);

            var disability = disabilityDto.Data.Adapt<Disability>();
            request.Adapt(disability);

            await  _repository.UpdateIncludeAsync(
                disability,
                request.CurrentUserId,
                cancellationToken,
                nameof(Disability.Type),
                nameof(Disability.Description),
                nameof(Disability.RequiresSpecialSupport)
            );

            return RequestResult<bool>.Success(true, "Disability updated successfully");
        }
    }
}
