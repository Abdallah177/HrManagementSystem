using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.DeleteRequest.Commands
{
        public record DeleteRequestCommand (string Id, string UserId) : IRequest<RequestResult<bool>>;

        public class DeleteRequestCommandHandler : RequestHandlerBase<DeleteRequestCommand, RequestResult<bool>, Request>
        {
            public DeleteRequestCommandHandler(RequestHandlerBaseParameters<Request> parameters) : base(parameters)
            {
            }
            public override async Task<RequestResult<bool>> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
            {
                // CheckRequestExists
                var IsRequestExists = await _repository.IsExistsAsync(p => p.Id == request.Id, cancellationToken);

                if (!IsRequestExists)
                    return RequestResult<bool>.Failure("Request Not Found", ErrorCode.RequestNotExist);

                await _repository.DeleteAsync(request.Id, request.UserId, cancellationToken);
                return RequestResult<bool>.Success(true);
            }
  
       }
 }

