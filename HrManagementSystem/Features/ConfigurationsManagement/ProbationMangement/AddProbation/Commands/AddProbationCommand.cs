using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums.FeatureEnums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.AddProbation.DTOs;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.AddProbation.Commands
{
    public record AddProbationCommand(int DurationInDays, string? EvaluationCriteria, ProbationStatus Status) : IRequest<RequestResult<AddProbationDto>>;

    public class AddProbationCommandHandler : RequestHandlerBase<AddProbationCommand, RequestResult<AddProbationDto>, Probation>
    {
        public AddProbationCommandHandler(RequestHandlerBaseParameters<Probation> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<AddProbationDto>> Handle(AddProbationCommand request, CancellationToken cancellationToken)
        {
            var probation = request.Adapt<Probation>();

            await _repository.AddAsync(probation, cancellationToken);
            var probationDto = probation.Adapt<AddProbationDto>();

            return RequestResult<AddProbationDto>.Success(probationDto);

        }
    }



}
