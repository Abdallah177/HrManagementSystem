using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.Common.CheckExists;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.DeleteBreak.Commands
{
    public record DeleteBreakCommand (string Id) : IRequest<RequestResult<bool>>;

    public class DeleteBreakCommandHandler : RequestHandlerBase<DeleteBreakCommand, RequestResult<bool>, Break>
    {
        public DeleteBreakCommandHandler(RequestHandlerBaseParameters<Break> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(DeleteBreakCommand request, CancellationToken cancellationToken)
        {
            var isExist =await _mediator.Send(new CheckExistsQuery<Break>(request.Id));

            if (!isExist)
                return RequestResult<bool>.Failure("Break Not Found .", ErrorCode.BreakNotFound);

            await _repository.DeleteAsync(request.Id,"System", cancellationToken);

            return RequestResult<bool>.Success(true);
        }
    }


}
