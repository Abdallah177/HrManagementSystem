using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.UpdateRequest.DTOS;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.UpdateRequest.Commands
{
    public record UpdateRequestCommand(string Id, string Title, string? Description, RequestStatus Status)
        : IRequest<RequestResult<UpdateRequestDTO>>;
    public class UpdateRequestCommandHandler : RequestHandlerBase<UpdateRequestCommand, RequestResult<UpdateRequestDTO>,Request>
    {
        public UpdateRequestCommandHandler(RequestHandlerBaseParameters<Request> parameters)
            : base(parameters)
        {
        }
        public override async Task<RequestResult<UpdateRequestDTO>> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            // Check Request Exists
            var requestResult = await _repository.GetByIDAsync(request.Id);

            if (requestResult is null)
                return RequestResult<UpdateRequestDTO>.Failure("Request Not Found", ErrorCode.RequestNotExist);

            request.Adapt(requestResult);

            await _repository.UpdateIncludeAsync(
                requestResult, request.Id, cancellationToken,
                nameof(Request.Title),
                nameof(Request.Description),
                nameof(Request.Status)
                );

            var dto = requestResult.Adapt<UpdateRequestDTO>();

            return RequestResult<UpdateRequestDTO>.Success(dto);
        }
    }


}
