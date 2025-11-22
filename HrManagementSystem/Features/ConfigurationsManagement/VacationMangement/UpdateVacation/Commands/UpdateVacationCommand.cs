using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Common.Views;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.UpdateVacation.Commands
{
    public record UpdateVacationCommand( string Id, string Name, VacationType Type, int DurationInDays, string Description)
        : IRequest<RequestResult<UpdateVacationResponseViewModel>>;

    public class UpdateVacationCommandHandler : RequestHandlerBase<UpdateVacationCommand, RequestResult<UpdateVacationResponseViewModel>, Vacation>
    {
        public UpdateVacationCommandHandler(RequestHandlerBaseParameters<Vacation> parameters)
            : base(parameters)
        {
        }
        public override async Task<RequestResult<UpdateVacationResponseViewModel>> Handle(UpdateVacationCommand request, CancellationToken cancellationToken)
        {
            // Check Vacation Exists
            var vacationResult = await _repository.GetByIDAsync(request.Id, cancellationToken);

            if (vacationResult == null)
                return RequestResult<UpdateVacationResponseViewModel>.Failure("Vacation Not Found", ErrorCode.VacationNotExist);

            request.Adapt(vacationResult);

            await _repository.UpdateIncludeAsync(
                vacationResult, request.Id, cancellationToken,
                nameof(vacationResult.Name),
                nameof(vacationResult.Type),
                nameof(vacationResult.DurationInDays),
                nameof(vacationResult.Description)
                );

            var viewModel = vacationResult.Adapt<UpdateVacationResponseViewModel>();
            return RequestResult<UpdateVacationResponseViewModel>.Success(viewModel);
        }
    }

}
