using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetProbationById.Queries;
using HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.UpdateProbation.DTOs;
using Mapster;
using MediatR;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.UpdateProbation.Commands
{
    public record UpdateProbationCommand(string Id, int DurationInDays, string? EvaluationCriteria) 
        : IRequest<RequestResult<UpdateProbationDto>>;

    public class UpdateProbationCommandHandler : RequestHandlerBase<UpdateProbationCommand, RequestResult<UpdateProbationDto>, Probation>
    {
        public UpdateProbationCommandHandler(RequestHandlerBaseParameters<Probation> parameters)
            : base(parameters)
        {
        }
        public override async Task<RequestResult<UpdateProbationDto>> Handle(UpdateProbationCommand request, CancellationToken cancellationToken)
        {
            // Check Probation Exists
            var probationRuslt = await _repository.GetByIDAsync(request.Id);
            if (probationRuslt is null)
                return RequestResult<UpdateProbationDto>.Failure("Probation Not Found", ErrorCode.ProbationNotExist);

            request.Adapt(probationRuslt);


            await _repository.UpdateIncludeAsync(
                probationRuslt, request.Id, cancellationToken,
                nameof(Probation.DurationInDays),
                nameof(Probation.EvaluationCriteria)
                );


            var dto = probationRuslt.Adapt<UpdateProbationDto>();
            return RequestResult<UpdateProbationDto>.Success(dto);
        }
    }

}
