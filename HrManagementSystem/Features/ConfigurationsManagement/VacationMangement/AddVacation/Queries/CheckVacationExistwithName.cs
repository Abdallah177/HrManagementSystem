using HrManagementSystem.Common;
using HrManagementSystem.Common.Entities.Features;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.AddVacation.Queries
{
    public record CheckVacationExistwithName(string Name) : IRequest<bool>;

    public class CheckVacationExistwithNameHandler : RequestHandlerBase<CheckVacationExistwithName, bool, Vacation>
    {
        public CheckVacationExistwithNameHandler(RequestHandlerBaseParameters<Vacation> parameters) : base(parameters)
        {
        }
        public override async Task<bool> Handle(CheckVacationExistwithName request, CancellationToken cancellationToken)
        {
            return await _repository.Get(v => v.Name == request.Name).AnyAsync(cancellationToken);
        }
    }

}
