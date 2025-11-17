using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.AddVacation.DTOs;
using HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.AddVacation.Queries;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.AddVacation.Command
{
    public record AddVacationCommand(string Name, VacationType Type, int DurationInDays, string? Description) : IRequest<RequestResult<AddVacationDto>>;

    public class AddVacationCommandHandler : RequestHandlerBase<AddVacationCommand, RequestResult<AddVacationDto>, Vacation>
    {
        public AddVacationCommandHandler(RequestHandlerBaseParameters<Vacation> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<AddVacationDto>> Handle(AddVacationCommand request, CancellationToken cancellationToken)
        {
            var isExist =await _mediator.Send(new CheckVacationExistwithName(request.Name));
            if (isExist)
                return RequestResult<AddVacationDto>.Failure("A vacation with this name already exists.", ErrorCode.DuplicateRecord);

            var vacation = request.Adapt<Vacation>();
            await _repository.AddAsync(vacation, cancellationToken);
            var addVacationDto = vacation.Adapt<AddVacationDto>();

            return RequestResult<AddVacationDto>.Success(addVacationDto);
        }
    }



}
