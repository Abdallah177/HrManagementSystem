using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.AddBreak.Dtos;
using HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.AddBreak.Queries;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.AddBreak.Commands
{
    public record AddBreakCommand(string Name , TimeSpan Duration , bool IsPaid) : IRequest<RequestResult<AddBreakDto>>;

    public class AddBreakCommandHandler : RequestHandlerBase<AddBreakCommand, RequestResult<AddBreakDto>, Break>
    {
        public AddBreakCommandHandler(RequestHandlerBaseParameters<Break> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<AddBreakDto>> Handle(AddBreakCommand request, CancellationToken cancellationToken)
        {
            var Isexist = await _mediator.Send(new CheckBreakExistwithName(request.Name));

            if (Isexist)
                return RequestResult<AddBreakDto>.Failure("A break with this name already exists.", ErrorCode.DuplicateRecord);

            var Break = request.Adapt<Break>();

            await _repository.AddAsync(Break, "System",cancellationToken);

            var addBreakDto = Break.Adapt<AddBreakDto>();

            return RequestResult<AddBreakDto>.Success(addBreakDto);
        }
    }

}
