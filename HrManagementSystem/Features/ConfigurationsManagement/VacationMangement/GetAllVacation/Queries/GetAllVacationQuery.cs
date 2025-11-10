using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using HrManagementSystem.Common.Views;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.GetAllVacation.Queries
{
    public record GetAllVacationQuery() : IRequest<RequestResult<List<GetAllVacationResponseViewModel>>>;

    public class GetAllVacationQueryHandler : RequestHandlerBase<GetAllVacationQuery, RequestResult<List<GetAllVacationResponseViewModel>>,Vacation>
    {
        public GetAllVacationQueryHandler(RequestHandlerBaseParameters<Vacation> parameters) : base(parameters)
        {
        }
        public override async Task<RequestResult<List<GetAllVacationResponseViewModel>>> Handle(GetAllVacationQuery request, CancellationToken cancellationToken)
        {
            var vacations = await _repository.GetAll()
                .ProjectToType<GetAllVacationResponseViewModel>()
                .ToListAsync(cancellationToken);

            return RequestResult<List<GetAllVacationResponseViewModel>>.Success(vacations);
        }
    }

}
