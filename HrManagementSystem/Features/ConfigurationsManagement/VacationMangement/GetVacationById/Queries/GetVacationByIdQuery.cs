using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Enums;
using HrManagementSystem.Common.Views;
using HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetProbationById.DTOs;
using HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.GetVacationById.DTOs;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.GetVacationById.Queries
{
    public record GetVacationByIdQuery(string Id) : IRequest<RequestResult<GetVacationByIdResponseViewModel>>;

    public class GetVacationByIdQueryHandler : RequestHandlerBase<GetVacationByIdQuery, RequestResult<GetVacationByIdResponseViewModel>, Vacation>
        {
        public GetVacationByIdQueryHandler(RequestHandlerBaseParameters<Vacation> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<GetVacationByIdResponseViewModel>> Handle(GetVacationByIdQuery request, CancellationToken cancellationToken)
        {
            var vacation = await _repository.GetAll()
                .Where(v => v.Id == request.Id)
                .ProjectToType<GetVacationByIdResponseViewModel>()
                .FirstOrDefaultAsync(cancellationToken);

            if (vacation == null)
                return RequestResult<GetVacationByIdResponseViewModel>.Failure("The requested Probation was not found.", ErrorCode.VacationNotFound);

            return RequestResult<GetVacationByIdResponseViewModel>.Success(vacation);
        }
    }


}
