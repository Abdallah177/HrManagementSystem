using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.Common.CheckIsEntityExist.Queries;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.DTOS;
using HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.Comman;
using HrManagementSystem.Features.ConfigurationsManagement.ShiftManagement.AddShift.Queries;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.Command
{
    public record AddRequestCommand(string Title, RequestStatus Status, string Description) : IRequest<RequestResult<AddRequestDTO>>;

    public class AddRequestCommandHandler : RequestHandlerBase<AddRequestCommand, RequestResult<AddRequestDTO>, Request>
    {
        public AddRequestCommandHandler(RequestHandlerBaseParameters<Request> parameters) : base(parameters) { }
        public override async Task<RequestResult<AddRequestDTO>> Handle(AddRequestCommand request, CancellationToken cancellationToken)
        {
            var ExistRequest = await _mediator.Send(new CheckExistQuery_Request(request.Title));
            if (ExistRequest)
                return RequestResult<AddRequestDTO>.Failure("A Request with this title already exists.", ErrorCode.DuplicateRecord);
            var requestEntity = request.Adapt<Request>();
            await _repository.AddAsync(requestEntity, cancellationToken);
            var addRequestDto = requestEntity.Adapt<AddRequestDTO>();
            return RequestResult<AddRequestDTO>.Success(addRequestDto);

        }
    }

}
