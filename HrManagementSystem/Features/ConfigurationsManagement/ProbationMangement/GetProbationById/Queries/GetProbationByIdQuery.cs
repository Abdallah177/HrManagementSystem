using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetProbationById.DTOs;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetProbationById.Queries
{
    public record GetProbationByIdQuery(string Id) : IRequest<RequestResult<GetProbationByIdResponseViewModel>>;

    public class GetprobationByIdQueryHandler : RequestHandlerBase<GetProbationByIdQuery, RequestResult<GetProbationByIdResponseViewModel>, Probation>
    {
        public GetprobationByIdQueryHandler(RequestHandlerBaseParameters<Probation> parameters) : base(parameters)
        { }
        public override async Task<RequestResult<GetProbationByIdResponseViewModel>> Handle(GetProbationByIdQuery request, CancellationToken cancellationToken)
        {
            var probation = await _repository.GetAll()
                .Where(p => p.Id == request.Id)
                .ProjectToType<GetProbationByIdResponseViewModel>()
                .FirstOrDefaultAsync(cancellationToken);

            if (probation == null)
                return RequestResult<GetProbationByIdResponseViewModel>.Failure("The requested Probation was not found.", ErrorCode.ProbationNotFound);

            return RequestResult<GetProbationByIdResponseViewModel>.Success(probation);
        }
    }


}
