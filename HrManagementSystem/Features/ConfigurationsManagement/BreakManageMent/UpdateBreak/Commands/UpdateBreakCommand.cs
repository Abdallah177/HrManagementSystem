using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.AddBreak.Dtos;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.AddBreak.Queries;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.GetBreakById.Queries;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.UpdateBreak.Dtos;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.UpdateBreak.Commands
{
    public record UpdateBreakCommand (string Id , string Name, TimeSpan Duration, bool IsPaid):IRequest<RequestResult<UpdateBreakDto>>;

    public class UpdateBreakCommandHandler : RequestHandlerBase<UpdateBreakCommand, RequestResult<UpdateBreakDto>, Break>
    {
        public UpdateBreakCommandHandler(RequestHandlerBaseParameters<Break> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<UpdateBreakDto>> Handle(UpdateBreakCommand request, CancellationToken cancellationToken)
        {
            var BreakResult =await _mediator.Send(new GetBreakByIdQuery(request.Id));

            if (!BreakResult.IsSuccess)
                return RequestResult<UpdateBreakDto>.Failure(BreakResult.Message, BreakResult.ErrorCode);

            var BreakEntity = BreakResult.Data.Adapt<Break>();

            if (BreakEntity.Name != request.Name)
            {
                var Isexist = await _mediator.Send(new CheckBreakExistwithName(request.Name));

                if (Isexist)
                    return RequestResult<UpdateBreakDto>.Failure("A break with this name already exists.", ErrorCode.DuplicateRecord);
            }
            BreakEntity.Name = request.Name;
            BreakEntity.Duration = request.Duration;
            BreakEntity.IsPaid = request.IsPaid;

            await _repository.UpdateIncludeAsync(BreakEntity, "System", cancellationToken, nameof(Break.Name), nameof(Break.Duration), nameof(Break.IsPaid));

            var updateBreakDto = BreakEntity.Adapt<UpdateBreakDto>();   

            return RequestResult<UpdateBreakDto>.Success(updateBreakDto);
        }
    }



}
